using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sup.Helpers;
using Sup.Models;
using Sup.Models.ViewModels;

namespace Sup.Controllers
{
    [Authorize]
    public class SettingsController : Controller
    {
        private readonly DatabaseContext _databaseContext;
        private readonly UserManager<User> _userManager;

        private static List<UserSetting> _possibleSettings = new List<UserSetting>
        {
            new UserSetting
            {
                Label = "Učestalost primanja e-pošte",
                Name = "_EmailFrequency",
                Type = "Select",
                Options = new SelectList(new []{"Tjedno", "Mjesečno"})
            },
            new UserSetting
            {
            Label = "Starost korisnika",
            Name = "Age",
            Type = "Input",
        }
        };

        public SettingsController(DatabaseContext context, UserManager<User> userManager)
        {
            _databaseContext = context;
            _userManager = userManager;
        }

        public async Task<ViewResult> Index()
        {
            //var mailFrequency = _databaseContext.Settings.First(s => s.Name.Equals("mailFrequency"));
            ViewData["Success"] = TempData["Success"];
            var userSettings = new List<UserSetting>();
            var currentUser = await _userManager.GetUserAsync(User);
            var id = currentUser.Id;
            Console.WriteLine(id);
            foreach (var us in _possibleSettings)
            {
                var value = _databaseContext.Settings.Where(s => s.Name.Equals(us.Name))
                    .FirstOrDefault(s => s.UserId.Equals(id))?.Value;
                if (us.Options!=null)
                {
                    var option = us.Options.FirstOrDefault(o => o.Text == value);
                    if (option != null)
                    {
                        option.Selected = true;
                    }
                }
                userSettings.Add(new UserSetting
                {
                    Label = us.Label,
                    Name = us.Name,
                    Options = us.Options,
                    Type = us.Type,
                    Value = value
                });

            }
            ViewData["PossibleSettings"] = userSettings;
            return View();
        }

        public async Task<IActionResult> Update()
        
        {
            if (ModelState.IsValid)
            {
                var currentUser = await _userManager.GetUserAsync(User);
                var id = currentUser.Id;
                foreach (var p in _possibleSettings)
                {
                    var settings = _databaseContext.Settings.Where(s => s.Name.Equals(p.Name))
                        .FirstOrDefault(s => s.UserId.Equals(id));
                    if (settings == null)
                    {
                        _databaseContext.Settings.Add(
                            new Settings {Name = p.Name, Value = Request.Form[p.Name], UserId = id});
                    }
                    else
                    {
                        settings.Value = Request.Form[p.Name];
                    }
                }
                _databaseContext.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
        
    }
}