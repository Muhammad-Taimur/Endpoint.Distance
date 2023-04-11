using AutoFixture;
using Endpoint.Distance.Controllers;
using Endpoint.Distance.Models;
using Endpoint.Distance.Services;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Endpoint.Distance.UnitTest.Controllers
{
    internal class DistanceMeasureControllerTest
    {
        private DistanceMeasureController _sut;
        private Fixture _fixture;
        private Mock<ICalculateDistanceService> _calculateDistance;

        [SetUp]
        public void SetUp()
        {
            _fixture = new Fixture();
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior());
            _calculateDistance = new Mock<ICalculateDistanceService>();
            _sut = new DistanceMeasureController(_calculateDistance.Object);
        }

        [Test]
        public async Task CalculateDistance_ReturnOk_WithCalculationResult()
        {
            //Arrange
            var twoCitiesCordinates = _fixture.Create<TwoCitiesCordinates>();
            var result = 26.560;

            _calculateDistance.Setup(x => x.CalculateDistance(twoCitiesCordinates))
                .Returns(result);

            //Act
            var response = await _sut.CalculateDistance(twoCitiesCordinates) as OkObjectResult;

            //Assert
            response.Should().BeOfType<OkObjectResult>();
            response.Value.Should().Be($"{result} km");
        }

    }
}
