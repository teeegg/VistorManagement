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
    public class DailyActivityController : Controller
    {
        private readonly CheckInOutService _service;

        public DailyActivityController(CheckInOutService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            DailyActivityViewModel activity =
                _service.GetDailyActivityViewModel();

            return View("DailyActivity", activity);
        }

        public IActionResult CheckIn(int id)
        {
            if (id > 0)
                _service.CheckIn(id);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult CheckOut(int id)
        {
            if (id > 0)
                _service.CheckOut(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
