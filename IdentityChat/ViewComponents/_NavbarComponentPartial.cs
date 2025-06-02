using Microsoft.AspNetCore.Mvc;

namespace IdentityChat.ViewComponents
{
    public class _NavbarComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}