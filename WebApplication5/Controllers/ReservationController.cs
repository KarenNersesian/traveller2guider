using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication5.DAL;
using System.Threading.Tasks;
using WebApplication5.Services;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    public class ReservationController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private GuiderService guiderService = new GuiderService();

        // GET: Reservation
        public async Task<ActionResult> Index(string guiderId)
        {
            var guider = guiderService.GetGuider(guiderId);

            return View("Index");
        }
    }
}