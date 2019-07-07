using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Application.BooksServices.Dto;
using BookShop.Core.Book;
using BookShop.EntityFramework.Contexts;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Application.BooksServices
{
    public class BooksService : IBooksService
    {
        private ApplicationUserDbContext _context;
        public BooksService(ApplicationUserDbContext context)
        {
            _context = context;
        }

        public async Task<Books> Get(int id)
        {
            var item = await _context.Books.FindAsync(id);
            return item;
        }

        public async Task<List<Books>> GetAll()
        {
            List<Books> list = await _context.Books
                .ToListAsync();
            if (!(list.Count() > 0))
            {
                list = new List<Books>();
            }
            return list;
        }

        public async Task<Books> Create(CreateBook input)
        {
            Books newBook = Books.Create(input.Name, input.Author, input.Description, input.CreatorUserId);
            await _context.Books.AddAsync(newBook);
            await _context.SaveChangesAsync();
            return newBook;
        }

        public async Task<Books> Update(UpdateBook input)
        {
            var updateBook = await Get(input.Id);
            updateBook.Name = input.Name;
            updateBook.Author = input.Author;
            updateBook.Description = input.Description;
            _context.Books.Update(updateBook);
            await _context.SaveChangesAsync();
            return updateBook;
        }

        public async Task Delete(int id)
        {
            var item = await Get(id);
            _context.Books.Remove(item);
            await _context.SaveChangesAsync();
        }
    }
}