using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Sup.Models;
using Sup.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using Microsoft.AspNetCore.Authorization;

namespace Sup.Controllers
{
    [Authorize]
    public class CompanyController : Controller
    {
        private readonly DatabaseContext _databaseContext;
        private readonly IActionDescriptorCollectionProvider _actionDescriptorCollectionProvider;

        public CompanyController(DatabaseContext context,
            IActionDescriptorCollectionProvider actionDescriptorCollectionProvider)
        {
            _databaseContext = context;
            _actionDescriptorCollectionProvider = actionDescriptorCollectionProvider;
        }

        public ViewResult Index()
        {
            ViewData["Success"] = TempData["Success"];
            IEnumerable<Company> companies = _databaseContext.Companies.Include(c => c.City)
                .ThenInclude(x => x.Country).ToList();
            return View(companies);
        }

        [AllowAnonymous]
        public ViewResult Show(int id)
        {
            Company company = _databaseContext.Companies
                .Include(u => u.Users)
                .Include(m => m.City)
                .ThenInclude(m => m.Country).First(m => m.Id == id);
            return View(company);
        }

        [HttpGet]
        public ViewResult Add()
        {
            ViewData["Cities"] = _databaseContext.Cities.ToList();
            ViewData["Users"] = _databaseContext.Users.ToList();

            return View(new CompanyViewModel());
        }


        [HttpPost]
        public IActionResult Create(CompanyViewModel model)
        {
            Console.WriteLine("ušo sam u create ");
            ViewData["Cities"] = _databaseContext.Cities.ToList();
            ViewData["Users"] = _databaseContext.Users.ToList();

            if (ModelState.IsValid)
            {
                Console.WriteLine("Pokušavam stvorit kompaniju " +  model.CityId);
                var city = _databaseContext.Cities.Find(model.CityId);
                var users = model.UserIds.Select(id => _databaseContext.Users.Find(id)).ToList();

                _databaseContext.Companies.Add(new Company
                {
                    Name = model.Name,
                    Address = model.Adress,
                    Logo = model.Logo,
                    Description = model.Description,
                    Website = model.Website,
                    City = city,
                    Users = users
                });

                TempData["Success"] = true;
                _databaseContext.SaveChanges();
            }
            else
            {
                Console.WriteLine("Evo meee");
                return View("Add", model);
            }

            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public ViewResult Edit(int id)
        {
            var company = _databaseContext.Companies.Include(u => u.Users).Include(g => g.City).First(g => g.Id == id);
            ViewData["Success"] = TempData["Success"];
            ViewData["Cities"] = _databaseContext.Cities.ToList();
            ViewData["Users"] = _databaseContext.Users.ToList();

            var model = new EditCompanyViewModel
            {
                Company = company,
                CityId = company.City.Id,
                UserIds = company.Users.ToList().Select(u => u.Id)
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Update(int id, EditCompanyViewModel model)
        {
            if (ModelState.IsValid)
            {
                var company = _databaseContext.Companies.Include(g => g.Users).First(g => g.Id == id);
                company.City = _databaseContext.Cities.ToList().First(c => c.Id == model.CityId);
                company.Name = model.Company.Name;
                company.Address = model.Company.Address;
                company.Description = model.Company.Description;
                company.Logo = model.Company.Logo;
                company.Website = model.Company.Website;

                TempData["Success"] = true;
                company.Users.Clear();
                var newUsers = _databaseContext.Users.Where(u => model.UserIds.Contains(u.Id)).ToList();
                foreach (var user in newUsers)
                {
                    company.Users.Add(user);
                }


                _databaseContext.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _databaseContext.Companies.Remove(new Company {Id = id});
            _databaseContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}