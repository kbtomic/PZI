using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PZI_projekt.Data;
using PZI_projekt.Models;
using PZI_projekt.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PZI_projekt.Controllers
{
    public class CreateAccountController : Controller
    {
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ApplicationDbContext _db;

        public CreateAccountController(SignInManager<ApplicationUser> signInManager,
                                    UserManager<ApplicationUser> userManager, ApplicationDbContext db)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            _db = db;
        }

        [HttpGet]
        public IActionResult CreateAccount()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAccount(CreateAccountViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                var result = await userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, isPersistent: false);
                    IEnumerable<Car> objList = _db.Car.FromSqlRaw("SELECT * FROM Car ").ToList();
                    foreach(var item in objList)
                    {
                        if(item.UserId == null)
                        {
                            _db.Car.Remove(item);
                            _db.SaveChanges();
                            item.Id = 0;
                            item.ApplicationUser = user;
                            _db.Car.Add(item);
                            _db.SaveChanges();
                            break;
                        }
                    }
                    return RedirectToAction("FrontPage", "FrontPage");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View(model);
        }
    }
}
