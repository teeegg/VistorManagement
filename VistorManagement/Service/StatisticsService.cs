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
    public class StatisticsService
    {
        private readonly VisitorManagementContext _context;

        public StatisticsService(VisitorManagementContext context)
        {
            _context = context;
        }

        public HostsViewModel GetHostsViewModel()
        {
            HostsViewModel hosts = new HostsViewModel();

            var staff = _context.StaffMembers
                .Include(s => s.Visits)
                .AsNoTracking()
                .OrderBy(s => s.FirstName)
                .ToList();

            var buildings = _context.Buildings
                .AsNoTracking()
                .OrderBy(b => b.BuildingName)
                .ToList();

            var campuses = _context.Campuses
                .AsNoTracking()
                .OrderBy(c => c.CampusName)
                .ToList();

            hosts.StaffMembers = staff;
            hosts.Buildings.AddRange(new SelectList(buildings, "BuildingId", "BuildingName"));
            hosts.Campuses.AddRange(new SelectList(campuses, "CampusId", "CampusName"));

            return hosts;
        }

        public HostsViewModel FilterHostByBuildingId(string buildingId)
        {
            HostsViewModel hosts = new HostsViewModel();

            var staff = _context.StaffMembers
                .Include(s => s.Visits)
                .Where(s => s.Visits.Any(v => v.BuildingId == buildingId))
                .AsNoTracking()
                .OrderBy(s => s.FirstName)
                .ToList();

            var building = _context.Buildings
                .Single(b => b.BuildingId == buildingId);

            var buildings = _context.Buildings
                .Where(b => b.CampusId == building.CampusId)
                .AsNoTracking()
                .OrderBy(b => b.BuildingName)
                .ToList();

            var campuses = _context.Campuses
                .AsNoTracking()
                .OrderBy(c => c.CampusName)
                .ToList();

            hosts.StaffMembers = staff;
            hosts.Buildings.AddRange(new SelectList(buildings, "BuildingId", "BuildingName"));
            
            hosts.Campuses.AddRange(new SelectList(campuses, "CampusId", "CampusName"));
            hosts.BuildingId = buildingId;
            hosts.CampusId = building.CampusId;

            return hosts;
        }

        public HostsViewModel FilterHostByCampusId(string campusId)
        {
            HostsViewModel hosts = new HostsViewModel();

            var staff = _context.StaffMembers
                .Include(s => s.Visits)
                .Where(s => s.Visits.Any(v => v.Building.CampusId == campusId))
                .AsNoTracking()
                .OrderBy(s => s.FirstName)
                .ToList();

            var buildings = _context.Buildings
                .Where(b => b.CampusId == campusId)
                .AsNoTracking()
                .OrderBy(b => b.BuildingName)
                .ToList();

            var campuses = _context.Campuses
                .AsNoTracking()
                .OrderBy(c => c.CampusName)
                .ToList();

            hosts.StaffMembers = staff;
            hosts.Buildings.AddRange(new SelectList(buildings, "BuildingId", "BuildingName"));
            hosts.Campuses.AddRange(new SelectList(campuses, "CampusId", "CampusName"));
            hosts.CampusId = campusId;

            return hosts;
        }


        public VisitorStatisticsViewModel GetVisitorStatisticsViewModel()
        {
            VisitorStatisticsViewModel visitorStatistics =
                new VisitorStatisticsViewModel();

            visitorStatistics.TotalHosts =
                _context.StaffMembers
                .Include(s => s.Visits)
                .Count(s => s.Visits.Count > 0);

            visitorStatistics.TotalVisitors =
                _context.Visits
                .GroupBy(v => v.VisitorId)
                .Count();


            visitorStatistics.TotalVisits =
                _context.Visits
                .Count(v => v.CheckOutDateTime.HasValue);


            visitorStatistics.Hosts =
                _context.StaffMembers
                .Where(s => s.Visits.Count > 0)
                .OrderByDescending(s => s.Visits.Count)
                .Take(10)
                .Include(s => s.Visits)
                .AsNoTracking()
                .ToList();

            visitorStatistics.Buildings =
                _context.Buildings
                .Where(b => b.Visits.Count > 0)
                .OrderByDescending(b => b.Visits.Count)
                .Take(10)
                .Include(b => b.Visits)
                .Include(b => b.Campus)
                .AsNoTracking()
                .ToList();

            visitorStatistics.Campuses =
                _context.Campuses
                .Include(c => c.Buildings)
                    .ThenInclude(b => b.Visits)
                .AsNoTracking()
                .ToList();

            return visitorStatistics;
        }
    }
}
