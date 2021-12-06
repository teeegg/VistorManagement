using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VistorManagement.Data;
using VistorManagement.Models;
using VistorManagement.ViewModels;

namespace VistorManagement.Service
{
    public class CheckInOutService
    {
        private readonly VisitorManagementContext _context;

        public CheckInOutService(VisitorManagementContext context)
        {
            _context = context;
        }

        public DailyActivityViewModel GetDailyActivityViewModel()
        {
            DailyActivityViewModel dailyActivity = new DailyActivityViewModel();

            var visits = _context.Visits
                //.Where(v => v.VisitDate > DateTime.Today && v.VisitDate < DateTime.Today.AddDays(1))
                .Include(v => v.Building)
                .Include(v => v.StaffMember)
                .Include(v => v.Visitor)
                .AsNoTracking()
                .OrderBy(v => v.VisitDate)
                .ToList();

            foreach (Visit visit in visits)
            {
                VisitViewModel visitView = new VisitViewModel();
                visitView.PopulateFromDataModel(visit);

                if (!visitView.Ends.HasValue && !visitView.CheckedIn)
                    dailyActivity.CheckIns.Add(visitView);
                else
                    dailyActivity.CheckOuts.Add(visitView);
            }

            return dailyActivity;
        }

        public void CheckIn(int visitId)
        {
            if (visitId == 0)
                return;
            Visit visit = _context.Visits.Single(v => v.VisitId == visitId);
            visit.CheckInDateTime = DateTime.Now;
            _context.Update(visit);
            _context.SaveChanges();
        }

        public void CheckOut(int visitId)
        {
            if (visitId == 0)
                return;
            Visit visit = _context.Visits.Single(v => v.VisitId == visitId);
            visit.CheckOutDateTime = DateTime.Now;
            _context.Update(visit);
            _context.SaveChanges();
        }
    }
}
