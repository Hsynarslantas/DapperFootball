using DapperSoccer.Repositories.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace DapperSoccer.Controllers
{
    public class TeamController : Controller
    {
        private readonly ITeamService _teamService;

        public TeamController(ITeamService teamService)
        {
            _teamService = teamService;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _teamService.GetRandomTeamsAsync();
            return View(values); 
        }
        public async Task<IActionResult> LongestTeam()
        {
            var values = await _teamService.GetLongestTeamsAsync();
            return View(values);
        }
        public async Task<IActionResult> AllTeam()
        {
            var values=await _teamService.GetResultTeamsAsync();
            return View(values);
        }


    }
}
