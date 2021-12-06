using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using VistorManagement.Models;

namespace VistorManagement.ViewModels
{
    public class EditVisitViewModel
    {
        public EditVisitViewModel()
        {
        }

        public Visit Visit { get; set; }


        public List<SelectListItem> Visitors { get; set; } =
            new List<SelectListItem>
            {
                new SelectListItem("Select a visitor", "")
            };

        public List<SelectListItem> StaffMembers { get; set; } =
            new List<SelectListItem>
            {
                new SelectListItem("Select a host", "")
            };

        public List<SelectListItem> Buildings { get; set; } =
            new List<SelectListItem>
            {
                new SelectListItem("Select a building", "")
            };

    }
}
