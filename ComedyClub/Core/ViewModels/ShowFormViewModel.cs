using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Web.Mvc;
using ComedyClub.Controllers;
using ComedyClub.Core.Models;

namespace ComedyClub.Core.ViewModels
{
    public class ShowFormViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Venue { get; set; }

        [Required]
        [FutureDate]
        public string Date { get; set; }

        [Required]
        [ValidTime]
        public string Time { get; set; }

        [Required]
        public byte GenreId { get; set; }

        public IEnumerable<Genre> Genres { get; set; }

        public DateTime GetDateTime()
        {
            return DateTime.Parse($"{Date} {Time}");
        }

        public string Heading { get; set; }

        public string Action
        {
            get
            {
                Expression<Func<ShowsController, ActionResult>> update =    
                    (e => e.Update(this));
                Expression<Func<ShowsController, ActionResult>> create =    
                    (e => e.Create(this));

                var action = (Id != 0) ? update : create;
                return (action.Body as MethodCallExpression).Method.Name;
            }
        } 
    }
}