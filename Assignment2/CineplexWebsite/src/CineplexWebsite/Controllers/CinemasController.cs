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
    public class CinemasController : Controller
    {
        private readonly CineplexContext _context;

        public CinemasController(CineplexContext context)
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

    }
}
