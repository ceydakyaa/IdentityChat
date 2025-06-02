using Microsoft.AspNetCore.Mvc;

namespace IdentityChat.ViewComponents
{
    public class _FooterComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}