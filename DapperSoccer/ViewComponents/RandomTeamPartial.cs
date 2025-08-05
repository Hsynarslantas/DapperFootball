using DapperSoccer.Repositories.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace DapperSoccer.ViewComponents
{
    public class RandomTeamPartial:ViewComponent
    {
        private readonly ITeamService _teamService;

        public RandomTeamPartial(ITeamService teamService)
        {
            _teamService = teamService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values=await _teamService.GetRandomTeamsAsync();
            return View(values);
        }
    }
}
