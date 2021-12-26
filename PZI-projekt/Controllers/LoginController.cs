using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PZI_projekt.Models;
using PZI_projekt.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PZI_projekt.Controllers
{
    public class LoginController : Controller
    {
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly UserManager<IdentityUser> userManager;

        public LoginController(SignInManager<IdentityUser> signInManager,
                                    UserManager<IdentityUser> userManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
        }

        public IActionResult Login()
        {
            if (signInManager.IsSignedIn(User))
            {
                return RedirectToAction("FrontPage", "FrontPage");
            }

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("FrontPage", "FrontPage");
                }

                ModelState.AddModelError(string.Empty, "Invalid login!");
            }

            return View("Login", model);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Login", "Login");
        }


        /*private readonly ApplicationDbContext _db;

       public LogInController(ApplicationDbContext db)
       {
           _db = db;
       }*/
        /*//Post - login
        [HttpPost]
        [ValidateAntiForgeryToken] //za sigurnost(da podaci nisu promijenjeni od submitanja podataka do dolaska ovde)
        public IActionResult LogIn(Student obj)
        {
            var emailParamater = new SqlParameter("@Email", obj.Email);
            var passwordParametar = new SqlParameter("@Password", obj.Password);
            var tempStudent = _db.Student.FromSqlRaw("SELECT * FROM Student WHERE Email=@Email AND Password=@Password", emailParamater, passwordParametar).FirstOrDefault();

            //tempStudent - student koji se logira

            if (tempStudent != null)
            {
             
                return RedirectToAction("Index", "SelectMenza");
            }
            else
            {
                return View("Index");
            }
            
        }Za oni jednostavni unos  */


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
