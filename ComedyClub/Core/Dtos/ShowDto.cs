using System;

namespace ComedyClub.Core.Dtos
{
    public class ShowDto
    {
        public int Id { get; set; }
        public UserDto Comedian { get; set; }
        public DateTime DateTime { get; set; }
        public string Venue { get; set; }
        public GenreDto Genre { get; set; }
        public bool IsCanceled { get; set; }
    }
}