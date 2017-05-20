﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CineplexWebsite.Models;
using CineplexWebsite.Services;
using CineplexWebsite.Services.Contracts;
using Moq;
using Xunit;

namespace CineplexWebsite.Tests.Services
{
    public class SearchServiceTests
    {
        private ISearchService _sut;
        private Mock<CineplexContext> _cineplexContextMock;

        public SearchServiceTests()
        {
            //Setup the mock CineplexContext
            _cineplexContextMock = new Mock<CineplexContext>();

           _sut = new SearchService(_cineplexContextMock.Object);
        }

        [Fact]
        public void GetSessionsByMovieTitle_ADefaultSession_ReturnsTwilightSession()
        {
            //Arrange


            //Act
            var result = _sut.GetSessionsByMovieTitle("fuck you m8");

            //Assert
          //  Assert.Equal(result, "twilight is on at 9 o clock");
        }
    }
}
