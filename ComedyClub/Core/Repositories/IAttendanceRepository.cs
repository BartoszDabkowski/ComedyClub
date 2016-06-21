using System.Collections.Generic;
using ComedyClub.Core.Models;

namespace ComedyClub.Core.Repositories
{
    public interface IAttendanceRepository
    {
        IEnumerable<Attendance> GetFutureAttendances(string userId);
        Attendance GetAttendance(int id, string userId);
        void Add(Attendance attendance);
        void Remove(Attendance attendance);
    }
}