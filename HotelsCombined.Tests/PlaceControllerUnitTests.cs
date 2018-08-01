using System;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using HotelsCombined;
using HotelsCombined.Controllers;
using HotelsCombined.Domain;
using Microsoft.AspNetCore.Mvc;

namespace HotelsCombined.Tests
{
    [TestClass]
    public class PlaceControllerUnitTests
    {

        private Mock<IPlaceRepository> _placeRepositoryMock;
        private PlaceController _placeController;
        private Mock<Controller> _baseControllerMock;
        private Place _place;

        [TestInitialize]
        public void Initialise()
        {
            _placeRepositoryMock = new Mock<IPlaceRepository>();
        }

        [TestMethod]
        public void GetDomainByNameReturnDataOk()
        {
            _placeRepositoryMock.Setup(x => x.Get(It.IsAny<string>())).Returns(new Place());

            _placeController = new PlaceController(_placeRepositoryMock.Object);

            var response = _placeController.GetDomainByName("Tokyo");

            var okResult = response as OkObjectResult;

            Assert.IsNotNull(okResult);
            Assert.AreEqual((int)HttpStatusCode.OK, okResult.StatusCode);


        }
    }
}
