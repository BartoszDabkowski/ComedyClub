using ComedyClub.Core.Models;
using ComedyClub.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ComedyClub.Persistence.Repositories
{

    public class AttendanceRepository : IAttendanceRepository
    {
        private readonly ApplicationDbContext _context;

        public AttendanceRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Attendance> GetFutureAttendances(string userId)
        {
            return _context.Attendances
                .Where(a => a.AttendeeId == userId && a.Show.DateTime > DateTime.Now)
                .ToList();
        }

        public Attendance GetAttendance(int id, string userId)
        {
            return _context.Attendances
                    .SingleOrDefault(a => a.ShowId == id && a.AttendeeId == userId);
        }

        public void Add(Attendance attendance)
        {
            _context.Attendances.Add(attendance);
        }

        public void Remove(Attendance attendance)
        {
            _context.Attendances.Remove(attendance);
        }
    }
}