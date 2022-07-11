using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BugTrackerDef.Models;
using BugTrackerDef.Data.Repository;
using Microsoft.AspNetCore.Identity;
using BugTrackerDef.Data.FileManager;
using BugTrackerDef.Domain;
using System.Collections.Generic;
using System.Linq;
using BugTrackerDef.Models.ViewModels;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using System;

namespace BugTrackerDef.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
