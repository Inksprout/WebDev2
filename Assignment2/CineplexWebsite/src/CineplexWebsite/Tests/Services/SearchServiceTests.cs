using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CineplexWebsite.Services;
using CineplexWebsite.Services.Contracts;
using Xunit;

namespace CineplexWebsite.Tests.Services
{
    public class SearchServiceTests
    {
        private ISearchService _sut;

        public SearchServiceTests()
        {
           //_sut = new SearchService();
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
