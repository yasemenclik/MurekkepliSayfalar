using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookShop.Core.Users;
using BookShop.Web.UI.Models.AccountViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.Web.UI.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

     
            public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        // Veritabanına veri ekleyeceğimiz için HttpPost yazıyoruz.
        // Veriyi eş zamanlı olarak (async) getirmesini sağlıyoruz.
        // ValidateAntiForgeryToken; kendisine gönderilen AntiForgeryToken’ı decrypt işleminden geçirerek, validation işlemlerini gerçekleştirmektedir.Eğer validation işlemlerinden geçemezse bu noktada exception’a düşmektedir.
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            // kayıt etme işlemleri
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = model.Email,
                    Email = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    EmailConfirmed = true,
                    TwoFactorEnabled = false
                };

                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Home");
                }
                AddErrors(result);
            }

            return View(model);
        }
        private void AddErrors(IdentityResult result)
        {
            foreach (var err in result.Errors)
            {
                ModelState.AddModelError(string.Empty, err.Description);
            }
        }

    }
}