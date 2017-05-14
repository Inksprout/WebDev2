using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CineplexWebsite.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CineplexWebsite.Controllers
{
    [Produces("application/json")]
    public class SearchSessionController : Controller
    {
        private ISearchService _searchService;

        public SearchSessionController(
            ISearchService searchService)
        {
            _searchService = searchService;
        }

        [HttpGet]
        [Route("api/SessionSearch/movie/{movieTitle}")]
        public ActionResult Movie(string movieTitle)
        {
            var sessions = _searchService.GetSessionsByMovieTitle(movieTitle);
            return new JsonResult(sessions);
        }

        [HttpGet]
        [Route("api/SessionSearch/cinema/{cinemaName}")]
        public ActionResult Cinema(string cinemaName)
        {
            var sessions = _searchService.GetSessionsByCinema(cinemaName);
            return new JsonResult(sessions);
        }
    }

}