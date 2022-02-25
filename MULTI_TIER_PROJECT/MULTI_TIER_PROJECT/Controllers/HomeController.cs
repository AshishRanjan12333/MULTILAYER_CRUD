using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MULTI_TIER_PROJECT.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer;

namespace MULTI_TIER_PROJECT.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private BLEmployeeBusiness business;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            business = new BLEmployeeBusiness();

        }

        public IActionResult Index()
        {
            var emp = business.GetEmployees();
            return View(emp);
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
