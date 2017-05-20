using System.Collections.Generic;
using CineplexWebsite.Models;

namespace CineplexWebsite.Repositories.Contracts
{
    public interface IMovieSessionRepository
    {
        ICollection<MovieSession> GetSessionsByMovieTitle(string movieTitle);
        ICollection<MovieSession> GetSessionsByCinema(string cinema);
    }
}
