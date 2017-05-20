using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CineplexWebsite.Models;
using Microsoft.AspNetCore.Mvc;

namespace CineplexWebsite.Services.Contracts
{
    public interface ISearchService
    {
        ICollection<MovieSession> GetSessionsByMovieTitle(string movieTitle);
        ICollection<MovieSession> GetSessionsByCinema(string cinema);
    }
}
