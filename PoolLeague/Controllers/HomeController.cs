using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PoolLeague.Models;

namespace PoolLeague.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddNewPlayer()
        {
            return View();
        }

        public IActionResult UpdateGame()
        {
            return View();
        }

        public IActionResult ViewWholeLeague()
        {
            return View();
        }

        public IActionResult ViewTopTen()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }    

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
