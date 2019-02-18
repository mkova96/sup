using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sup.Models.ViewModels
{
    public class SettingsViewModel
    {

        [Required]
        public string SettingsName { get; set; }

        [Required]
        public string SettingsValue { get; set; }
    }
}