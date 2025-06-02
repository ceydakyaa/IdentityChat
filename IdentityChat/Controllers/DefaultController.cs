using IdentityChat.Context;
using IdentityChat.Entities;
using IdentityChat.Context;
using IdentityChat.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentityChat.Controllers
{
    public class DefaultController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly MailContext _context;

        public DefaultController(UserManager<AppUser> userManager, MailContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.v1 = _context.Messages.Where(x => x.ReceiverEmail == user.Email).Count();//gelen mesaj sayısı
            ViewBag.v2 = _context.Messages.Where(x => x.ReceiverEmail == user.Email && x.IsRead == false).Count();//okunmamış mesaj sayısı
            ViewBag.v3 = _context.Messages.Where(x => x.ReceiverEmail == user.Email && x.IsRead == true).Count();//okunmuş mesaj sayısı
            ViewBag.v4 = _context.Messages.Where(x => x.SenderEmail == user.Email).Count();//gönderilen mesaj sayısı

            var lastMessage = _context.Messages.Where(m => m.ReceiverEmail == user.Email).OrderByDescending(m => m.SendDate).FirstOrDefault();//gelen son mesaj
            ViewBag.LastMessage = lastMessage;

            var lastSendMessage = _context.Messages.Where(m => m.SenderEmail == user.Email).OrderByDescending(m => m.SendDate).FirstOrDefault();//gönderilen son mesaj
            ViewBag.LastSendMessage = lastSendMessage;

            return View();
        }
    }
}