using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Sup.Models;

namespace Sup.Models{ 
    public class Country{
        public int Id {get;set;}
        public string Name {get;set;}
       

        public virtual ICollection<City> Cities { get; set; }

    }
}