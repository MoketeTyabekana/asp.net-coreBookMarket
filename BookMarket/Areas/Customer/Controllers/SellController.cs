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
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

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

        public IActionResult Terms()
        {

            return View();
        }

        [Authorize]
        public IActionResult  Apply()
        {

           
            //ViewData["UserId"] = new SelectList(_db.Application.ToList(), "Id");

            //var user = await _userManager.GetUserAsync(User);
            //if (user == null)
            //{
            //    return NotFound();
            //}
            //return View(user);
            return View();

        }

        //Post Create Method
        [HttpPost]
        [ValidateAntiForgeryToken]


        public async Task<IActionResult> Apply(SellApplication application, IFormFile ID, IFormFile Address)
        {
            SellApplicationDetails applicationDetails = new SellApplicationDetails();

          
               
                if (ID != null)
                {
                    var id = Path.Combine(_he.WebRootPath + "/files", Path.GetFileName(ID.FileName));
                    await ID.CopyToAsync(new FileStream(id, FileMode.Create));
                    application.ProofId = "files/" + ID.FileName;
                }
                if (Address != null)
                {
                    var address = Path.Combine(_he.WebRootPath + "/files", Path.GetFileName(Address.FileName));
                    await Address.CopyToAsync(new FileStream(address, FileMode.Create));
                    application.ProofAddress = "files/" + Address.FileName;
                }
            applicationDetails.UserId = _userManager.GetUserId(User);
            application.Status = "Pending";
            application.SellApplicationDetails.Add(applicationDetails);
            
            _db.SellApplication.Add(application);

            await _db.SaveChangesAsync();
            TempData["save"] = "Application successfully sent";
            return Redirect("~/");


        }















    }
}