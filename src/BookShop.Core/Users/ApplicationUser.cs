using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookShop.Core.Users
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [MaxLength(30)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(30)]
        public string LastName { get; set; }

        // [Required] : Adres ilk etapta zorunlu tutulmadığı için bu tabı yorum satırı olarak ekledik.
        
        public string Address { get; set; }

        // [Required] : Ülke ilk etapta zorunlu tutulmadığı için bu tabı yorum satırı olarak ekledik.
        
        public string Country { get; set; }

        // [Required] : Şehir ilk etapta zorunlu tutulmadığı için bu tabı yorum satırı olarak ekledik.
        
        public string State { get; set; }


    }
}
