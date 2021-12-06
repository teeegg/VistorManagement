using System;
using System.ComponentModel.DataAnnotations;

namespace VistorManagement.Models
{
    public class Visitor
    {
        public int VisitorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CompanyName { get; set; }
        public string EmailAddress { get; set; }

        //[Phone]
        public decimal MobileNumber { get; set; }
    }
}
