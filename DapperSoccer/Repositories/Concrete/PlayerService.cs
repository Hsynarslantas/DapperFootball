using AutoMapper.Configuration.Annotations;
using Dapper;
using DapperSoccer.Context;
using DapperSoccer.Dtos.PlayerDto;
using DapperSoccer.Repositories.Abstract;

namespace DapperSoccer.Repositories.Concrete
{
    public class PlayerService : IPlayerService
    {
        private readonly DapperContext context;

        public PlayerService(DapperContext context)
        {
            this.context = context;
        }

        public async Task<List<FirstBirthdayPlayerDto>> FirstBirthdayPlayerDtoAsync()
        {
            string query = "SELECT TOP 1 player_name,CONVERT(varchar(10),birthday,120) AS birthday FROM TblPlayer WHERE birthday IS NOT NULL ORDER BY birthday ASC";
            var connection=context.CreateConnection();
            var value=await connection.QueryAsync<FirstBirthdayPlayerDto>(query);
            return value.ToList();
        }

        public async Task<BestPotentialPlayerDto> GetBestPotentialPlayerAsync()
        {
            string query = "SELECT TOP 1 p.player_api_id,p.player_name,a.potential,a.finishing,a.dribbling,a.agility,a.stamina FROM TblPlayer p INNER JOIN TblPlayerAttributes a ON p.player_api_id=a.player_api_id WHERE a.potential IS NOT NULL ORDER BY a.potential DESC";
            var connection=context.CreateConnection();
            var value= await connection.QueryFirstOrDefaultAsync<BestPotentialPlayerDto>(query);
            return value;
        }

        public Task<int> GetGetCountPlayersAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<List<HighHeightPlayerDto>> GetHighHeightPlayersAsync()
        {
            string query = "SELECT TOP 1 player_name,height FROM TblPlayer WHERE height IS NOT NULL ORDER BY height DESC";
            var connection=context.CreateConnection();
            var value=await connection.QueryAsync<HighHeightPlayerDto>(query);
            return value.ToList();
        }
        public async Task<List<ResultPlayerDto>> GetResultPlayersAsync()
        {
            string query = "SELECT * FROM TblPlayer";
            var connections=context.CreateConnection();
            var value= await connections.QueryAsync<ResultPlayerDto>(query);
            return value.ToList();
        }

        public async Task<List<TopPotentialPlayerDto>> GetTopPotentialPlayersAsync(int count)
        {
            string query = "SELECT TOP 5 p.player_name, MAX(a.overall_rating) AS overall_rating, MAX(a.potential) AS potential FROM TblPlayerAttributes a INNER JOIN TblPlayer p ON a.player_api_id = p.player_api_id WHERE a.overall_rating > 0 AND a.potential > 0 GROUP BY p.player_api_id, p.player_name ORDER BY MAX(a.potential) DESC, MAX(a.overall_rating) DESC";
            var connection = context.CreateConnection();
            var value = await connection.QueryAsync<TopPotentialPlayerDto>(query);
            return value.ToList();
        }

        public async Task<List<WorstWeightPlayerDto>> GetWorstWeightPlayersAsync()
        {
            string query = "SELECT TOP 1 player_name,weight FROM TblPlayer WHERE weight IS NOT NULL ORDER BY weight ASC";
            var connection=context.CreateConnection();
            var value = await connection.QueryAsync<WorstWeightPlayerDto>(query);
            return value.ToList();
        }
        public async Task<List<ResultPlayerDto>> SearchPlayersAsync(string searchTerm)
        {
            var connection = context.CreateConnection();

            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                // Boşsa tüm futbolcuları getir
                return await GetResultPlayersAsync();
            }

            string query = "SELECT player_name, birthday, height, weight FROM TblPlayer WHERE player_name LIKE @SearchTerm";
            var values = await connection.QueryAsync<ResultPlayerDto>(query, new
            {
                SearchTerm = $"%{searchTerm}%"
            });

            return values.ToList();
        }
    }
}
