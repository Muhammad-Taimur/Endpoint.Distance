using AutoFixture;
using Endpoint.Distance.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Endpoint.Distance.Models;
using Endpoint.Distance.Services.Implementation;
using FluentAssertions;

namespace Endpoint.Distance.UnitTest.Services
{
    internal class CalculateDistanceServiceTest
    {
        private CalculateDistanceService _sut;
        private Fixture _fixture;

        [SetUp]
        public void SetUp()
        {
            _fixture = new Fixture();
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior());
            _sut = new CalculateDistanceService();
        }

        [Test]
        public void CalculateDistance_ReturnsResult()
        {
            //Arrange
            var twoCitiesCordinates = _fixture.Build<TwoCitiesCordinates>()
                .With(x => x.latitude1, 53.297975)
                .With(x => x.longitude1, -6.372663)
                .With(x => x.latitude2, 41.385101)
                .With(x => x.longitude2, -81.440440)
                .Create();

            //Act
            var result = _sut.CalculateDistance(twoCitiesCordinates);

            //Assert
            result.Should().Be(5536.3386822666853);
        }

    }
}
