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
    public class CineplexesController : Controller
    {
        private readonly CineplexContext _context;

        public CineplexesController(CineplexContext context)
        {
            _context = context;    
        }

        // GET: Cineplexes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Cineplex.ToListAsync());
        }

        // GET: Cineplexes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cineplex = await _context.Cineplex.SingleOrDefaultAsync(m => m.CineplexId == id);
            if (cineplex == null)
            {
                return NotFound();
            }

            return View(cineplex);
        }

        // GET: Cineplexes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cineplexes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CineplexId,ImageUrl,Location,LongDescription,ShortDescription")] Cineplex cineplex)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cineplex);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(cineplex);
        }

        // GET: Cineplexes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cineplex = await _context.Cineplex.SingleOrDefaultAsync(m => m.CineplexId == id);
            if (cineplex == null)
            {
                return NotFound();
            }
            return View(cineplex);
        }

        // POST: Cineplexes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CineplexId,ImageUrl,Location,LongDescription,ShortDescription")] Cineplex cineplex)
        {
            if (id != cineplex.CineplexId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cineplex);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CineplexExists(cineplex.CineplexId))
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
            return View(cineplex);
        }

        // GET: Cineplexes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cineplex = await _context.Cineplex.SingleOrDefaultAsync(m => m.CineplexId == id);
            if (cineplex == null)
            {
                return NotFound();
            }

            return View(cineplex);
        }

        // POST: Cineplexes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cineplex = await _context.Cineplex.SingleOrDefaultAsync(m => m.CineplexId == id);
            _context.Cineplex.Remove(cineplex);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool CineplexExists(int id)
        {
            return _context.Cineplex.Any(e => e.CineplexId == id);
        }
    }
}
