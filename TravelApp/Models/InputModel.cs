using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using Microsoft.AspNetCore.Identity.UI;

namespace TravelApp.Models
{
    public class InputModel
    {
        [Required]
        public string Name { get; set; }

        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
}

