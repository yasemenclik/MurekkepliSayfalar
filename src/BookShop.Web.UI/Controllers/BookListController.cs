using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BookShop.Application.BookListServices;
using BookShop.Application.BookListServices.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.Web.UI.Controllers
{
    [Authorize]
    public class BookListController : Controller
    {
        private readonly IBookListService _bookListService;
        public BookListController(IBookListService bookListService)
        {
            _bookListService = bookListService;
        }
        public async Task<IActionResult> Index()
        {
            
            if (User.IsInRole("Admin"))
            {
                return View(await _bookListService.GetAll());
            }

            string userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            return View(await _bookListService.GetAllByOwner(userId));
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateBookList model)
        {
            if (ModelState.IsValid)
            {
                model.CreatorUserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                var newItem = await _bookListService.Create(model);
                return RedirectToAction("Index", "BookList");
            }
            return View();
        }
        public async Task<ActionResult> Delete(int id)
        {
            return View(await _bookListService.Get(id));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirm(DeleteBookList model)
        {
            if (ModelState.IsValid)
            {
                // silme islemini yap 
                await _bookListService.Delete(model.Id);
            }
            // ve

            // liste sayfasina gonder
            return RedirectToAction("Index", "BookList");

        }

        public async Task<ActionResult> Update(int id)
        {
            var model = await _bookListService.Get(id);
            UpdateBookList updateModel = new UpdateBookList
            {
                Id = model.Id,
                CreatorUserId = model.CreatorUserId,
                Title = model.Title
            };
            return View(updateModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Update(UpdateBookList model)
        {
            if (ModelState.IsValid)
            {
                var updatedBookList = await _bookListService.Update(model);

                UpdateBookList updateModel = new UpdateBookList
                {
                    Id = updatedBookList.Id,
                    CreatorUserId = updatedBookList.CreatorUserId,
                    Title = updatedBookList.Title
                };
                return View(updateModel);
            }
            return View(model);
        }
    }
}