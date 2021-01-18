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
    public class OrdersController : Controller
    {
        private ApplicationDbContext _db;
        private IHostingEnvironment _he;
        public OrdersController(ApplicationDbContext db, IHostingEnvironment he)
        {
            _db = db;
            _he = he;
           
        }
        public IActionResult Index()
        {
            var orders = _db.OrderDetails.Include(c => c.Order).Include(f => f.Book).Include(z => z.User).ToList();
            if (orders == null)
            {
                return NotFound();
            }
            return View(orders);



            //var result = from ur in _db.OrderDetails
            //             join r in _db.Order on ur.OrderId equals r.Id
            //             join W in _db.Books on ur.BookId equals W.Id
            //             join a in _db.ApplicationUsers on ur.UserId equals a.Id
            //             select new OrderDetails()
            //             {
            //                 UserId = ur.UserId,
            //                 OrderId = ur.OrderId,
            //                 BookId=ur.BookId,


            //             };
            //ViewBag.OrderDetails = result;
            //return View();
        }
       
        //Get Delete Action Method
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var order = _db.OrderDetails.Include(c => c.Order).Include(c => c.Book).Include(c => c.User).Where(c => c.Id == id).FirstOrDefault();
            if (order == null)
            {
                return NotFound();
            }
            return View(order);
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
            var order = _db.OrderDetails.FirstOrDefault(c => c.Id == id);
            if (order == null)
            {
                return NotFound();
            }

            _db.Remove(order);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}