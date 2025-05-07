using System.Diagnostics;
using EstacionamientoMVC.C.Models;
using Microsoft.AspNetCore.Mvc;

namespace EstacionamientoMVC.C.Controllers
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
    }
}
