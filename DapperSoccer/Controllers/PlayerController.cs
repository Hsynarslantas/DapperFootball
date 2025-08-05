using System.Threading.Tasks;
using DapperSoccer.Repositories.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace DapperSoccer.Controllers
{
    public class PlayerController : Controller
    {
        private readonly IPlayerService _playerService;

        public PlayerController(IPlayerService playerService)
        {
            _playerService = playerService;
        }
        public async Task<IActionResult> Top5PlayerPotentialList()
        {
            var values = await _playerService.GetTopPotentialPlayersAsync(5);
            return View(values);
        }
        public async Task<IActionResult> HighHeightPlayerList()
        {
            var values = await _playerService.GetHighHeightPlayersAsync();
            return View(values);
        }
        public async Task<IActionResult> FirstBirthdayPlayerList()
        {
            var values = await _playerService.FirstBirthdayPlayerDtoAsync();
            return View(values);
        }
        public async Task<IActionResult> WorstWeightPlayerList()
        {
            var values = await _playerService.GetWorstWeightPlayersAsync();
            return View(values);
        }
        public async Task<IActionResult> BestPotentialPlayer()
        {
            var values = await _playerService.GetBestPotentialPlayerAsync();
            return View(values);
        }
        [HttpGet]
        public async Task<IActionResult> GetResultPlayers()
        {
            var values = await _playerService.GetResultPlayersAsync();
            return View(values);
        }
        [HttpPost]
        public async Task<IActionResult> GetResultPlayers(string searchTerm)
        {
            var players = await _playerService.SearchPlayersAsync(searchTerm);
            ViewBag.SearchTerm = searchTerm ?? "";
            return View(players);
        }
    }
}
