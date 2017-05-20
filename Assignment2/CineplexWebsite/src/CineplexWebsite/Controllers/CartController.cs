using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CineplexWebsite.Models;
using CineplexWebsite.Extensions;
using CineplexWebsite.Repositories;
using CineplexWebsite.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace CineplexWebsite.Controllers
{
    public class CartController : Controller
    {
        private readonly ISessionRepository _sessionRepository;

        public CartController(ISessionRepository sessionRepository)
        {
            _sessionRepository = sessionRepository;
        }

        public IActionResult Index()
        {
            var moviesCheckedout = _sessionRepository.Get<ICollection<MovieSessionModel>>("sessions-cart");
            return View(moviesCheckedout);
        }

        public IActionResult Delete([FromBody] Guid sessionToDelete)
        {
            var existingSessions = _sessionRepository.Get<ICollection<MovieSessionModel>>("sessions-cart");
            _sessionRepository.Remove("sessions-cart");
            var newSessions = existingSessions.Where(s => s.SessionId != sessionToDelete).ToList();
            _sessionRepository.Set<ICollection<MovieSessionModel>>("sessions-cart", newSessions);
            return Ok();
        }
    }
}