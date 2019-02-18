using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Sup.Models;

namespace Sup.Models{ 
    public class CompanyKeyword {
        public int Id {get;set;}
        //public int CompanyId {get;set;}

        public Company Company {get;set;}
        public Keyword Keyword {get;set;}

    }
}