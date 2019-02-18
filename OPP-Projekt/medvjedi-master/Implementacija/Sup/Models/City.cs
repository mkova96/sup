using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Sup.Models;

namespace Sup.Models{
    public class City{
        public int Id {get;set;}
        public string Name {get;set;}
        int CountryId {get;set;}
        

       public virtual Country Country { get; set; }
    }
}