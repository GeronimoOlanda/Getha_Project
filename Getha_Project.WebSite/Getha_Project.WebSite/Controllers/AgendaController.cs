﻿using Getha_Project.WebSite.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Configuration;
using Getha_Project.Domain.Services.Impl.DTO;
using Getha_Project.Domain.Services;
using Getha_Project.WebSite.Models.Home;

namespace Getha_Project.WebSite.Controllers
{
    public class AgendaController : Controller
    {
        private readonly ILogger<AgendaController> _logger;
        public AgendaController(ILogger<AgendaController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View("Index");
        }
    }
}