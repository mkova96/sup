using System.ComponentModel.DataAnnotations;

namespace Sup.Models.ViewModels {
  public class UserViewModel {
    [Required(ErrorMessage = "Morate unijeti ime korisnika")]
    public string Name{ get; set; }
    [Required]
    public string Surname { get; set; }
    public string Phone { get; set; }
    public string EMail { get; set; }
    [Required]
    public string Password { get; set; }
    public string Role { get; set; }
    [Required]
    [Range(1, int.MaxValue)]
    public int CompanyId { get; set; }
  }
}