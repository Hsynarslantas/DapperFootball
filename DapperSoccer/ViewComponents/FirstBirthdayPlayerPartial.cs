using DapperSoccer.Repositories.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Diagnostics;

namespace DapperSoccer.ViewComponents
{
    public class FirstBirthdayPlayerPartial:ViewComponent
    {
        private readonly IPlayerService _playerService;

        public FirstBirthdayPlayerPartial(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values=await _playerService.FirstBirthdayPlayerDtoAsync();
            return View(values);
        }
    }
}
