using System;
using System.Collections.Generic;
using System.Text;

namespace BookShop.Application.BookListServices.Dto
{
    public class UpdateBookList : CreateBookList
    {
        public int Id { get; set; }
    }
}