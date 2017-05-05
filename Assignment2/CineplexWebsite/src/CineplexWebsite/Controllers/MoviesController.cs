using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CineplexWebsite.Models;
using Newtonsoft.Json;

namespace CineplexWebsite.Controllers
{
    public class MoviesController : Controller
    {
        private readonly CineplexContext _context;

        public MoviesController(CineplexContext context)
        {
            _context = context;
        }

        // GET: Movies
        public async Task<IActionResult> Index()
        {
            var movies = await _context.Movie.ToListAsync();
            var moviesComingSoon = await _context.MovieComingSoon.ToListAsync();
            return View(new MoviesViewModel
            {
                Movies = movies,
                MoviesComingSoon = moviesComingSoon
            });
        }

        // GET: Movies/Details/5
        public async Task<IActionResult> Search(string id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var movies = _context.Movie.Where(m => m.Title.Contains(id) || m.ShortDescription.Contains(id));

            return new JsonResult(movies);
        }
    }
}
