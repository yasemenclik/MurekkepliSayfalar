using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookShop.Core.Book
{
    public class Books
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        [MaxLength(300)]
        public string Description { get; set; }

        [Required]
        public string CreatorUserId { get; set; }
        public DateTime CreatedDate { get; set; }

        public static Books Create(string name, string author, string description, string creatorUserId)
        {
            return new Books
            {
                Name = name,
                Author = author,
                Description = description,
                CreatorUserId = creatorUserId,
                CreatedDate = DateTime.Now
               
            };
        }

    }
}
