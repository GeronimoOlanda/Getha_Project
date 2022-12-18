using Getha_Project.WebSite.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Configuration;

namespace Getha_Project.WebSite.Controllers
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
            teste();
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

        
        public void teste()
        {

            var baseAddress = "https://localhost:7232/api/UserLogin?id=1";

            using (var http = new HttpClient())
            {
                http.BaseAddress = new Uri(baseAddress);
                http.DefaultRequestHeaders.Accept.Clear();
                http.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                http.Timeout = TimeSpan.FromMinutes(30);

                HttpResponseMessage response = http.GetAsync($"{baseAddress}").Result;
                if (response.IsSuccessStatusCode)
                {
                    string stringContent = response.Content.ReadAsStringAsync().Result;

                }
            }
        }
    }
}