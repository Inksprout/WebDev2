using System.Collections.Generic;
using System.Linq;
using CineplexWebsite.Models;
using CineplexWebsite.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace CineplexWebsite.Repositories
{
    public class MovieSessionRepository : IMovieSessionRepository
    {
        private readonly CineplexContext _context;

        public MovieSessionRepository(CineplexContext context)
        {
            _context = context;
        }

        public ICollection<MovieSession> GetSessionsByMovieTitle(string movieTitle)
        {

          var returnedSessionsQuery =  from m in _context.Movie
                from s in EntityFrameworkQueryableExtensions.Include<MovieSession, Movie>(_context.MovieSession, s => s.Movie).Include(s => s.Cineplex)
                                  where m.Title.Contains(movieTitle) &&
                      s.MovieId == m.MovieId
                select s;

            return Enumerable.ToList<MovieSession>(returnedSessionsQuery);
        }

        public ICollection<MovieSession> GetSessionsByCinema(string cinema)
        {

            var returnedSessionsQuery = from c in _context.Cineplex
                from s in EntityFrameworkQueryableExtensions.Include<MovieSession, Movie>(_context.MovieSession, s => s.Movie).Include(s => s.Cineplex)
                where c.Location.Contains(cinema) &&
                      c.CineplexId == s.CineplexId
                select s;

            return Enumerable.ToList<MovieSession>(returnedSessionsQuery);
        }
    }
}
