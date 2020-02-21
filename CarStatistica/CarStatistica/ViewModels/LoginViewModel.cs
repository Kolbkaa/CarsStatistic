using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarStatistica.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "To pole jest wymagane")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Minimum 3 znaków")]
        public string Login { get; set; }


        [Required(ErrorMessage = "To pole jest wymagane")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Minimum 6 znaków")]
        [Display(Name = "Hasło")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
