using System;
using VistorManagement.Models;

namespace VistorManagement.ViewModels
{
    public class VisitViewModel
    {
        public VisitViewModel()
        {
        }
        public int VisitId { get; set; }
        public string Name { get; set; }
        public string Company { get; set; }
        public string Host { get; set; }
        public DateTime VisitDate { get; set; }
        public DateTime Starts { get; set; }
        public DateTime? Ends { get; set; }
        public string BuildingName { get; set; }
        public bool CheckedIn
        {
            get
            {
                return !Ends.HasValue && VisitDate != Starts; 
            }
        }

        public bool CheckedOut
        {
            get
            {
                return Ends.HasValue;
            }
        }

        public void PopulateFromDataModel(Visit data)
        {
            VisitId = data.VisitId;
            Name = data.Visitor.FirstName + " " + data.Visitor.LastName;
            Company = data.Visitor.CompanyName;
            Host = data.StaffMember.FirstName +" "+ data.StaffMember.LastName;
            VisitDate = data.VisitDate;
            Starts = data.CheckInDateTime;
            Ends = data.CheckOutDateTime;
            BuildingName = data.Building.BuildingName;
        }
    }
}
 