using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Sup.Models

{
  public class User : IdentityUser
  {
    public string Name{ get; set; }
    public string Surname { get; set; }
    public string Phone { get; set; }
    public DateTime Published {get; set;}
    
    public Company Company { get; set; }
    
    [InverseProperty("Sender")]
    public  ICollection<Message> SenderMessages { get; set; }

    [InverseProperty("Receiver")]
    public  ICollection<Message> ReceiverMessages { get; set; }

    [NotMapped]
    public virtual string Fullname => $"{Name} {Surname}";
  }
}