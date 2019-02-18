using System.Collections.Generic;

namespace Sup.Models.ViewModels
{
    public class EditEventViewModel
    {
        public IEnumerable<string> UserIds { get; set; }
        public Event Event { get; set; }
    }
}