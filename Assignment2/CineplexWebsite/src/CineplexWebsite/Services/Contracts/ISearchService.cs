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
        Task<IActionResult> GetSessionsByMovieTitle(string movieTitle);
        Task<IActionResult> GetSessionsByCinema(string cinema);
    }
}
