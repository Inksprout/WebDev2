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
    public class MovieComingSoonsController : Controller
    {
        private readonly CineplexContext _context;

        public MovieComingSoonsController(CineplexContext context)
        {
            _context = context;    
        }

        // GET: MovieComingSoons
        public async Task<IActionResult> Index()
        {
            return View(await _context.MovieComingSoon.ToListAsync());
        }

        // GET: MovieComingSoons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieComingSoon = await _context.MovieComingSoon.SingleOrDefaultAsync(m => m.MovieComingSoonId == id);
            if (movieComingSoon == null)
            {
                return NotFound();
            }

            return View(movieComingSoon);
        }

        // GET: MovieComingSoons/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MovieComingSoons/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MovieComingSoonId,ImageUrl,LongDescription,ShortDescription,Title")] MovieComingSoon movieComingSoon)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movieComingSoon);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(movieComingSoon);
        }

        // GET: MovieComingSoons/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieComingSoon = await _context.MovieComingSoon.SingleOrDefaultAsync(m => m.MovieComingSoonId == id);
            if (movieComingSoon == null)
            {
                return NotFound();
            }
            return View(movieComingSoon);
        }

        // POST: MovieComingSoons/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MovieComingSoonId,ImageUrl,LongDescription,ShortDescription,Title")] MovieComingSoon movieComingSoon)
        {
            if (id != movieComingSoon.MovieComingSoonId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movieComingSoon);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieComingSoonExists(movieComingSoon.MovieComingSoonId))
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
            return View(movieComingSoon);
        }

        // GET: MovieComingSoons/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieComingSoon = await _context.MovieComingSoon.SingleOrDefaultAsync(m => m.MovieComingSoonId == id);
            if (movieComingSoon == null)
            {
                return NotFound();
            }

            return View(movieComingSoon);
        }

        // POST: MovieComingSoons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movieComingSoon = await _context.MovieComingSoon.SingleOrDefaultAsync(m => m.MovieComingSoonId == id);
            _context.MovieComingSoon.Remove(movieComingSoon);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool MovieComingSoonExists(int id)
        {
            return _context.MovieComingSoon.Any(e => e.MovieComingSoonId == id);
        }
    }
}
