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
        //şifrenin yazıldığı kontrolde yazılan karakterlerin şifrelerin görünmemesi gerekir. Bu yapılandırmayı, modeliln Sifre özelliğine DataType attribute’u ekleyerek tanımlıyoruz. Şifre girişi için parametre olarak DataType.Password tanımlanması yapıldığında, View üzerinde üye girişi yapılırken şifre, kullanıcılara noktalı olarak gözükecektir.
        [Display(Name = "Parola")]
        [StringLength(20, ErrorMessage = "Lutfen {0} en az {2} karakter olmali en uzun {1} karakter olmali", MinimumLength = 6)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Parola Doğrula")]
        [Compare("Password", ErrorMessage = "Şifreler Aynı Değil!")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "İsim")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Soyisim")]
        public string LastName { get; set; }

        // [Required] -> Adres ilk etapta zorunlu tutulmadığı için bu tabı yorum satırı olarak ekledik.
        [Display(Name = "Adres")]
        public string Address { get; set; }

        // [Required] -> Ülke ilk etapta zorunlu tutulmadığı için bu tabı yorum satırı olarak ekledik.
        [Display(Name = "Ülke")]
        public string State { get; set; }

        // [Required] -> Şehir ilk etapta zorunlu tutulmadığı için bu tabı yorum satırı olarak ekledik.
        [Display(Name = "Şehir")]
        public string Country { get; set; }



    }
}