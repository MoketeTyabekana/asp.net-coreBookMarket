using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookMarket.Data;
using BookMarket.Models;
using BookMarket.Utility;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

namespace BookMarket.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class RentalsController : Controller
    {
       
        private  ApplicationDbContext _db;
        private readonly IHostingEnvironment _he;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;
        public RentalsController(ApplicationDbContext db, IHostingEnvironment he, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _he = he;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public IActionResult Index(int? page)
        {
            return View(_db.MyBooks.Include(c => c.Categories).ToList().ToPagedList(page ?? 1, 9));
        }

        //Get Book Detail Action Method
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var book = _db.MyBooks.Include(c => c.Categories)
                .FirstOrDefault(c => c.Id == id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        //POST Book Detail Action Method
        [HttpPost]
        [ActionName("Details")]
        public ActionResult BookDetails(int? id)
        {
            List<MyBooks> books = new List<MyBooks>();
            if (id == null)
            {
                return NotFound();
            }
            var book = _db.MyBooks.Include(c => c.Categories)
                .FirstOrDefault(c => c.Id == id);
            if (book == null)
            {
                return NotFound();
            }
            books = HttpContext.Session.Get<List<MyBooks>>("mybooks");
            if (books == null)
            {
                books = new List<MyBooks>();
            }
            books.Add(book);
            HttpContext.Session.Set("mybooks", books);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Remove(int? id)
        {
            List<MyBooks> books = HttpContext.Session.Get<List<MyBooks>>("mybooks");
            if (books != null)
            {
                var book = books.FirstOrDefault(c => c.Id == id);
                if (book != null)
                {
                    books.Remove(book);
                    HttpContext.Session.Set("mybooks", books);
                }
            }

            return RedirectToAction(nameof(Index));
        }

        //Get Remove Action Method
        [ActionName("Remove")]
        public IActionResult RemoveFromCart(int? id)
        {
            List<MyBooks> books = HttpContext.Session.Get<List<MyBooks>>("mybooks");
            if (books != null)
            {
                var book = books.FirstOrDefault(c => c.Id == id);
                if (book != null)
                {
                    books.Remove(book);
                    HttpContext.Session.Set("mybooks", books);
                }
            }

            return RedirectToAction(nameof(Cart));
        }

        //Get Cart Action Method
        public IActionResult Cart()
        {
            List<MyBooks> books = HttpContext.Session.Get<List<MyBooks>>("mybooks");
            if (books == null)
            {
                books = new List<MyBooks>();
            }
            return View(books);
        }

        public IActionResult Rent()
        {
            return View();
        }
    }
}