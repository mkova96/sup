using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Sup.Models;
using Sup.Models.ViewModels;
using Sup.Services;

namespace Sup.Controllers
{   
    [Authorize]
    public class AnnouncementController : Controller
    {
        private readonly DatabaseContext _databaseContext;
        private readonly UserManager<User> _userManager;
        private readonly IEmailSender _emailSender;

        public AnnouncementController(DatabaseContext context, UserManager<User> userManager, IEmailSender emailSender)
        {
            _databaseContext = context;
            _userManager = userManager;
            _emailSender = emailSender;
        }

        public ViewResult Index()
        {
            ViewData["Success"] = TempData["Success"];
            IEnumerable<Announcement> announcements = _databaseContext.Announcements.OrderByDescending(a => a.Published).ToList();
            return View(announcements);
        }

        [HttpGet]
        public ViewResult Add()
        {
            ViewData["Users"] = _databaseContext.Users.ToList();
            ViewData["Groups"] = _databaseContext.Groups.ToList();
            return View(new AnnouncementViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(AnnouncementViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                var sendToUsers = new List<string>();
                if (model.RecieverType == "Group")
                {
                    var group = _databaseContext.Groups.Include(g => g.GroupUsers).ThenInclude(gu => gu.User)
                        .First(g => g.Id == model.GroupId);
                    sendToUsers = group.GroupUsers.Select(gu => gu.User.Id).ToList();
                }
                else
                {
                    sendToUsers.Add(model.UserId);
                }
                var announcement = new Announcement
                {
                    Title = model.Title,
                    Message = model.Message,
                    Published = DateTime.Now,
                    RecieverType = model.RecieverType,
                    User = user
                };
                var users = _databaseContext.Users.Where(u => sendToUsers.Contains(u.Id)).ToList();
                announcement.AnnouncementUsers = new List<AnnouncementUser>();
                foreach (var u in users)
                {
                    announcement.AnnouncementUsers.Add(new AnnouncementUser {Announcement = announcement, User = u});
                    await _emailSender.SendEmailAsync(u.Email, "Nova obavijest",
                        "Dobili ste novu obavijest");
                }
                _databaseContext.Announcements.Add(announcement);
                TempData["Success"] = true;
                _databaseContext.SaveChanges();
            }
            else
            {
                ViewData["Users"] = _databaseContext.Users.ToList();
                ViewData["Groups"] = _databaseContext.Groups.ToList();
                return View("Add", model);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public ViewResult Edit(int id) => View(_databaseContext.Announcements.Find(id));

        [HttpPost]
        public IActionResult Update(int id, Announcement model)
        {
            if (ModelState.IsValid)
            {
                _databaseContext.Announcements.Update(model);
                TempData["Success"] = true;
                _databaseContext.SaveChanges();
            }
            else
            {
                return View("Edit", model);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}