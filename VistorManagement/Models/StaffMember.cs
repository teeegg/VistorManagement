using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VistorManagement.Models
{
    public class StaffMember
    {
        public StaffMember()
        {
        }

        [Key]
        public string SNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public decimal Extension { get; set; }

        public ICollection<Visit> Visits { get; set; }
    }
}
