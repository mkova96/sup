using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sup.Models;
using Sup.Models.ViewModels;

namespace Sup.Controllers
{
    [Authorize]
    public class MessageController : Controller
    {
        private readonly DatabaseContext _databaseContext;
        private readonly UserManager<User> _userManager;


        public MessageController(DatabaseContext context, UserManager<User> userManager)
        {
            _databaseContext = context;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            var id = user.Id;
            IEnumerable<Message> messages = _databaseContext.Messages
                .Include(message => message.Receiver)
                .Include(message => message.Sender).FromSql("SELECT * FROM \"Messages\"" +
                                                            " WHERE \"Messages\".\"Date\" = (SELECT MAX(\"m\".\"Date\") FROM \"Messages\" AS \"m\"" +
                                                            " WHERE (\"m\".\"SenderId\" = \"Messages\".\"SenderId\" AND \"m\".\"ReceiverId\" = \"Messages\".\"ReceiverId\"" +
                                                            " AND (\"Messages\".\"SenderId\" = {0} OR \"Messages\".\"ReceiverId\" = {1}))" +
                                                            " OR (\"m\".\"SenderId\" = \"Messages\".\"ReceiverId\" AND \"m\".\"ReceiverId\" = \"Messages\".\"SenderId\"" +
                                                            " AND (\"Messages\".\"SenderId\" = {0} OR \"Messages\".\"ReceiverId\" = {1})))",
                    id, id)
                .ToList();
            return View(messages);
        }

        [HttpGet]
        public ViewResult Add()
        {
            ViewData["Users"] = _databaseContext.Users.ToList();
            return View(new MessageViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(MessageViewModel model)
        {
            if (ModelState.IsValid)
            {
                var sender = await _userManager.GetUserAsync(User);
                var receiver = _databaseContext.Users.Find(model.ReceiverId);
                _databaseContext.Messages.Add(new Message
                {
                    Content = model.Content,
                    Date = DateTime.Now,
                    Sender = sender,
                    Receiver = receiver
                });
                TempData["Success"] = true;
                _databaseContext.SaveChanges();
            }
            else
            {
                ViewData["Users"] = _databaseContext.Users.ToList();
                return View("Add", model);
            }

            return RedirectToAction(nameof(Index));
        }

        /*
         * Razgovor s `senderId` osobom. Dohvatimo poruke s njime. I njemu saljemo odgovor (`receiverId`).
         * 
         */
        public async Task<IActionResult> Show(int id)
        {
            var message = _databaseContext.Messages.Include(m => m.Sender).Include(m => m.Receiver).Where(m => m.Id == id).First();
            var sender = message.Sender;
            var receiver = message.Receiver;
            //var talkingToUser = _databaseContext.Users.Find(id);
            var user = await _userManager.GetUserAsync(User);
            var messages = _databaseContext.Messages
                .Include(m => m.Sender)
                .Include(m => m.Receiver)
                .Where(m => (m.Sender.Id == sender.Id && m.Receiver.Id == receiver.Id) ||
                            m.Sender.Id == receiver.Id && m.Receiver.Id == sender.Id)
                .ToList();
            if(receiver.Id == user.Id){
                receiver = sender;
            }
            return View(new MessageShowViewModel {Messages = messages,CurrentMessageId = id, Receiver = receiver});
        }

        [HttpPost]
        public async Task<IActionResult> CreateFromShow(MessageShowViewModel model, string id, int MessageId)
        {
            if (ModelState.IsValid)
            {
                var sender = await _userManager.GetUserAsync(User);
                var receiver = _databaseContext.Users.Find(id);
                var date = DateTime.Now;
                _databaseContext.Messages.Add(new Message
                {
                    Content = model.Content,
                    Date = date,
                    Sender = sender,
                    Receiver = receiver
                });
                TempData["Success"] = true;
                _databaseContext.SaveChanges();
                var message = _databaseContext.Messages.Include(m => m.Sender).Include(m => m.Receiver).Where(m => m.Content == model.Content && m.Sender == sender && m.Receiver == receiver && m.Date == date).First();
                return RedirectToAction(nameof(Show), new { id = message.Id});
            }

            return RedirectToAction(nameof(Show), new {id = MessageId});
        }


        [HttpPost]
        public IActionResult Delete(int id)
        {
            _databaseContext.Messages.Remove(new Message {Id = id});
            _databaseContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}