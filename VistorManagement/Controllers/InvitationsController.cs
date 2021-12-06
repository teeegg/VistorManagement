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
    public class InvitationsController : Controller
    {
        private readonly InvitationService _service; 

        public InvitationsController(InvitationService service)
        {
            _service = service;
            ViewData["active"] = "invitations";
        }

        public IActionResult Index()
        {
            InvitationsViewModel invitations =
                _service.GetInvitations();

            return View("Invitations", invitations);
        }

        [HttpGet]
        public IActionResult Create()
        {
            EditVisitViewModel editVisitView =
                _service.GetEditVisitViewModel();

            return View(editVisitView);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(EditVisitViewModel editVisitView)
        {
            
            if (ModelState.IsValid)
            {
                if(_service.CreateInvitation(editVisitView.Visit))
                    return RedirectToAction(nameof(Index));
            }

            editVisitView =
                _service.GetEditVisitViewModel();
            return View(editVisitView);
        }
    }
}
