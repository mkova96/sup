using System.Collections.Generic;

namespace Sup.Models.ViewModels
{
    public class EditGroupViewModel
    {
        public IEnumerable<string> UserIds { get; set; }
        public Group Group { get; set; }
    }
}