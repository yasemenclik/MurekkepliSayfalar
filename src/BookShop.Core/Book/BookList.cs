using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookShop.Core.Book
{
    public class BookList
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(70)]
        public string Title { get; set; }

        [Required]
        public string CreatorUserId { get; set; }

        public DateTime CreatedDate { get; set; }

        public virtual ICollection<BookListItem> BookListItems { get; set; }

        public static BookList Create(string title, string creatorUserId)
        {
            return new BookList
            {
                Title = title,
                CreatorUserId = creatorUserId,
                CreatedDate = DateTime.Now
            };
        }
    }
}