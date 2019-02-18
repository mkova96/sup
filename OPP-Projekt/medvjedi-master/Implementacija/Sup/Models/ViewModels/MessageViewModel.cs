using System.ComponentModel.DataAnnotations;

namespace Sup.Models.ViewModels {
  public class MessageViewModel {
        
    [Required(ErrorMessage = "Morate unijeti primatelja poruke")]
    public string ReceiverId { get; set; }
    [Required(ErrorMessage = "Morate unijeti tekst poruke")]
    public string Content { get; set; }
    //public User UserRecieve { get; set; }
  }
}