using Getha_Project.WebSite.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Getha_Project.WebSite.Controllers
{
    public class GraficoController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public GraficoController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

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