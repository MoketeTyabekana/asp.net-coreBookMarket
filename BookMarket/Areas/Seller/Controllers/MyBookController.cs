using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BookMarket.Data;
using BookMarket.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BookMarket.Areas.Seller.Controllers
{
    [Area("Seller")]
    public class MyBookController : Controller
    {
        private ApplicationDbContext _db;
        private IHostingEnvironment _he;
        private UserManager<ApplicationUser> _userManager;

        public MyBookController(ApplicationDbContext db, IHostingEnvironment he, UserManager<ApplicationUser> userManager)
        {
            _db = db;
            _he = he;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
           
            return View(_db.MyBookDetails.Include(c => c.MyBook).Include(c => c.MyBook.Categories).Where(h=>h.UserId == _userManager.GetUserId(User)).ToList());
        }
        //POST Index Action Method
        [HttpPost]
        public IActionResult Index(decimal? lowAmount, decimal? largeAmount)
        {
            var books = _db.MyBooks.Include(c => c.Categories)
                .Where(c => c.Price >= lowAmount && c.Price <= largeAmount).ToList();
            if (lowAmount == null || largeAmount == null)
            {
                books = _db.MyBooks.Include(c => c.Categories).ToList();

            }
            return View(books);
        }

        //Get Create Method
        public IActionResult Create()
        {
            ViewData["categoryId"] = new SelectList(_db.Categories.ToList(), "Id", "Category");
           
            return View();
        }


        //Post Create Method

        [HttpPost]
        public async Task<IActionResult> Create(MyBookDetails book, IFormFile image)
        {
            
            if (ModelState.IsValid)
            {
                var searchBook = _db.MyBookDetails.Include(f=>f.MyBook).FirstOrDefault(c => c.MyBook.Title == book.MyBook.Title);
                if (searchBook != null)
                {
                    ViewBag.message = "This book already exists!";

                    ViewData["categoryId"] = new SelectList(_db.Categories.ToList(), "Id", "Category");
                    
                    return View();
                }
                if (image != null)
                {
                    var name = Path.Combine(_he.WebRootPath + "/images", Path.GetFileName(image.FileName));
                    await image.CopyToAsync(new FileStream(name, FileMode.Create));
                    book.MyBook.Image = "images/" + image.FileName;
                }
                else
                {
                    book.MyBook.Image = "images/noimage.PNG";
                }

                book.UserId = _userManager.GetUserId(User);
                _db.MyBookDetails.Add(book);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

        //Get Edit Action Method

        public ActionResult Edit(int? id)
        {
            ViewData["categoryId"] = new SelectList(_db.Categories.ToList(), "Id", "Category");
           
            if (id == null)
            {
                return NotFound();
            }
            var book = _db.MyBookDetails.Include(c => c.MyBook.Categories).Include(c => c.User)
                .FirstOrDefault(c => c.Id == id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }
        [HttpPost]
        //POST Edit Action Method
        public async Task<IActionResult> Edit(MyBookDetails book, IFormFile image)
        {
            var mybook = _db.MyBookDetails.Include(c => c.MyBook.Categories).Include(c => c.User)
               .FirstOrDefault(c => c.Id == book.Id);
            
            if (ModelState.IsValid)
            {
                if (image == null)
                {
                    mybook.MyBook.Image = mybook.MyBook.Image;
                }
                else

                {
                    var name = Path.Combine(_he.WebRootPath + "/images", Path.GetFileName(image.FileName));
                    await image.CopyToAsync(new FileStream(name, FileMode.Create));
                    mybook.MyBook.Image = "images/" + image.FileName;
                }


                _db.MyBookDetails.Update(book);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(book);

        }

        //Get Details Action Method
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var book = _db.MyBookDetails.Include(c => c.MyBook.Categories).Include(c => c.User)
                .FirstOrDefault(c => c.Id == id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        //Get Delete Action Method
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var book = _db.MyBookDetails.Include(c => c.User).Include(c => c.MyBook.Categories).Where(c => c.Id == id).FirstOrDefault();
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        //Post Delete Action Method
        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var book = _db.MyBookDetails.FirstOrDefault(c => c.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            _db.Remove(book);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}