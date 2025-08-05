using DapperSoccer.Repositories.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace DapperSoccer.ViewComponents
{
    public class HighHeightPlayerPartial:ViewComponent
    {
        private readonly IPlayerService _playerService;

        public HighHeightPlayerPartial(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values=await _playerService.GetHighHeightPlayersAsync();
            return View(values);
        }
    }
}
