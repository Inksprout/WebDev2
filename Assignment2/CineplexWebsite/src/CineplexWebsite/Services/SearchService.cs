using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CineplexWebsite.Models;
using CineplexWebsite.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Newtonsoft.Json;

namespace CineplexWebsite.Services
{
    public class SearchService : ISearchService
    {
        private readonly CineplexContext _context;

        public SearchService(CineplexContext context)
        {
            _context = context;
        }

        public ICollection<MovieSession> GetSessionsByMovieTitle(string movieTitle)
        {

          var returnedSessionsQuery =  from m in _context.Movie
                from s in _context.MovieSession.Include(s => s.Movie).Include(s => s.Cineplex)
                                  where m.Title.Contains(movieTitle) &&
                      s.MovieId == m.MovieId
                select s;

            return returnedSessionsQuery.ToList();
        }

        public ICollection<MovieSession> GetSessionsByCinema(string cinema)
        {

            var returnedSessionsQuery = from c in _context.Cineplex
                from s in _context.MovieSession.Include(s => s.Movie).Include(s => s.Cineplex)
                where c.Location.Contains(cinema) &&
                      c.CineplexId == s.CineplexId
                select s;

            return returnedSessionsQuery.ToList();
        }
    }
}
