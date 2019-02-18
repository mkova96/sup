using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sup.Models;
using Sup.Models.ViewModels;

namespace Sup.Controllers
{
    [Authorize]
    public class GroupController : Controller
    {
        private readonly DatabaseContext _databaseContext;

        public GroupController(DatabaseContext context)
        {
            _databaseContext = context;
        }

        public ViewResult Index()
        {
            ViewData["Success"] = TempData["Success"];
            IEnumerable<Group> groups = _databaseContext
                .Groups
                .Include(group => group.GroupUsers)
                .ThenInclude(groupUser => groupUser.User)
                .OrderByDescending(a => a.Published)
                .ToList();
            return View(groups);
        }

        [HttpGet]
        public ViewResult Add()
        {
            ViewData["Users"] = _databaseContext.Users.ToList();
            return View(new GroupViewModel());
        }

        [HttpPost]
        public IActionResult Create(GroupViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewData["Users"] = _databaseContext.Users.ToList();
                return View(nameof(Add), model);
            }
            var group = new Group {Name = model.Name, Published = DateTime.Now};
            _databaseContext.Groups.Add(group);
            var groupUsers = model.UserIds.Select(id => _databaseContext.Users.Find(id))
                .Select(user => new GroupUser {User = user, Group = group}).ToList();

            foreach (var gu in groupUsers)
            {
                var groupUserInDb = _databaseContext.GroupUsers.SingleOrDefault(s => s.User.Id == gu.User.Id &&
                                                                                     s.Group.Id == gu.Group.Id);
                if (groupUserInDb == null)
                {
                    _databaseContext.GroupUsers.Add(gu);
                }
            }

            TempData["Success"] = true;
            _databaseContext.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public ViewResult Edit(int id)
        {
            var group = _databaseContext.Groups
                .Include(g => g.GroupUsers)
                .ThenInclude(gu => gu.User)
                .First(g => g.Id == id);
            ViewData["Success"] = TempData["Success"];
            ViewData["Users"] = _databaseContext.Users.ToList();
            var model = new EditGroupViewModel
            {
                Group = group,
                UserIds = group.GroupUsers.ToList().Select(gu => gu.User.Id)
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Update(int id, EditGroupViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewData["Users"] = _databaseContext.Users.ToList();
                return View(nameof(Edit), model);
            }
            var group = _databaseContext.Groups
                .Include(g => g.GroupUsers)
                .ThenInclude(gu => gu.User)
                .First(g => g.Id == id);
            group.Name = model.Group.Name;
            TempData["Success"] = true;
            group.GroupUsers.Clear();
            var newUsers = _databaseContext.Users.Where(u => model.UserIds.Contains(u.Id)).ToList();
            foreach (var user in newUsers)
            {
                group.GroupUsers.Add(new GroupUser {User = user, Group = group});
            }
            _databaseContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _databaseContext.Groups.Remove(new Group {Id = id});
            _databaseContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}