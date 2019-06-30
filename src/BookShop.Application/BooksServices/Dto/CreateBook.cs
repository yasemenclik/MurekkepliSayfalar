using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookShop.Application.BooksServices.Dto
{
    public class CreateBook
    {
        [Required]
        [Display(Name = "Kitap İsmi")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Kitap Yazarı")]
        public string Author { get; set; }

        [MaxLength(300)]
        [Required]
        [Display(Name = "Kitap Özeti")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Oluşturan Kullanıcı")]
        public string CreatorUserId { get; set; }
    }
}