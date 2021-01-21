using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookMarket.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookMarket.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RentalController : Controller
    {
        private ApplicationDbContext _db;
        private IHostingEnvironment _he;

        public RentalController(ApplicationDbContext db, IHostingEnvironment he)
        {
            _db = db;
            _he = he;
        }
        public IActionResult Index()
        {
            return View(_db.MyBooks.Include(c => c.Categories).ToList());
        }
    }
}