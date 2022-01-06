using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PZI_projekt.Data;
using PZI_projekt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PZI_projekt.Controllers
{
    public class FrontPageController : Controller
    {
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ApplicationDbContext _db;

        public FrontPageController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, ApplicationDbContext db)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            _db = db;
        }

        //public IActionResult FrontPage()
        //{
        //    return View();
        //}
        
        public IActionResult FrontPage()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            IEnumerable<Car> objList = _db.Car;
            Car currentCar = new Car();
            foreach (var item in objList)
            {
                if(item.UserId == userId)
                {
                    currentCar = item;
                    break;
                }
            }
            return View(currentCar);
        }
    }
}

