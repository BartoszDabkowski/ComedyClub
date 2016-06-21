using System;
using System.ComponentModel.DataAnnotations;

namespace ComedyClub.Core.Models
{
    public class Notification
    {
        public int Id { get; private set; }
        public DateTime DateTime { get; private set; }
        public NotificationType NotificationType { get; private set; }
        public DateTime? OriginalDateTime { get; private set; }
        public string OriginalVenue { get; private set; }

        [Required]
        public Show Show { get; set; }

        protected Notification()
        {
        }

        private Notification(Show show, NotificationType notificationType)
        {
            if (show == null)
                throw new ArgumentNullException(nameof(show));

            Show = show;
            DateTime = DateTime.Now;
            NotificationType = notificationType;
        }

        public static Notification ShowCreated(Show show)
        {
            return new Notification(show, NotificationType.ShowCreated);
        }

        public static Notification ShowUpdated(Show newShow, DateTime originalDateTime, string originalVenue)
        {
            return new Notification(newShow, NotificationType.ShowUpdated)
            {
                OriginalDateTime = originalDateTime,
                OriginalVenue = originalVenue
            };
        }

        public static Notification ShowCanceled(Show show)
        {
            return new Notification(show, NotificationType.ShowCanceled);
        }

    }
}