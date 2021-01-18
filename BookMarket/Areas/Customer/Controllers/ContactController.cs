using BookMarket.Models;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BookMarket.Areas.Customer.Controllers
{
    public class ContactController : Controller
    {

        public IActionResult ContactMail()
        {
            return View();
        }
       
    }
}