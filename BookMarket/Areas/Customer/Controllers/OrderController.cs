using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookMarket.Data;
using BookMarket.Models;
using BookMarket.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace BookMarket.Areas.Customer.Controllers
{
    [Area("Customer")]
    [Authorize]
    public class OrderController : Controller
    {
        private ApplicationDbContext _db;
        private UserManager<ApplicationUser> _userManager;

        public OrderController(ApplicationDbContext db, UserManager<ApplicationUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }
        public async Task<IActionResult> Details()
        {

            var user = await _userManager.GetUserAsync(User);
                if (user == null)
                {
                    return NotFound();
                }
                return View(user);
           
        }

        [HttpPost]
        public async Task<IActionResult> Details(ApplicationUser user)
        {
            var userInfo = _db.ApplicationUsers.FirstOrDefault(c => c.Id == user.Id);
            if (userInfo == null)
            {
                return NotFound();
            }
            userInfo.Name = user.Name;
            userInfo.Surname = user.Surname;
            userInfo.PhoneNumber = user.PhoneNumber;
            userInfo.StreetAddress = user.StreetAddress;
            userInfo.Suburb = user.Suburb;
            userInfo.Complex = user.Complex;
            userInfo.City = user.City;
            userInfo.Province = user.Province;
            userInfo.PostalCode = user.PostalCode;
            var result = await _userManager.UpdateAsync(userInfo);
            if (result.Succeeded)
            {
                TempData["save"] = "User has been updated successfully";
                return RedirectToAction(nameof(Details));
            }
            return View(userInfo);
        }

        //GET Checkout actioin method

        public IActionResult Checkout()
        {
            return View();
        }

        //POST Checkout action method

        [HttpPost]
        [ValidateAntiForgeryToken]


        public async Task<IActionResult> Checkout(Order anOrder)
        {
            List<Books> books = HttpContext.Session.Get<List<Books>>("books");
            OrderDetails orderDetails = new OrderDetails();

            if (books!=null)
            {
               
                foreach (var book in books)
                {
                    orderDetails.BookId = book.Id;
                    orderDetails.UserId = _userManager.GetUserId(User);
                    anOrder.OrderDetails.Add(orderDetails);
                }
            }

            anOrder.OrderDate = DateTime.Now;

            anOrder.OrderNo = GetOrderNo();
            _db.Order.Add(anOrder);
            await _db.SaveChangesAsync();
            TempData["save"] = "Order successfully placed";
            HttpContext.Session.Set("books", new List<Books>());

            return Redirect("~/");

        }










        public string GetOrderNo()
        {
            int rowCount = _db.Order.ToList().Count()+1;
            return rowCount.ToString("000");
        }

        //public async Task<IActionResult> Details(string id)
        //{
        //    var user = _userManager.GetUserAsync(User);
        //    if (user == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(user);
        //}

       

        //Get UserInfo
        //public async Task<IActionResult> OnGetAsync()
        //{
        //    var user = await _userManager.GetUserAsync(User);
        //    if (user == null)
        //    {
        //        return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
        //    }

        //    var userName = await _userManager.GetUserNameAsync(user);
        //    var email = await _userManager.GetEmailAsync(user);

        //    var phoneNumber = await _userManager.GetPhoneNumberAsync(user);

        //    Username = userName;

        //    Input = new InputModel
        //    {
        //        Email = email,
        //        PhoneNumber = phoneNumber
        //    };

        //    IsEmailConfirmed = await _userManager.IsEmailConfirmedAsync(user);

        //    return Page();
        //}
    }
}
