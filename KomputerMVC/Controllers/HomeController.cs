using KomputerMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace KomputerMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            if (Response.HttpContext.Items[LastVisitCookie.CookieName] is DateTime lastVisit)
            {
                ViewData["Visit"] = lastVisit.ToString("yyyy-MM-dd");
            }
            else
            {
                ViewData["Visit"] = null;
            }

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
