using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Application.BookListServices.Dto;
using BookShop.Core.Book;
using BookShop.EntityFramework.Contexts;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Application.BookListServices
{
    public class BookListService : IBookListService
    {
        private ApplicationUserDbContext _context;
        public BookListService(ApplicationUserDbContext context)
        {
            _context = context;
        }

        public async Task<BookList> Get(int id)
        {
            var item = await _context.BookLists.FindAsync(id);
            return item;
        }

        public async Task<List<BookList>> GetAll()
        {
            var list = await _context.BookLists
                .Include(x => x.BookListItems)
                .ToListAsync();
            return list;
        }

        public async Task<List<BookList>> GetAllByOwner(string userId)
        {
            var list = await _context.BookLists
               .Where(x => x.CreatorUserId == userId)
               .Include(x => x.BookListItems).ToListAsync();
            return list;
        }

        public async Task<BookList> Create(CreateBookList input)
        {
            BookList newBookList = BookList.Create(input.Title, input.CreatorUserId);
            await _context.BookLists.AddAsync(newBookList);
            await _context.SaveChangesAsync();
            return newBookList;
        }

        public async Task<BookList> Update(UpdateBookList input)
        {
            var updateBookList = await Get(input.Id);
            updateBookList.Title = input.Title;
            _context.BookLists.Update(updateBookList);
            await _context.SaveChangesAsync();
            return updateBookList;
        }

        public async Task Delete(int id)
        {
            var item = await Get(id);
            _context.BookLists.Remove(item);
            await _context.SaveChangesAsync();
        }


    }
}