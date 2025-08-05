using Dapper;
using DapperSoccer.Context;
using DapperSoccer.Dtos.TeamDto;
using DapperSoccer.Repositories.Abstract;

namespace DapperSoccer.Repositories.Concrete
{
    public class TeamService : ITeamService
    {
        private readonly DapperContext context;

        public TeamService(DapperContext context)
        {
            this.context = context;
        }

        public async Task<List<LongestTeamDto>> GetLongestTeamsAsync()
        {
            string query = "SELECT TOP 1 team_long_name,team_short_name FROM TblTeam WHERE team_long_name IS NOT NULL ORDER BY team_long_name DESC ";
            var connection=context.CreateConnection();
            var values=await connection.QueryAsync<LongestTeamDto>(query);
            return values.ToList();
        }

        public async Task<List<OldestTeamDto>> GetOldestTeamsAsync()
        {
            string query = @"SELECT Top 3 team_api_id date FROM TblTeamAttributes WHERE date IS NOT NULL ORDER BY date ASC";
            var connection=context.CreateConnection();
            var value=await connection.QueryAsync<OldestTeamDto>(query);
            return value.ToList();
        }

        public async Task<List<RandomTeamDto>> GetRandomTeamsAsync()
        {
            string query = "SELECT TOP 3 team_api_id,team_long_name FROM TblTeam WHERE team_long_name IS NOT NULL ORDER BY NEWID()";
            var connection=context.CreateConnection();
            var value=await connection.QueryAsync<RandomTeamDto>(query);
            return value.ToList();
        }

        public async Task<List<ResultTeamDto>> GetResultTeamsAsync()
        {
            string query = "SELECT * FROM TblTeam";
            var connection=context.CreateConnection();
            var values=await connection.QueryAsync<ResultTeamDto>(query);
            return values.ToList();
        }
    }
}
