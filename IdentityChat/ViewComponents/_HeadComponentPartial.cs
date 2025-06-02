using Microsoft.AspNetCore.Mvc;

namespace IdentityChat.ViewComponents
{
    public class _HeadComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
