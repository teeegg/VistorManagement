using System;
using System.Collections.Generic;

namespace VistorManagement.ViewModels
{
    public class DailyActivityViewModel
    {
        public DailyActivityViewModel()
        {
        }

        public List<VisitViewModel> CheckIns { get; set; } =
            new List<VisitViewModel>();
        public List<VisitViewModel> CheckOuts { get; set; } =
            new List<VisitViewModel>();
    }
}
