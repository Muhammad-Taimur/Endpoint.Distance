using AutoFixture;
using Endpoint.Distance.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Endpoint.Distance.Services.Implementation;

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

    }
}
