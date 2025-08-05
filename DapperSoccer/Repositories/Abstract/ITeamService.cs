using DapperSoccer.Dtos.TeamDto;

namespace DapperSoccer.Repositories.Abstract
{
    public interface ITeamService
    {
        Task<List<OldestTeamDto>> GetOldestTeamsAsync();
        Task<List<RandomTeamDto>> GetRandomTeamsAsync();
        Task<List<LongestTeamDto>> GetLongestTeamsAsync();
       
        Task<List<ResultTeamDto>> GetResultTeamsAsync();
    }
}

