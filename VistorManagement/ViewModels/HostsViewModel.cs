using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using VistorManagement.Models;

namespace VistorManagement.ViewModels
{
    public class HostsViewModel
    {
        public HostsViewModel()
        {
        }

        public string CampusId { get; set; }
        public string BuildingId { get; set; }

        public List<StaffMember> StaffMembers = new List<StaffMember>();

        public List<SelectListItem> Campuses { get; set; } =
            new List<SelectListItem>
            {
                new SelectListItem("Campus", "")
            };

        public List<SelectListItem> Buildings { get; set; } =
            new List<SelectListItem>
            {
                new SelectListItem("Building", "")
            };
    }
}
