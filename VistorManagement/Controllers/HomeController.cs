using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using VistorManagement.Models;
using VistorManagement.Service;
using VistorManagement.ViewModels;

namespace VistorManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly StatisticsService _service;

        public HomeController(ILogger<HomeController> logger, StatisticsService service)
        {
            _logger = logger;
            _service = service;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Invitations()
        {
            return View();
        }
        public IActionResult DailyActivity()
        {
            return View();
        }
        public IActionResult Hosts()
        {
            return View();
        }
        public IActionResult VisitorStatistics()
        {
            VisitorStatisticsViewModel visitorStatistics
                = _service.GetVisitorStatisticsViewModel();
            return View(visitorStatistics);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
