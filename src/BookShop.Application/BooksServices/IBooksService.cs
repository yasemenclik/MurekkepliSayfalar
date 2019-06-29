using BookShop.Application.BooksServices.Dto;
using BookShop.Core.Book;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Application.BooksServices
{
    public interface IBooksService
    {
        Task<Books> Get(int id);
        Task<List<Books>> GetAll();

        Task<Books> Create(CreateBook input);
        Task<Books> Update(UpdateBook input);
        Task<Books> Delete(DeleteBook input);
    }
}
