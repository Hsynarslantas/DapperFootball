using DapperSoccer.Dtos.PlayerDto;

namespace DapperSoccer.Repositories.Abstract
{
    public interface IPlayerService
    {
        Task<List<TopPotentialPlayerDto>> GetTopPotentialPlayersAsync(int count);
        Task<List<HighHeightPlayerDto>> GetHighHeightPlayersAsync();
        Task<List<FirstBirthdayPlayerDto>> FirstBirthdayPlayerDtoAsync();
        Task<List<WorstWeightPlayerDto>> GetWorstWeightPlayersAsync();
        Task<BestPotentialPlayerDto> GetBestPotentialPlayerAsync();
        Task<List<ResultPlayerDto>> GetResultPlayersAsync();
        Task<int> GetGetCountPlayersAsync();
        Task<List<ResultPlayerDto>> SearchPlayersAsync(string searchTerm);
    }
}
