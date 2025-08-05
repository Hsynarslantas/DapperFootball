using DapperSoccer.Repositories.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace DapperSoccer.ViewComponents
{
    public class Top5PotentialPlayerPartial:ViewComponent
    {
        private readonly IPlayerService _playerService;

        public Top5PotentialPlayerPartial(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _playerService.GetTopPotentialPlayersAsync(5);
            return View(values);
        }
    }
}
