using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CineplexWebsite.Models;
using CineplexWebsite.Extensions;
using CineplexWebsite.Repositories;
using CineplexWebsite.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

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

            var deletedSession = false;
            foreach (var session in existingSessions)
            {
                if (session.SessionId == sessionToDelete)
                {
                    deletedSession = true;
                    break;
                }
            }
            if (deletedSession == true)
            {
                var newSessions = existingSessions.Where(s => s.SessionId != sessionToDelete).ToList();
                _sessionRepository.Set<ICollection<MovieSessionModel>>("sessions-cart", newSessions);
                return Ok();
            }
            _sessionRepository.Set<ICollection<MovieSessionModel>>("sessions-cart", existingSessions);
            return NotFound();
        }
    }
}