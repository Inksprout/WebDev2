using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CineplexWebsite.Models;
using CineplexWebsite.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace CineplexWebsite.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            var moviesCheckedout = HttpContext.Session.Get<ICollection<MovieSessionModel>>("sessions-cart");
            return View(moviesCheckedout);
        }

        public IActionResult Delete([FromBody] Guid sessionToDelete)
        {
            var existingSessions = HttpContext.Session.Get<ICollection<MovieSessionModel>>("sessions-cart");
            HttpContext.Session.Remove("sessions-cart");
            var newSessions = existingSessions.Where(s => s.SessionId != sessionToDelete).ToList();
            HttpContext.Session.Set<ICollection<MovieSessionModel>>("sessions-cart", newSessions);
            return Ok();
        }
    }
}