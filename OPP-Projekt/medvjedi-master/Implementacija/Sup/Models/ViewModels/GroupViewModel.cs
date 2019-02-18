using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sup.Models.ViewModels
{
    public class GroupViewModel
    {
        [Required(ErrorMessage = "Morate unijeti ime grupe")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Morate odabrati barem jednog korisnika")]
        [MinLength(1)]
        public List<string> UserIds { get; set; }
    }
}