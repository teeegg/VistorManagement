using System;
using Microsoft.AspNetCore.Mvc;
using VistorManagement.Service;
using VistorManagement.ViewModels;

namespace VistorManagement.Controllers
{
    public class HostsController : Controller
    {
        private readonly StatisticsService _service;
        public HostsController(StatisticsService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            HostsViewModel hosts = _service.GetHostsViewModel();

            return View("Hosts", hosts);
        }

        public IActionResult FilterByBuidingId(string id)
        {
            HostsViewModel hosts = _service.FilterHostByBuildingId(id);
            return PartialView("Hosts", hosts);
        }

        public IActionResult FilterByCampusId(string id)
        {
            HostsViewModel hosts = _service.FilterHostByCampusId(id);
            return PartialView("Hosts", hosts);
        }
    }
}
