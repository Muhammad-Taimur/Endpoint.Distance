using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Newtonsoft.Json;
using System.Text;
using System;
using Endpoint.Distance.Models;
using FluentAssertions;

namespace Endpoint.Distance.IntegrationTest
{
    public class DistanceMeasureControllerIntegrationTest
    {
        private HttpClient _httpClient;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            var webApplicationFactory = new WebApplicationFactory<Program>();
            _httpClient = webApplicationFactory.CreateDefaultClient();
        }

        [Test]
        public async Task DistanceMeasureControllerApiTest_ReturnsOk_WithResult()
        {
            //Arrange
            var twoCitiesCordinates = new TwoCitiesCordinates
            {
                longitude1 = 53.297975,
                latitude1 = -6.372663,
                longitude2 = 41.385101,
                latitude2 = -81.440440
            };
            
            var json = JsonConvert.SerializeObject(twoCitiesCordinates);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            
            //Act
            var response = await _httpClient.PostAsync("/api/measuredistance",data);
            var result = await response.Content.ReadAsStringAsync();

            //Assert
            result.Should().NotBeNullOrEmpty();
            result.Should().BeEquivalentTo("8368.152583373927 km");
        }
    }
}