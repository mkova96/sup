using System;
using System.Collections.Generic;

namespace Sup.Models
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Published {get; set;}
        public List<GroupUser> GroupUsers { get; set; }
    }
}