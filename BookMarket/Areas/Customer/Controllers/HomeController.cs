using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookMarket.Models;
using BookMarket.Data;
using Microsoft.EntityFrameworkCore;
using BookMarket.Utility;
using X.PagedList;
using Microsoft.AspNetCore.Http;

namespace BookMarket.Controllers
{
    [Area("Customer")]
    
    public class HomeController : Controller
    {
        private ApplicationDbContext _db;
        public HomeController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index(int? page)
        {

            return View(_db.Books.Include(c => c.Categories).Include(c => c.TagName).ToList().ToPagedList(page ?? 1, 9));
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        //Get Book Detail Action Method
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var book = _db.Books.Include(c => c.Categories).Include(c => c.TagName)
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
            List<Books> books = new List<Books>();
            if (id == null)
            {
                return NotFound();
            }
            var book = _db.Books.Include(c => c.Categories).Include(c => c.TagName)
                .FirstOrDefault(c => c.Id == id);
            if (book == null)
            {
                return NotFound();
            }
            books = HttpContext.Session.Get<List<Books>>("books");
            if (books == null)
            {
                books = new List<Books>();
            }
            books.Add(book);
            HttpContext.Session.Set("books", books);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Remove(int? id)
        {
            List<Books> books = HttpContext.Session.Get<List<Books>>("books");
            if (books != null)
            {
                var book = books.FirstOrDefault(c => c.Id == id);
                if (book != null)
                {
                    books.Remove(book);
                    HttpContext.Session.Set("books", books);
                }
            }

            return RedirectToAction(nameof(Index));
        }

        //Get Remove Action Method
        [ActionName("Remove")]
        public IActionResult RemoveFromCart(int? id)
        {
            List<Books> books = HttpContext.Session.Get<List<Books>>("books");
            if (books != null)
            {
                var book = books.FirstOrDefault(c => c.Id == id);
                if (book != null)
                {
                    books.Remove(book);
                    HttpContext.Session.Set("books", books);
                }
            }

            return RedirectToAction(nameof(Cart));
        }

        //Get Cart Action Method
        public IActionResult Cart()
        {
            List<Books> books = HttpContext.Session.Get<List<Books>>("books");
            if (books == null)
            {
                books = new List<Books>();
            }
            return View(books);
        }

    }
}
