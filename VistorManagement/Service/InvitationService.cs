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
    public class InvitationService
    {
        private readonly VisitorManagementContext _context;

        public InvitationService(VisitorManagementContext context)
        {
            _context = context;
        }

        public InvitationsViewModel GetInvitations()
        {
            InvitationsViewModel invitations = new InvitationsViewModel();
            var visits = _context.Visits
                .Include(v => v.Building)
                .Include(v => v.StaffMember)
                .Include(v => v.Visitor)
                .AsNoTracking()
                .OrderBy(v => v.VisitDate)
                .ToList();

            foreach(Visit v in visits)
            {
                VisitViewModel visitView = new VisitViewModel();
                visitView.PopulateFromDataModel(v);
                invitations.Visits
                    .Add(visitView);

            }

            return invitations;
        }

        public EditVisitViewModel GetEditVisitViewModel()
        {
            EditVisitViewModel editVisitView = new EditVisitViewModel();

            editVisitView.Visitors
                .AddRange(new SelectList(_context.Visitors, "VisitorId", "FirstName"));
            editVisitView.StaffMembers
                .AddRange(new SelectList(_context.StaffMembers, "SNumber", "FirstName"));
            editVisitView.Buildings
                .AddRange(new SelectList(_context.Buildings, "BuildingId", "BuildingName"));

            return editVisitView;
        }

        public bool CreateInvitation(Visit visit)
        {
            visit.CheckInDateTime = visit.VisitDate;
            _context.Update(visit);
            return _context.SaveChanges() > 0;
        }
    }
}
