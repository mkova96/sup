using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Sup.Models;
using Sup.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Sup.Controllers
{
    public class SearchController : Controller
    {
        private readonly DatabaseContext _databaseContext;
        private readonly IActionDescriptorCollectionProvider _actionDescriptorCollectionProvider;


        public SearchController(DatabaseContext context,
            IActionDescriptorCollectionProvider actionDescriptorCollectionProvider)
        {
            _databaseContext = context;
            _actionDescriptorCollectionProvider = actionDescriptorCollectionProvider;
        }


        public ViewResult SearchAction(string searchString)
        {
            if (string.IsNullOrEmpty(searchString)) return View();
            var searchLower = searchString.ToLower().Split(" ");
            IEnumerable<Company> companies =
                _databaseContext.Companies.Where(c => searchForArray(c.Name.ToLower(), searchLower)).ToList();
            IEnumerable<User> users = _databaseContext.Users.Where(u =>
                searchForArray(u.UserName.ToLower(), searchLower) || searchForArray(u.Name.ToLower(), searchLower) ||
                searchForArray(u.Surname.ToLower(), searchLower)).ToList();
            var searchResults = new SearchActionViewModel
            {
                Users = users,
                Companies = companies,
                Savior = searchString == "isus" || searchString == "tonson",
                Patriot = searchString == "bojna" || searchString == "tonson",
                Boss = searchString == "mićan",
            };
            return View(searchResults);
        }

        private bool searchForArray(string value, string[] searchStrings)
        {
            foreach (var s in searchStrings)
            {
                if (value.Contains(s)) return true;
            }
            return false;
        }
    }
}