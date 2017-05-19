using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CineplexWebsite.Models;
using Microsoft.AspNetCore.Http;
using CineplexWebsite.Extensions;

namespace CineplexWebsite.Controllers
{
    public class MovieSessionsController : Controller
    {
        private readonly CineplexContext _context;

        public MovieSessionsController(CineplexContext context)
        {
            _context = context;
        }

        // GET: MovieSessions
        public async Task<IActionResult> Index()
        {
            var cineplexContext = _context.MovieSession.Include(m => m.Cineplex).Include(m => m.Movie);
            return View(await cineplexContext.ToListAsync());
        }

        // GET: MovieSessions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieSession = await _context.MovieSession.FirstOrDefaultAsync(m => m.MovieSessionId == id);
            var movie = await _context.Movie.FirstOrDefaultAsync(m => m.MovieId == movieSession.MovieId);
            var cineplex = await _context.Cineplex.FirstOrDefaultAsync(c => c.CineplexId == movieSession.CineplexId);

            return View(new MovieSessionDetailViewModel
            {
                MovieSession = movieSession,
                Movie = movie,
                Cineplex = cineplex
            });
        }

        public async Task<IActionResult> Save([FromBody] MovieSessionModel movieSession)
        {

            movieSession.SessionId = Guid.NewGuid();
            var existingSession = HttpContext.Session.Get<ICollection<MovieSessionModel>>("sessions-cart") ?? new List<MovieSessionModel>();
            HttpContext.Session.Remove("sessions-cart");
            existingSession.Add(movieSession);
            HttpContext.Session.Set<ICollection<MovieSessionModel>>("sessions-cart", existingSession);
            return Ok();
        }
    }
}
