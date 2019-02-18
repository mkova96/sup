using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sup.Models.ViewModels
{
    public class EventViewModel
    {
        [Required(ErrorMessage = "Morate unijeti naziv sastanka")]
        public string Title {get; set;}
        [Required(ErrorMessage = "Morate unijeti opis sastanka")]
        public string Description {get; set;}
        [Required(ErrorMessage = "Morate unijeti datum održavanja")]
        public DateTime Date {get; set;}
        [Required(ErrorMessage = "Morate unijeti vrijeme održavanja")]
        public TimeSpan Time {get; set;}
        [Required(ErrorMessage = "Morate odabrati barem jednog korisnika")]
        [MinLength(1)]
        public List<string> UserIds { get; set; }


        public EventViewModel()
        {
            Date = DateTime.Today;
            Time = TimeSpan.Parse("12:00:00");
        }
    }
}