using IdentityChat.Context;
using IdentityChat.Entities;
using IdentityChat.Context;
using IdentityChat.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IdentityChat.Controllers
{
    public class MessageController : Controller
    {
        private readonly MailContext _context;
        private readonly UserManager<AppUser> _userManager;

        public MessageController(MailContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Profile()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.v1 = values.Name + "" + values.Surname;
            ViewBag.v2 = values.Email;
            return View();
        }
        public async Task<IActionResult> Inbox(string p)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            var messageList = _context.Messages.Where(x => x.ReceiverEmail == values.Email).ToList();
            ViewBag.countInboxMessages = messageList.Where(x => x.IsRead == false).Count();

            if (!string.IsNullOrWhiteSpace(p))
            {
                messageList = messageList.Where(x => x.Subject.Contains(p) || x.MessageDetail.Contains(p)).ToList();
            }

            return View(messageList);
        }
        public async Task<IActionResult> Sendbox(string p)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            string email = values.Email;
            var sendMessageList = _context.Messages.Where(x => x.SenderEmail == email).ToList();
            ViewBag.countSendboxMessages = sendMessageList.Count();

            if (!string.IsNullOrWhiteSpace(p))
            {
                sendMessageList = sendMessageList.Where(x => x.Subject.Contains(p) || x.MessageDetail.Contains(p)).ToList();
            }

            return View(sendMessageList);
        }
        public async Task<IActionResult> MessageDetail(int id)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            var value = _context.Messages.FirstOrDefault(x => x.MessageId == id);
            return View(value);
        }
        public IActionResult CreateMessage()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateMessage(Message message)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            string x = values.Email;

            message.SenderEmail = x;
            message.SendDate = DateTime.Now;
            message.IsRead = false;
            _context.Messages.Add(message);
            _context.SaveChanges();
            TempData["Success"] = "Mesajınız Başarıyla İletildi";
            return RedirectToAction("Sendbox");
        }
        public async Task<IActionResult> ChangeIsReadToTrue(int id)
        {
            var message = await _context.Messages.FindAsync(id);
            if (message != null)
            {
                message.IsRead = true;
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Inbox");
        }

        public async Task<IActionResult> ChangeIsReadToFalse(int id)
        {
            var message = await _context.Messages.FindAsync(id);
            if (message != null)
            {
                message.IsRead = false;
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Inbox");
        }
    }
}