using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookMarket.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookMarket.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class RequestController : Controller
    {
        private ApplicationDbContext _db;
        private IHostingEnvironment _he;

        public RequestController(ApplicationDbContext db, IHostingEnvironment he)
        {
            _db = db;
            _he = he;
        }
        public IActionResult Index()
        {
            return View(_db.Requests.Include(c => c.User).ToList());
        }
    }
}