using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Sup.Models;
using Sup.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace Sup.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly DatabaseContext _databaseContext;

        public UserController(DatabaseContext context)
        {
            _databaseContext = context;
        }

        public ViewResult Index()
        {
            ViewData["Success"] = TempData["Success"];
            IEnumerable<User> users = _databaseContext.Users.Include(c => c.Company).ToList();
            return View(users);
        }

        [AllowAnonymous]
        public ViewResult Show(string id)
        {
            var user = _databaseContext.Users.Include(g => g.Company).First(g => g.Id == id);
            return View(user);
        }

        [HttpGet]
        public ViewResult Add()
        {
            ViewData["Companies"] = _databaseContext.Companies.ToList();
            return View(new UserViewModel());
        }

        [HttpPost]
        public IActionResult Create(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var company = _databaseContext.Companies.Find(model.CompanyId);
                _databaseContext.Users.Add(new User
                {
                    Name = model.Name,
                    Surname = model.Surname,
                    Phone = model.Phone,
                    Email = model.EMail,
                    Company = company
                });

                TempData["Success"] = true;
                _databaseContext.SaveChanges();
            }
            else
            {
                ViewData["Companies"] = _databaseContext.Companies.ToList();
                return View("Add", model);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public ViewResult Edit(string id)
        {
            var user = _databaseContext.Users.Include(g => g.Company).First(g => g.Id == id);
            ViewData["Success"] = TempData["Success"];
            ViewData["Companies"] = _databaseContext.Companies.ToList();
            var model = new EditUserViewModel
            {
                User = user,
                CompanyId = user.Company?.Id
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Update(string id, EditUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _databaseContext.Users.Include(g => g.Company).First(g => g.Id == id);
                user.Company = _databaseContext.Companies.FirstOrDefault(c => c.Id == model.CompanyId);
                user.Email = model.User.Email;
                user.Name = model.User.Name;
                user.Phone = model.User.Phone;
                user.Surname = model.User.Surname;
                TempData["Success"] = true;
                _databaseContext.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Delete(string id)
        {
            var user =  _databaseContext.Users.Find(id);
            _databaseContext.Database.ExecuteSqlCommand("DELETE FROM \"AspNetUsers\" WHERE \"AspNetUsers\".\"Id\" = {0}",id);
            _databaseContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}