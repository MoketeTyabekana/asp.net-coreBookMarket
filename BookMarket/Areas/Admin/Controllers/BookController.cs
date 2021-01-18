using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BookMarket.Data;
using BookMarket.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BookMarket.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BookController : Controller
    {
        private ApplicationDbContext _db;
        private IHostingEnvironment _he;

        public BookController(ApplicationDbContext db, IHostingEnvironment he)
        {
            _db = db;
            _he = he;
        }
        public IActionResult Index()
        {
            return View(_db.Books.Include(c => c.Categories).Include(f => f.TagName).ToList());
        }
        //POST Index Action Method
        [HttpPost]
        public IActionResult Index(decimal? lowAmount, decimal? largeAmount)
        {
            var books = _db.Books.Include(c => c.Categories).Include(c => c.TagName)
                .Where(c => c.Price >= lowAmount && c.Price <= largeAmount).ToList();
            if (lowAmount == null || largeAmount == null)
            {
                books = _db.Books.Include(c => c.Categories).Include(c => c.TagName).ToList();

            }
            return View(books);
        }

        //Get Create Method
        public IActionResult Create()
        {
            ViewData["categoryId"] = new SelectList(_db.Categories.ToList(), "Id", "Category");
            ViewData["TagNameId"] = new SelectList(_db.TagNames.ToList(), "Id", "TagName");
            return View();
        }


        //Post Create Method
        [HttpPost]

        public async Task<IActionResult> Create(Books book, IFormFile image)
        {
            if (ModelState.IsValid)
            {
                var searchBook = _db.Books.FirstOrDefault(c => c.Title == book.Title);
                if (searchBook != null)
                {
                    ViewBag.message = "This book already exists!";

                    ViewData["categoryId"] = new SelectList(_db.Categories.ToList(), "Id", "Category");
                    ViewData["TagNameId"] = new SelectList(_db.TagNames.ToList(), "Id", "TagName");
                    return View();
                }
                if (image != null)
                {
                    var name = Path.Combine(_he.WebRootPath + "/images", Path.GetFileName(image.FileName));
                    await image.CopyToAsync(new FileStream(name, FileMode.Create));
                    book.Image = "images/" + image.FileName;
                }
                else 
                {
                    book.Image = "images/noimage.PNG";
                }
                _db.Books.Add(book);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

        //Get Edit Action Method

        public ActionResult Edit(int? id)
        {
            ViewData["categoryId"] = new SelectList(_db.Categories.ToList(), "Id", "Category");
            ViewData["TagNameId"] = new SelectList(_db.TagNames.ToList(), "Id", "TagName");
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
        [HttpPost]
        //POST Edit Action Method
        public async Task<IActionResult> Edit(Books book, IFormFile image)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    var name = Path.Combine(_he.WebRootPath + "/images", Path.GetFileName(image.FileName));
                    await image.CopyToAsync(new FileStream(name, FileMode.Create));
                    book.Image = "images/" + image.FileName;
                }
                else
               
                {
                    book.Image = "Images/noimage.PNG";
                }
                _db.Books.Update(book);
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
            var book = _db.Books.Include(c => c.Categories).Include(c => c.TagName)
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
            var book = _db.Books.Include(c => c.TagName).Include(c => c.Categories).Where(c => c.Id == id).FirstOrDefault();
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
            var book = _db.Books.FirstOrDefault(c => c.Id == id);
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