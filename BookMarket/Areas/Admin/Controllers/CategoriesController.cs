using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookMarket.Data;
using BookMarket.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookMarket.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class CategoriesController : Controller
    {
        private ApplicationDbContext _db;

        public CategoriesController(ApplicationDbContext db)
        {
            _db = db;
        }
        //[AllowAnonymous]
        public IActionResult Index()
        {
            //var data = _db.ProductTypes.ToList();
            return View(_db.Categories.ToList());
        }

        //GET Create Action Method

        public ActionResult Create()
        {
            return View();
        }

        //POST Create Action Method

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Categories categories)
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Add(categories);
                await _db.SaveChangesAsync();
                TempData["save"] = "Category has been saved";
                return RedirectToAction(nameof(Index));
            }

            return View(categories);
        }

        //GET Edit Action Method

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = _db.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        //POST Edit Action Method

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Categories categories)
        {
            if (ModelState.IsValid)
            {
                _db.Update(categories);
                await _db.SaveChangesAsync();
                TempData["edit"] = "Category has been updated";
                return RedirectToAction(nameof(Index));
            }

            return View(categories);
        }


        //GET Details Action Method

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = _db.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        //POST Edit Action Method

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Details(Categories categories)
        {
            return RedirectToAction(nameof(Index));

        }

        //GET Delete Action Method

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = _db.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        //POST Delete Action Method

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int? id, Categories categories)
        {
            if (id == null)
            {
                return NotFound();
            }

            if (id != categories.Id)
            {
                return NotFound();
            }

            var category = _db.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _db.Remove(category);
                await _db.SaveChangesAsync();
                TempData["delete"] = "Category has been deleted";
                return RedirectToAction(nameof(Index));
            }

            return View(categories);
        }

    }
}