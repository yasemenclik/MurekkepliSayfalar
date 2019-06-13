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
        [DataType(DataType.Password)] // şifrenin yazıldığı kontrolde yazılan karakterlerin şifrelerin görünmemesi gerekir. Bu yapılandırmayı, modeliln Sifre özelliğine DataType attribute’u ekleyerek tanımlıyoruz. Şifre girişi için parametre olarak DataType.Password tanımlanması yapıldığında, View üzerinde üye girişi yapılırken şifre, kullanıcılara noktalı olarak gözükecektir.

        [Display(Name = "Parola")]
        [StringLength(20, ErrorMessage = "Lutfen {0} en az {2} karakter olmali en uzun {1} karakter olmali", MinimumLength = 6)]

        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)] // şifrenin yazıldığı kontrolde yazılan karakterlerin şifrelerin görünmemesi gerekir. Bu yapılandırmayı, modeliln Sifre özelliğine DataType attribute’u ekleyerek tanımlıyoruz. Şifre girişi için parametre olarak DataType.Password tanımlanması yapıldığında, View üzerinde üye girişi yapılırken şifre, kullanıcılara noktalı olarak gözükecektir.

        [Display(Name = "Parola Doğrula")]
        [Compare("Password", ErrorMessage = "Şifreler aynı değil!")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "İsim")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Soyisim")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Kullanıcı Adı")]
        public string UserName { get; set; }

        // [Required] : Adres ilk etapta zorunlu tutulmadığı için bu tabı yorum satırı olarak ekledik.
        [Display(Name = "Adres")]
        public string Address { get; set; }

        // [Required] : Ülke ilk etapta zorunlu tutulmadığı için bu tabı yorum satırı olarak ekledik.
        [Display(Name = "Ülke")]
        public string Country { get; set; }

        // [Required] : Şehir ilk etapta zorunlu tutulmadığı için bu tabı yorum satırı olarak ekledik.
        [Display(Name = "Şehir")]
        public string State { get; set; }

        // [Required] : Ödeme türü ilk etapta zorunlu tutulmadığı için bu tabı yorum satırı olarak ekledik.
        [Display(Name = "Ödeme Türü")]
        public string PaymentType { get; set; }

        // [Required] : Kart üzerindeki isim ilk etapta zorunlu tutulmadığı için bu tabı yorum satırı olarak ekledik.
        [Display(Name = "Kart Üzerindeki İsim")]
        public string CardUserName { get; set; }

        // [Required] : Kart numarası ilk etapta zorunlu tutulmadığı için bu tabı yorum satırı olarak ekledik.
        [Display(Name = "Kart Numarası")]
        [StringLength(16, ErrorMessage = "Lutfen {0} en uzun {1} karakter olmali", MinimumLength = 0)]
        public int CardNumber { get; set; }

        // [Required] : Kart son kullanım tarihi ilk etapta zorunlu tutulmadığı için bu tabı yorum satırı olarak ekledik.
        [Display(Name = "Son Kullanım Tarihi")]
        public int ExpirationDate { get; set; }

        // [Required] : CVV ilk etapta zorunlu tutulmadığı için bu tabı yorum satırı olarak ekledik.
        [Display(Name = "Kart Güvenlik Kodu (Cvv)")]
        public int Security { get; set; }
    }
}
