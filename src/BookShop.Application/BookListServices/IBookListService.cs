using BookShop.Application.BookListServices.Dto;
using BookShop.Core.Book;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Application.BookListServices
{
    public interface IBookListService
    {
        Task<List<BookList>> GetAll();

        Task<List<BookList>> GetAllByOwner(string userId);

        Task<BookList> Get(int id);

        Task<BookList> Create(CreateBookList input);

        Task<BookList> Update(UpdateBookList input);

        Task Delete(int id);
    }
}