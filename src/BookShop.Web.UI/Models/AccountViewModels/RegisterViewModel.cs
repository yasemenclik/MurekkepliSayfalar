using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookShop.Web.UI.Models.AccountViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Eposta")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Parola")]
        [StringLength(20, ErrorMessage = "Lutfen {0} en az {2} karakter olmali en uzun {1} karakter olmali", MinimumLength = 6)]

        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Parola Doğrula")]
        [Compare("Password", ErrorMessage = "Şifreler aynı değil!")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "İsim")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Soyisim")]
        public string LastName { get; set; }
    }
}
