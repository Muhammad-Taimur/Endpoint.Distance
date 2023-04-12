using Endpoint.Distance.Models;
using Endpoint.Distance.Services;
using Microsoft.AspNetCore.Mvc;

namespace Endpoint.Distance.Controllers
{
    [ApiController]
    public class DistanceMeasureController : Controller
    {
        private readonly ICalculateDistanceService _calculateDistanceService;
        public DistanceMeasureController(ICalculateDistanceService calculateDistanceService)
        {
            _calculateDistanceService = calculateDistanceService ?? throw new ArgumentNullException(nameof(calculateDistanceService));
        }

        [HttpPost]
        [Route("api/measuredistance")]
        public async Task<ActionResult> CalculateDistance([FromBody] TwoCitiesCordinates twoCitiesCordinates)
        {
            var distance =_calculateDistanceService.CalculateDistance(twoCitiesCordinates);
            return Ok($"{distance} km");
        }
    }
}