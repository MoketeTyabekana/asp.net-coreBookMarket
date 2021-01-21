using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookMarket.Data;
using BookMarket.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

namespace BookMarket.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class RentalController : Controller
    {
        
        private ApplicationDbContext _db;
        public RentalController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index(Books book,int? page)
        {
            return View(_db.Books.Include(c => c.Categories).Include(c => c.TagName).Where(s=>s.TagName.TagName == "Rentals" ).ToList().ToPagedList(page ?? 1, 9));
        }
    }
}