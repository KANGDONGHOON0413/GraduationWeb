using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GraduationWeb.Models.ViewModels
{
    public class LoginApproach
    {
        [Required]
        public string ID { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
