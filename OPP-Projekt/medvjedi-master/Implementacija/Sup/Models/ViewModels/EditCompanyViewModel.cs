using System.Collections.Generic;

namespace Sup.Models.ViewModels
{
    public class EditCompanyViewModel
    {
        public int CityId { get; set; }
        public Company Company { get; set; }
        public IEnumerable<string> UserIds { get; set; }
    }
}