using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CineplexWebsite.Models;

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

            var movieSession = await _context.MovieSession.SingleOrDefaultAsync(m => m.MovieSessionId == id);
            if (movieSession == null)
            {
                return NotFound();
            }

            return View(movieSession);
        }

        // GET: MovieSessions/Create
        public IActionResult Create()
        {
            ViewData["CineplexId"] = new SelectList(_context.Cineplex, "CineplexId", "Location");
            ViewData["MovieId"] = new SelectList(_context.Movie, "MovieId", "LongDescription");
            return View();
        }

        // POST: MovieSessions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MovieSessionId,CineplexId,MovieId,SessionTime")] MovieSession movieSession)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movieSession);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["CineplexId"] = new SelectList(_context.Cineplex, "CineplexId", "Location", movieSession.CineplexId);
            ViewData["MovieId"] = new SelectList(_context.Movie, "MovieId", "LongDescription", movieSession.MovieId);
            return View(movieSession);
        }

        // GET: MovieSessions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieSession = await _context.MovieSession.SingleOrDefaultAsync(m => m.MovieSessionId == id);
            if (movieSession == null)
            {
                return NotFound();
            }
            ViewData["CineplexId"] = new SelectList(_context.Cineplex, "CineplexId", "Location", movieSession.CineplexId);
            ViewData["MovieId"] = new SelectList(_context.Movie, "MovieId", "LongDescription", movieSession.MovieId);
            return View(movieSession);
        }

        // POST: MovieSessions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MovieSessionId,CineplexId,MovieId,SessionTime")] MovieSession movieSession)
        {
            if (id != movieSession.MovieSessionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movieSession);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieSessionExists(movieSession.MovieSessionId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            ViewData["CineplexId"] = new SelectList(_context.Cineplex, "CineplexId", "Location", movieSession.CineplexId);
            ViewData["MovieId"] = new SelectList(_context.Movie, "MovieId", "LongDescription", movieSession.MovieId);
            return View(movieSession);
        }

        // GET: MovieSessions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieSession = await _context.MovieSession.SingleOrDefaultAsync(m => m.MovieSessionId == id);
            if (movieSession == null)
            {
                return NotFound();
            }

            return View(movieSession);
        }

        // POST: MovieSessions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movieSession = await _context.MovieSession.SingleOrDefaultAsync(m => m.MovieSessionId == id);
            _context.MovieSession.Remove(movieSession);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool MovieSessionExists(int id)
        {
            return _context.MovieSession.Any(e => e.MovieSessionId == id);
        }
    }
}
