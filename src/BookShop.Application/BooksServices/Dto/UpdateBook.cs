using System;
using System.Collections.Generic;
using System.Text;

namespace BookShop.Application.BooksServices.Dto
{
    public class UpdateBook : CreateBook
    {
        public int Id { get; set; }
    }
}