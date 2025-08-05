using DapperSoccer.Repositories.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace DapperSoccer.ViewComponents
{
    public class BestPotentialPlayerPartial:ViewComponent
    {
        private readonly IPlayerService _playerService;

        public BestPotentialPlayerPartial(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var value=await _playerService.GetBestPotentialPlayerAsync();
            return View(value);
        }
    }
}
