using Microsoft.AspNetCore.Mvc;

namespace IdentityChat.ViewComponents
{
    public class _MessageSidebarComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}