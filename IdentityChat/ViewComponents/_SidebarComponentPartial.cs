using Microsoft.AspNetCore.Mvc;

namespace IdentityChat.ViewComponents
{
    public class _SidebarComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}