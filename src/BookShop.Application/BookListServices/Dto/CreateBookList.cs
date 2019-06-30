using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookShop.Application.BookListServices.Dto
{
    public class CreateBookList
    {
        [Required]
        [MaxLength(70)]
        [Display(Name = "Kitap Adı")]
        public string Title { get; set; }

        [Display(Name = "Oluşturan Kullanıcı")]
        public string CreatorUserId { get; set; }
    }
}