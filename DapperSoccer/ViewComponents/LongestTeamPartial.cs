using DapperSoccer.Repositories.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace DapperSoccer.ViewComponents
{
    public class LongestTeamPartial:ViewComponent
    {
        private readonly ITeamService _teamService;

        public LongestTeamPartial(ITeamService teamService)
        {
            _teamService = teamService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _teamService.GetLongestTeamsAsync();
            return View(values);
        }
    }
}
