using Microsoft.AspNetCore.Mvc;
using PZI_projekt.Data;
using PZI_projekt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PZI_projekt.Controllers
{
    public class CheckStatusController : Controller
    {
        //public IActionResult CheckStatus()
        //{
        //    return View();
        //}

        private readonly ApplicationDbContext _db;

        public CheckStatusController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult CheckStatus()
        {
            IEnumerable<Car> objList = _db.Car;
            return View(objList);
        }
    }
}
