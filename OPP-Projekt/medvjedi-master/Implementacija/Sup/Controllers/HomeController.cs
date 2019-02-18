using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Sup.Models;
using Sup.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Sup.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IActionDescriptorCollectionProvider _actionDescriptorCollectionProvider;
        private readonly DatabaseContext _databaseContext;
        private readonly UserManager<User> _userManager;


        public HomeController(IActionDescriptorCollectionProvider actionDescriptorCollectionProvider,
            DatabaseContext context, UserManager<User> userManager)
        {
            _actionDescriptorCollectionProvider = actionDescriptorCollectionProvider;
            _databaseContext = context;
            _userManager = userManager;
        }

        public async Task<ViewResult> Index()
        {
            ViewData["Success"] = TempData["Success"];
            var user = await _userManager.GetUserAsync(User);
            IEnumerable<Announcement> announcements =
                _databaseContext.Announcements
                     .OrderByDescending(a => a.Published)
                    .Include(a => a.User)
                    .Include(a => a.AnnouncementUsers)
                    .ThenInclude(au => au.User)
                    .Where(a => a.AnnouncementUsers.Select(au => au.User.Id).Contains(user.Id)).ToList();
            return View(announcements);
        }

        public IActionResult GetAllRoutes()
        {
            var routes = _actionDescriptorCollectionProvider.ActionDescriptors.Items
                .Select(ad => new
                {
                    Action = ad.RouteValues["action"],
                    Controller = ad.RouteValues["controller"]
                }).Distinct().ToList();
            return Ok(routes);
        }

        public ViewResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}