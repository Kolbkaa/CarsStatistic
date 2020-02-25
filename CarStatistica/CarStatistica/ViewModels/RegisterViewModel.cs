using System.ComponentModel.DataAnnotations;

namespace CarStatistica.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "To pole jest wymagane")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Minimum 3 znaków")]
        public string Login { get; set; }


        [Required(ErrorMessage = "To pole jest wymagane")]
        [DataType(DataType.Password)]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Minimum 6 znaków")]
        [Display(Name = "Hasło")]
        public string Password { get; set; }


        [Required(ErrorMessage = "To pole jest wymagane")]
        [Compare(nameof(Password), ErrorMessage = "Hasła nie zgodne")]
        [DataType(DataType.Password)]
        [Display(Name = "Powtórz hasło")]
        public string ConfirmPassword { get; set; }


        [Required(ErrorMessage = "To pole jest wymagane")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Wprowadź poprawny adres email")]
        public string Email { get; set; }
    }
}
