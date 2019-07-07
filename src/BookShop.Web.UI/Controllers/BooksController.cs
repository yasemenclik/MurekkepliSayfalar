using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookShop.Application.BooksServices;
using BookShop.Application.BooksServices.Dto;
using BookShop.Core.Book;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.Web.UI.Controllers
{
    [Authorize]
    public class BooksController : Controller
    {
        private readonly IBooksService _booksService;
        public BooksController(IBooksService booksService)
        {
            _booksService = booksService;
        }
        public async Task<IActionResult> Index()
        {
            List<Books> model = await _booksService.GetAll();
            return View(model);
            
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateBook model)
        {
            if (ModelState.IsValid)
            {
                // model.CreatorUserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                var newItem = await _booksService.Create(model);
                return RedirectToAction("Index", "Books");
            }
            return View();
        }
        public async Task<ActionResult> Delete(int id)
        {
            return View(await _booksService.Get(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirm(DeleteBook model)
        {
            if (ModelState.IsValid)
            {
                // silme islemini yap 
                await _booksService.Delete(model.Id);
            }
            // ve

            // liste sayfasina gonder
            return RedirectToAction("Index", "Books");

        }

        public async Task<ActionResult> Update(int id)
        {
            var model = await _booksService.Get(id);
            UpdateBook updateModel = new UpdateBook
            {
                Id = model.Id,
                CreatorUserId = model.CreatorUserId,
                Description = model.Description,
                Name = model.Name,
                Author = model.Author,
            };
            return View(updateModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Update(UpdateBook model)
        {
            if (ModelState.IsValid)
            {
                var updatedBook = await _booksService.Update(model);

                UpdateBook updateModel = new UpdateBook
                {
                    Id = updatedBook.Id,
                    CreatorUserId = updatedBook.CreatorUserId,
                    Description = updatedBook.Description,
                    Name = updatedBook.Name,
                    Author = updatedBook.Author
                };
                return View(updateModel);
            }
            return View(model);
        }
    }
}