using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BookMarket.Data;
using BookMarket.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BookMarket.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class SellController : Controller
    {
        private IHostingEnvironment _he;
        private UserManager<ApplicationUser> _userManager;
        private ApplicationDbContext _db;

        public SellController(ApplicationDbContext db, UserManager<ApplicationUser> userManager, IHostingEnvironment he)
        {
            _db = db;
            _he = he;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
           
            return View();
        }
        public async Task<IActionResult> Terms()
        {
            return View();
        }

        [Authorize]
        public async Task<IActionResult> Apply()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Apply(SellApplications application, IFormFile address, IFormFile Id)
        {
            if (ModelState.IsValid)
            {
                if (address != null)
                {
                    var name = Path.Combine(_he.WebRootPath + "/files", Path.GetFileName(address.FileName));
                    await address.CopyToAsync(new FileStream(name, FileMode.Create));
                    application.ProofOfAddress = "files/" + address.FileName;
                }
                //if (Id != null)
                //{
                //    var name = Path.Combine(_he.WebRootPath + "/files", Path.GetFileName(Id.FileName));
                //    await address.CopyToAsync(new FileStream(name, FileMode.Create));
                //    application.ProofOfID = "files/" + Id.FileName;
                //}
                application.UserId = _userManager.GetUserId(User);
                _db.SellApplications.Add(application);
                
                
                await _db.SaveChangesAsync();
                TempData["save"] = "Application successfully sent";
                return Redirect("~/");
            }
            return View(application);
        }











    }
}