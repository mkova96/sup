using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sup.Models;
using Sup.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Sup.Controllers
{
    public class UnregHomeController : Controller
    {
        private readonly DatabaseContext _databaseContext;

        public UnregHomeController(DatabaseContext context)
        {
            _databaseContext = context;
        }

        public ViewResult Index()
        {
            ViewData["Empty"] = "true";
            ViewData["Users"] = _databaseContext.Users.Include(u => u.Company).ToList();
            ViewData["Companies"] = _databaseContext.Companies.Include(c => c.City).ToList();
            return View();
        } 
    }
}