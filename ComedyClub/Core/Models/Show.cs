using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace ComedyClub.Core.Models
{
    public class Show
    {
        public int Id { get; set; }

        public string ComedianId { get; set; }
        public ApplicationUser Comedian { get; set; }

        public DateTime DateTime { get; set; }

        public string Venue { get; set; }

        public byte GenreId { get; set; }
        public Genre Genre { get; set; }

        public bool IsCanceled { get; private set; }

        public ICollection<Attendance> Attendances { get; private set; }

        public Show()
        {
            Attendances = new Collection<Attendance>();
        }

        public void Cancel()
        {
            IsCanceled = true;

            var notification = Notification.ShowCanceled(this);

            foreach (var attendee in Attendances.Select(a => a.Attendee))
            {
                attendee.Notify(notification);
            }
        }

        public void Modify(DateTime dateTime, string venue, byte genreId)
        {
            var notification = Notification.ShowUpdated(this, DateTime, Venue);

            DateTime = dateTime;
            Venue = venue;
            GenreId = genreId;

            foreach (var attendee in Attendances.Select(a => a.Attendee))
                attendee.Notify(notification);
        }
    } 
}