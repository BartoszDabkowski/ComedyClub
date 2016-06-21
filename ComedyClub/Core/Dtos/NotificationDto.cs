using System;
using ComedyClub.Core.Models;

namespace ComedyClub.Core.Dtos
{
    public class NotificationDto
    {
        public DateTime DateTime { get; set; }
        public NotificationType NotificationType { get; set; }
        public DateTime? OriginalDateTime { get; set; }
        public string OriginalVenue { get; set; }
        public ShowDto Show { get; set; }
    }
}