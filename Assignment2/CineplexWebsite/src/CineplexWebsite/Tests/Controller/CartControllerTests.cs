using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using CineplexWebsite.Controllers;
using CineplexWebsite.Models;
using CineplexWebsite.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace CineplexWebsite.Tests.Controller
{
    public class CartControllerTests
    {

        private readonly CartController _sut;
        private readonly Mock<ISessionRepository> _sessionRepositoryMock;

        public CartControllerTests()
        {
            _sessionRepositoryMock = new Mock<ISessionRepository>();

            _sut = new CartController(_sessionRepositoryMock.Object);
        }

        [Fact]
        public void Index_NothingInTheCart_ReturnViewWithEmptyCart()
        {
            //Arrange
            _sessionRepositoryMock.Setup(s => s.Get<ICollection<MovieSessionModel>>(It.IsAny<string>()))
                .Returns(new List<MovieSessionModel>());

            //Act
            var result = _sut.Index() as ViewResult;
            var model = (List<MovieSessionModel>)result.Model;
            //Assert
            Assert.True(model.Count == 0);
        }

        [Fact]
        public void Delete_ItemsAreInTheCart_ReturnsStatusOk()
        {
            //Arrange
            var sessionToDelete = Guid.NewGuid();
            var sessionToKeep = Guid.NewGuid();

            _sessionRepositoryMock.Setup(s => s.Get<ICollection<MovieSessionModel>>(It.IsAny<string>()))
                .Returns(new List<MovieSessionModel>
                {
                    new MovieSessionModel
                    {
                        SessionId = sessionToDelete
                    },
                    new MovieSessionModel
                    {
                        SessionId = sessionToKeep
                    }
                });

            //Act
            var result = _sut.Delete(sessionToDelete) as OkResult;
            //Assert
            Assert.True(result.StatusCode == (int) HttpStatusCode.OK);
        }
    }
}
