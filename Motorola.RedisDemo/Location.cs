using System;
using System.Collections.Generic;
using System.Text;

namespace Motorola.RedisDemo
{
    public class Location
    {
        public Location()
        {
        }

        public Location(double latitude, double longitude)
            : this()
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }


    public class Vehicle
    {
        public Vehicle()
        {
        }

        public Vehicle(string name, Location location)
            : this()
        {
            Name = name;
            Location = location;
        }

        public string Name { get; set; }
        public Location Location { get; set; }
    }
}
