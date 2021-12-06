using System;
using System.Collections.Generic;
using VistorManagement.Models;

namespace VistorManagement.ViewModels
{
    public class VisitorStatisticsViewModel
    {
        public VisitorStatisticsViewModel()
        {
        }

        public int TotalHosts { get; set; }
        public int TotalVisitors { get; set; }
        public int TotalVisits { get; set; }
        public List<Campus> Campuses { get; set; } = new List<Campus>();
        public List<StaffMember> Hosts { get; set; } = new List<StaffMember>();
        public List<Building> Buildings { get; set; } = new List<Building>();
    }
}
