using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookMarket.Areas.Customer.Controllers
{
    [Area("Customer")]

    public class RentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [Authorize]
        public IActionResult Rent()
        {
            return View();
        }

        public IActionResult Terms()
        {
            return View();
        }



    }
}