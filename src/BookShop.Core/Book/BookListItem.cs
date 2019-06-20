using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BookShop.Core.Book
{
    public class BookListItem
    {
        public int Id { get; set; }

        [ForeignKey("BookId")]
        public virtual Books Book { get; set; }
        public virtual int BookId { get; set; }
        
        public bool IsCompleted { get; set; } = false;

        [ForeignKey("BookListId")]
        public virtual BookList BookList { get; set; }
        public virtual int BookListId { get; set; }

        [Required]
        public string CreatorUserId { get; set; }
        public DateTime CreatedDate { get; set; }

        public static BookListItem Create(int bookId, int bookListId, string creatorUserId)
        {
            return new BookListItem
            {
                BookId = bookId,
                BookListId = bookListId,
                CreatorUserId = creatorUserId,
                CreatedDate = DateTime.Now,
                IsCompleted = false
            };
        }
    }
}
           
