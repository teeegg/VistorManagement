using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VistorManagement.Models
{
    public class Visit
    {
        public Visit()
        {
        }

        public int VisitId { get; set; } = 0;
        [Display(Name = "Visitor")]
        public int VisitorId { get; set; }

        [ForeignKey("StaffMember")]
        [Display(Name = "Host")]
        public string HostSNumber { get; set; }

        [Display(Name = "Building Name")]
        public string BuildingId { get; set; }
        public DateTime VisitDate { get; set; }
        public DateTime CheckInDateTime { get; set; }
        public DateTime? CheckOutDateTime { get; set; }

        public Visitor Visitor { get; set; }
        public StaffMember StaffMember { get; set; }
        public Building Building { get; set; }
    }
}
