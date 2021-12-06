using System;
using System.Collections.Generic;

namespace VistorManagement.Models
{
    public class Campus
    {
        public Campus()
        {
        }

        public string CampusId { get; set; }
        public string CampusName { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public decimal ZoomLevel { get; set; }
        public string AboutUrl { get; set; }
        public ICollection<Building> Buildings { get; set; }
    }
}
