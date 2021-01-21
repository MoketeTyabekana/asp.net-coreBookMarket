using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BookMarket.Data;
using BookMarket.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookMarket.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RentApplicationsController : Controller
    {
        private ApplicationDbContext _db;
        private IHostingEnvironment _he;
        private RoleManager<IdentityRole> _roleManager;
        private UserManager<ApplicationUser> _userManager;
        public RentApplicationsController(ApplicationDbContext db, IHostingEnvironment he, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _he = he;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public IActionResult Index()
        {
            var applications = _db.RentApplicationDetails.Include(c => c.RentApplication).Include(f => f.User).ToList();
            if (applications == null)
            {
                return NotFound();
            }
            return View(applications);
        }

        public JsonResult OpenPDFPath(string pdf)
        {
            string PDFpath = "files/" + pdf;
            return Json(PDFpath);
        }
        public FileResult OpenPDF(string pdf)
        {
            string PDFpath = "wwwroot/files/" + pdf;
            byte[] abc = System.IO.File.ReadAllBytes(PDFpath);
            System.IO.File.WriteAllBytes(PDFpath, abc);
            MemoryStream ms = new MemoryStream(abc);
            return new FileStreamResult(ms, "application/pdf");
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var application = _db.RentApplicationDetails.Include(c => c.RentApplication).Include(c => c.User).Where(c => c.Id == id).FirstOrDefault();
            if (application == null)
            {
                return NotFound();
            }
            return View(application);
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
            var application = _db.RentApplicationDetails.FirstOrDefault(c => c.Id == id);
            if (application == null)
            {
                return NotFound();
            }

            _db.Remove(application);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Accept(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var application = _db.RentApplicationDetails.Include(c => c.RentApplication).Include(f => f.User).FirstOrDefault(c => c.Id == id);
            if (application == null)
            {
                return NotFound();
            }
            return View(application);
        }

        [HttpPost]
        public async Task<IActionResult> Accept(RentApplication application)
        {
            RentApplicationDetails applicationDetails = new RentApplicationDetails();

            application.Status = "Accepted";



            _db.Update(application);


            TempData["save"] = "User has been updated successfully";
            return RedirectToAction(nameof(Index));



        }
    }
}