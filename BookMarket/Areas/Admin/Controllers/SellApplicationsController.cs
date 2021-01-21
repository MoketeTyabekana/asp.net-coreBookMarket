using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BookMarket.Data;
using BookMarket.Models;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MimeKit;

namespace BookMarket.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SellApplicationsController : Controller
    {
        private ApplicationDbContext _db;
        private readonly IHostingEnvironment _he;
        private readonly RoleManager<IdentityRole> _roleManager;
        private UserManager<ApplicationUser> _userManager;
        public SellApplicationsController(ApplicationDbContext db, IHostingEnvironment he, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _he = he;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public IActionResult Index()
        {
            var applications = _db.SellApplicationDetails.Include(c => c.SellApplication).Include(f=>f.User).ToList();
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
            string PDFpath = "wwwroot/files/"+pdf;
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
            var application = _db.SellApplicationDetails.Include(c => c.SellApplication).Include(c => c.User).Where(c => c.Id == id).FirstOrDefault();
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
            var application = _db.SellApplicationDetails.FirstOrDefault(c => c.Id == id);
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
            
            var application = _db.SellApplicationDetails.Include(c=>c.SellApplication).Include(f=>f.User).FirstOrDefault(c => c.Id == id);
            if (application == null)
            {
                return NotFound();
            }
            return View(application);
        }

        [HttpPost]
        public async Task<IActionResult> Accept(SellApplicationDetails application)
        {
           
            var applicationDetails = _db.SellApplicationDetails.Include(c => c.SellApplication).Include(f => f.User).FirstOrDefault(c => c.Id == application.Id);
            applicationDetails.SellApplication.Status = "Accepted";
            applicationDetails.SellApplication.ProofAddress = application.SellApplication.ProofAddress;
            applicationDetails.SellApplication.ProofId = application.SellApplication.ProofId;

            _db.Update(applicationDetails);
            var isSaveRole = await _userManager.AddToRoleAsync(applicationDetails.User, "Seller");

            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Book Market", "2021bookmarket@gmail.com"));
            message.To.Add(new MailboxAddress(applicationDetails.User.Name, applicationDetails.User.Email));
            message.Subject = "Application Successful";
            message.Body = new TextPart("plain")
            {
                Text = "Your application has been approved. You may now sell your books " +
                "on the BookMarket platform"
            };
            using (var client = new SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587, false);
                client.Authenticate("2021bookmarket@gmail.com", "bookmarket");
                client.Send(message);
                client.Disconnect(true);
            }

            await _db.SaveChangesAsync();

          

            TempData["save"] = "Application has been accepted";
            return RedirectToAction(nameof(Index));

        }
        public async Task<IActionResult> Decline(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var application = _db.SellApplicationDetails.Include(c => c.SellApplication).Include(f => f.User).FirstOrDefault(c => c.Id == id);
            if (application == null)
            {
                return NotFound();
            }
            return View(application);
        }

        [HttpPost]
        public async Task<IActionResult> Decline(SellApplicationDetails application, string Reason)
        {
            var applicationDetails = _db.SellApplicationDetails.Include(c => c.SellApplication).Include(f => f.User).FirstOrDefault(c => c.Id == application.Id);
            applicationDetails.SellApplication.Status = "Declined";
            applicationDetails.SellApplication.ProofAddress = application.SellApplication.ProofAddress;
            applicationDetails.SellApplication.ProofId = application.SellApplication.ProofId;
            applicationDetails.Reason = Reason;
            
            
            _db.Update(applicationDetails);

            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Book Market", "2021bookmarket@gmail.com"));
            message.To.Add(new MailboxAddress(applicationDetails.User.Name, applicationDetails.User.Email));
            message.Subject = "Application Unsuccessful";
            message.Body = new TextPart("plain")
            {
                Text = application.Reason
            };
            using (var client = new SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587, false);
                client.Authenticate("2021bookmarket@gmail.com", "bookmarket");
                client.Send(message);
                client.Disconnect(true);
            }

            await _db.SaveChangesAsync();

            TempData["save"] = "Application has been declined";
            return RedirectToAction(nameof(Index));

        }
    }
}


















