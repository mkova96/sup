using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;


namespace Sup.Models.ViewModels
{
    public class CompanyViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Adress {get;set;}
        [Required]
        public string Logo {get;set;}
        [Required]
        public string Description {get;set;}
        [Required]
        public string Website {get;set;}

        [Required]
        [MinLength(1)]
        public List<string> UserIds {get;set;}

        [Required]
        public int CityId { get; set; }
    }
}