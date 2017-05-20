using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CineplexWebsite.Repositories.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CineplexWebsite.Controllers
{
    [Produces("application/json")]
    public class SearchSessionController : Controller
    {
        private IMovieSessionRepository _movieSessionRepository;

        public SearchSessionController(
            IMovieSessionRepository movieSessionRepository)
        {
            _movieSessionRepository = movieSessionRepository;
        }

        [HttpGet]
        [Route("api/SessionSearch/movie/{movieTitle}")]
        public ActionResult Movie(string movieTitle)
        {
            var sessions = _movieSessionRepository.GetSessionsByMovieTitle(movieTitle);
            return new JsonResult(sessions);
        }

        [HttpGet]
        [Route("api/SessionSearch/cinema/{cinemaName}")]
        public ActionResult Cinema(string cinemaName)
        {
            var sessions = _movieSessionRepository.GetSessionsByCinema(cinemaName);
            return new JsonResult(sessions);
        }
    }

}