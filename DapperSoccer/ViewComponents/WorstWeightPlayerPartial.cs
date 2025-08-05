using DapperSoccer.Repositories.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace DapperSoccer.ViewComponents
{
    public class WorstWeightPlayerPartial:ViewComponent
    {
        private readonly IPlayerService _playerService;

        public WorstWeightPlayerPartial(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _playerService.GetWorstWeightPlayersAsync();
            return View(values);
        }
    }
}
