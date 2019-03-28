using System;
using System.ComponentModel.DataAnnotations;

namespace Motorola.MotoTaxi.Locations.DomainModels
{
    public class LocationResult
    {
        public LocationResult(string deviceId, Location location, double distance)
        {
            DeviceId = deviceId;
            Location = location;
            Distance = distance;
        }

        public string DeviceId { get; set; }
        public Location Location { get; set; }
        public double Distance { get; set; }

    }

    public class VehicleLocation
    {
        public VehicleLocation(string deviceId, Location location)
        {
            DeviceId = deviceId;
            Location = location;
        }

        [Required]
        public string DeviceId { get; set; }
        public Location Location { get; set; }
    }

    public class Location
    {
        public Location(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        [Required]
        public double Latitude { get; set; }

        [Required]
        public double Longitude { get; set; }        
    }


    
}
