using Motorola.MotoTaxi.Locations.DomainModels;
using Motorola.MotoTaxi.Locations.IServices;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Motorola.MotoTaxi.Locations.DbServices
{
    public class DbLocationService : ILocationService
    {
        private readonly IConnectionMultiplexer connection;
        private readonly IDatabase db;

        private const string key = "locations";

        public DbLocationService(IConnectionMultiplexer connection)
        {
            this.connection = connection;

            this.db = connection.GetDatabase();
        }

        public void Add(VehicleLocation location)
        {
            db.GeoAdd(key, location.Location.Longitude, location.Location.Latitude, location.DeviceId);
        }

        public IEnumerable<LocationResult> Get(Location location, double radius = 5, int quantity = 10)
        {
            var results = db.GeoRadius(key, location.Longitude, location.Latitude, radius,
                GeoUnit.Kilometers, quantity,
                   Order.Ascending, GeoRadiusOptions.WithDistance | GeoRadiusOptions.WithCoordinates);

            var locations = results.Select(p => new LocationResult(p.Member, 
                new Location(p.Position.Value.Latitude, p.Position.Value.Longitude), 
                p.Distance.Value)).ToList();

            return locations;

        }
    }
}
