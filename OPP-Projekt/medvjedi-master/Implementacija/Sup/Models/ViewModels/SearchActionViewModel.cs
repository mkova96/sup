using System.Collections.Generic;

namespace Sup.Models.ViewModels
{
    public class SearchActionViewModel
    {
        public IEnumerable<User> Users { get; set; }
        public IEnumerable<Company> Companies { get; set; }
        public bool Savior { get; set; }
        public bool Patriot { get; set; }
        public bool Boss { get; set; }
    }
}