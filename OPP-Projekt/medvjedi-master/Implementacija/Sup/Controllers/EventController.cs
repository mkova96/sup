using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Sup.Models;
using Sup.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;



namespace Sup.Controllers
{
    [Authorize]
    public class EventController : Controller
    {
        private readonly DatabaseContext _databaseContext;
        private readonly UserManager<User> _userManager;

        public EventController(DatabaseContext context, UserManager<User> userManager)
        {
            _databaseContext = context;
            _userManager = userManager;
        }

        public ViewResult Index()
        {
            ViewData["Success"] = TempData["Success"];
            IEnumerable<Event> events = _databaseContext.Events.Include(e => e.EventUser).ThenInclude(eu => eu.Users).OrderByDescending(a => a.Published).ToList(); 
            return View(events);  
        }

        [HttpGet]
        public ViewResult Add()
        {
            ViewData["Users"] = _databaseContext.Users.ToList();
            return View(new EventViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create (EventViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                var Event = new Event {Title = model.Title, Description = model.Description, Date = model.Date, Time = model.Time, User = user};
                _databaseContext.Events.Add(Event);
                
                var eventUsers = model.UserIds.Select(id => _databaseContext.Users.Find(id))
                .Select(u => new EventUser {Users = u, Events = Event }).ToList();
        
                foreach (var eu in eventUsers)
                {
                    var eventUserInDb = _databaseContext.EventUsers.SingleOrDefault(s => s.Users.Id == eu.Users.Id &&
                                                                                     s.Events.Id == eu.Events.Id);
                    if (eventUserInDb == null)
                    {
                        _databaseContext.EventUsers.Add(eu);
                    }
                }

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

        [HttpGet]
        public ViewResult Edit(int id)
        {
            var Event = _databaseContext.Events
                .Include(g => g.EventUser)
                .ThenInclude(eu => eu.Users)
                .First(g => g.Id == id);
            var userIds = Event.EventUser.Select(eu => eu.Users.Id);
            ViewData["Users"] = _databaseContext.Users.ToList();
            return View(new EditEventViewModel {Event = Event, UserIds = userIds});
        }

        [HttpPost]
        public IActionResult Update(int id, EditEventViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewData["Users"] = _databaseContext.Users.ToList();
                return View(nameof(Edit), model);
            }
            var Event = _databaseContext.Events
                .Include(e => e.EventUser)
                .ThenInclude(eu => eu.Users)
                .First(g => g.Id == id);
            
            Event.Title = model.Event.Title;
            Event.Description = model.Event.Description;
            Event.Date = model.Event.Date;
            Event.Time = model.Event.Time;
            
            TempData["Success"] = true;
            Event.EventUser.Clear();
            var newUsers = _databaseContext.Users.Where(u => model.UserIds.Contains(u.Id)).ToList();
            foreach (var user in newUsers)
            {
                Event.EventUser.Add(new EventUser {Users = user, Events = Event});
            }
            _databaseContext.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Show(int id) => View(_databaseContext.Events.Find(id));
        
        [HttpPost]
        public IActionResult Delete(int id)
        {
            _databaseContext.Events.Remove(new Event {Id = id});
            _databaseContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}