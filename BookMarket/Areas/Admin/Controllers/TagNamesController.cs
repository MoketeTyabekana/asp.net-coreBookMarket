using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookMarket.Data;
using BookMarket.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookMarket.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TagNamesController : Controller
    {
        private ApplicationDbContext _db;

        public TagNamesController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            //var data = _db.ProductTypes.ToList();
            return View(_db.TagNames.ToList());
        }

        //Create Get Action Method
        public ActionResult Create()
        {
            return View();
        }

        //Create Post Action Method
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create(TagNames tagNames)
        {
            if (ModelState.IsValid)
            {
                _db.TagNames.Add(tagNames);
                await _db.SaveChangesAsync();
                TempData["save"] = "Tag Name saved";
                return RedirectToAction(nameof(Index));
            }
            return View(tagNames);
        }

        //Edit Get Action Method
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var tagName = _db.TagNames.Find(id);
            if (tagName == null)
            {
                return NotFound();
            }
            return View(tagName);
        }

        //Edit Post Action Method
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Edit(TagNames tagNames)
        {
            if (ModelState.IsValid)
            {
                _db.Update(tagNames);
                await _db.SaveChangesAsync();
                TempData["update"] = "Tag Name Updated";
                return RedirectToAction(nameof(Index));
            }
            return View(tagNames);
        }

        //Details Get Action Method
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var tagName = _db.TagNames.Find(id);
            if (tagName == null)
            {
                return NotFound();
            }
            return View(tagName);
        }

        //Details Post Action Method
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Details(TagNames tagNames)
        {
            return RedirectToAction(nameof(Index));

        }

        //Delete Get Action Method
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var tagName = _db.TagNames.Find(id);
            if (tagName == null)
            {
                return NotFound();
            }
            return View(tagName);
        }

        //Delete Post Action Method
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Delete(int? id, TagNames tagNames)
        {
            if (id == null)
            {
                return NotFound();
            }
            if (id != tagNames.Id)
            {
                return NotFound();
            }

            var tagName = _db.TagNames.Find(id);
            if (tagName == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _db.Remove(tagName);
                await _db.SaveChangesAsync();
                TempData["remove"] = "Tag Name deleted";
                return RedirectToAction(nameof(Index));
            }
            return View(tagName);
        }



    }
}