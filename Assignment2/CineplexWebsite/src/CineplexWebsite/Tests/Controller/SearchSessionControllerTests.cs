using System.Collections.Generic;
using CineplexWebsite.Controllers;
using CineplexWebsite.Models;
using CineplexWebsite.Repositories;
using CineplexWebsite.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Newtonsoft.Json;
using Xunit;

namespace CineplexWebsite.Tests.Controller
{
    public class SearchSessionControllerTests
    {
        private readonly SearchSessionController _sut;
        private readonly Mock<IMovieSessionRepository> _movieSessionRepositoryMock;

        public SearchSessionControllerTests()
        {
            _movieSessionRepositoryMock = new Mock<IMovieSessionRepository>();

           _sut = new SearchSessionController(_movieSessionRepositoryMock.Object);
        }

        [Fact]
        public void SearchByMovieTitle_SearchedForAMovieInTheDatabaseWithMultipleEntries_ReturnsListOfMovieSessions()
        {
            //Arrange
            _movieSessionRepositoryMock.Setup(m => m.GetSessionsByMovieTitle(It.IsAny<string>()))
                .Returns(new List<MovieSession>
                {
                    new MovieSession(),
                    new MovieSession(),
                    new MovieSession()
                });

            //Act
            var result = _sut.SearchByMovieTitle("Twilight") as JsonResult;
            var listOfMovieSessions = (List<MovieSession>)result.Value;
            //Assert
            Assert.True(listOfMovieSessions.Count == 3);
        }

        [Fact]
        public void SearchByCinemaName_SearchedForAMovieInTheDatabaseWithMultipleEntries_ReturnsListOfMovieSessions()
        {
            //Arrange
            _movieSessionRepositoryMock.Setup(m => m.GetSessionsByCinema(It.IsAny<string>()))
                .Returns(new List<MovieSession>
                {
                    new MovieSession(),
                    new MovieSession(),
                });

            //Act
            var result = _sut.SearchByCinemaName("St Kilda") as JsonResult;
            var listOfMovieSessions = (List<MovieSession>)result.Value;
            //Assert
            Assert.True(listOfMovieSessions.Count == 2);
        }
    }
}
