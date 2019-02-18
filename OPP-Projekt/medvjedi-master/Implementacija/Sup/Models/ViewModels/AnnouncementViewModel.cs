using System;
using System.ComponentModel.DataAnnotations;


namespace Sup.Models.ViewModels
{
    public class AnnouncementViewModel
    {
        [Required(ErrorMessage = "Morate unijeti naziv obavijest")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Morate unijeti sadržaj obavijesti")]
        public string Message { get; set; }

        [Required]
        public string RecieverType { get; set; }

        public string UserId { get; set; }
        public int GroupId { get; set; }
    }
}