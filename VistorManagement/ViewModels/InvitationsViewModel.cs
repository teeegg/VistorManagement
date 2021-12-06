using System;
using System.Collections.Generic;
using System.Linq;

namespace VistorManagement.ViewModels
{
    public class InvitationsViewModel
    {
        public InvitationsViewModel()
        {
        }

        public int Today
        {
            get
            {
                return Visits.Count(v => v.VisitDate > DateTime.Today &&
                    v.VisitDate < DateTime.Today.AddDays(1));
            }
        }
        public int Tomorrow
        {
            get
            {
                return Visits.Count(v => v.VisitDate > DateTime.Today.AddDays(1) &&
                    v.VisitDate < DateTime.Today.AddDays(2));
            }
        }
        public int Next7Days
        {
            get
            {
                return Visits.Count(v => v.VisitDate > DateTime.Today &&
                    v.VisitDate < DateTime.Today.AddDays(7));
            }
        }
        public int Expired
        {
            get
            {
                return Visits.Count(v => v.VisitDate < DateTime.Now);
            }
        }
        public int TotalVisits
        {
            get
            {
                return Visits.Count;
            }
        }

        public List<VisitViewModel> Visits { get; set; } =
            new List<VisitViewModel>();

        
    }
}
