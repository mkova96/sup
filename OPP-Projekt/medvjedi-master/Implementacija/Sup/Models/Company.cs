using System.Collections.Generic;

namespace Sup.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int CityId { get; set; }
        public int IndustryId { get; set; }
        public string Logo { get; set; }
        public string Description { get; set; }
        public string Website { get; set; }
        public virtual City City { get; set; }

        public virtual ICollection<User> Users { get; set; }

        //public virtual Industry Industry { get; set; }

        //public virtual ICollection<CompanyKeyword> CompanyKeywords { get; set; }
    }
}