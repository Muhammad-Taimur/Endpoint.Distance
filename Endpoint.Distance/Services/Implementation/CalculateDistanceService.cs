using Endpoint.Distance.Models;

namespace Endpoint.Distance.Services.Implementation
{
    public class CalculateDistanceService : ICalculateDistanceService
    {
        public double CalculateDistance(TwoCitiesCordinates twoCitiesCordinates)
        {
            //double latA = 40.7128; // latitude in degrees
            //double lonA = -74.0060; // longitude in degrees
            double result;

            //// Coordinates of point B
            //double latB = 51.5074; // latitude in degrees
            //double lonB = -0.1278; // longitude in degrees

            // Convert coordinates to radians
            double latARad = twoCitiesCordinates.latitude1 * Math.PI / 180;
            double lonARad = twoCitiesCordinates.longitude1 * Math.PI / 180;
            double latBRad = twoCitiesCordinates.latitude2 * Math.PI / 180;
            double lonBRad = twoCitiesCordinates.longitude2* Math.PI / 180;

            //double latARad = latA * Math.PI / 180;
            //double lonARad = lonA * Math.PI / 180;
            //double latBRad = latB * Math.PI / 180;
            //double lonBRad = lonB * Math.PI / 180;

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
