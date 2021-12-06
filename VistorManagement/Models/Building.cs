using System;
using System.Collections.Generic;

namespace VistorManagement.Models
{
    public class Building
    {
        public Building()
        {
        }

        public string BuildingId { get; set; }
        public string BuildingName { get; set; }
        public string BuildingDesc { get; set; }
        public string CampusId { get; set; }

        public Campus Campus { get; set; }
        public ICollection<Visit> Visits { get; set; }
    }
}
