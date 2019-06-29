using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookShop.Application.BooksServices.Dto
{
    public class CreateBook
    {
      
        [Required]
        [Display(Name="Kitabın İsmi")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Kitabın Yazarı")]
        public string Author { get; set; }

        [Required]
        [Display(Name = "Kitabın Açıklaması")]
        [MaxLength(300)]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Oluşturan Kullanıcı")]
        public string CreatorUserId { get; set; }
        
       
    }
}
