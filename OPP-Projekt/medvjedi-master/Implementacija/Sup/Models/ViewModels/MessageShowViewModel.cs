using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;


namespace Sup.Models.ViewModels {
  public class MessageShowViewModel {
        
    public IEnumerable<Message> Messages {get; set;}
    public int CurrentMessageId {get;set;}
    public User Receiver {get; set;}
    [Required(ErrorMessage = "Morate unijeti tekst poruke")]
    public string Content { get; set; }
    //public User UserRecieve { get; set; }
  }
}