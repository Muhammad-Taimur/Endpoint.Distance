using Endpoint.Distance.Models;

namespace Endpoint.Distance.Services.Implementation
{
    public class CalculateDistanceService : ICalculateDistanceService
    {
        public double CalculateDistance(TwoCitiesCordinates twoCitiesCordinates)
        {
            double result;

            // Convert coordinates to radians
            double latARad = twoCitiesCordinates.latitude1 * Math.PI / 180;
            double lonARad = twoCitiesCordinates.longitude1 * Math.PI / 180;
            double latBRad = twoCitiesCordinates.latitude2 * Math.PI / 180;
            double lonBRad = twoCitiesCordinates.longitude2* Math.PI / 180;

            // Calculate the distance between the two points
            double a = Math.PI / 2 - latBRad;
            double b = Math.PI / 2 - latARad;
            double phi = lonARad - lonBRad;
            double cosC = Math.Cos(a) * Math.Cos(b) + Math.Sin(a) * Math.Sin(b) * Math.Cos(phi);
            double c = Math.Acos(cosC);

            return result = 6371 * c; // Radius of Earth = 6371 km
        }
    }
}
