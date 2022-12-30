using Getha_Project.WebSite.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Configuration;
using Getha_Project.Domain.Services.Impl.DTO;
using Getha_Project.Domain.Services;
using Getha_Project.WebSite.Models.Home;

namespace Getha_Project.WebSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHomeService _homeService;
        public HomeController(ILogger<HomeController> logger, IHomeService homeService)
        {
            _logger = logger;
            _homeService = homeService;
        }

        public IActionResult Index()
        {
            //int idUsuario = 5;

            //var resposta = _homeService.consultaUsuarioPorId(idUsuario);
            return View("Index");
        }

    }
}