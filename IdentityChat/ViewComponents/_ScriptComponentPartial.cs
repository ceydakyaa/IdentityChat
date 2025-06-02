using Microsoft.AspNetCore.Mvc;

namespace IdentityChat.ViewComponents
{
    public class _ScriptComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}