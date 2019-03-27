using Bogus;
using StackExchange.Redis;
using System;
using System.Linq;
using System.Threading;

namespace Motorola.RedisDemo
{
    class Program
    {

        // add package StackExchange.Redis

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            ConnectionTest();

            AddGeoTest();

            Console.WriteLine("Press any key to exit.");

            Console.ReadKey();
        }

        private static void AddGeoTest()
        {
            var location = new Location(50.066360, 19.970300);

            var key = "locations";

            // add package Bogus

            var locationFaker = new Faker<Location>()
                .RuleFor(p => p.Latitude, f => f.Address.Latitude(50.5, 50.6))
                .RuleFor(p => p.Longitude, f => f.Address.Longitude(19.5, 19.7));

            var locations = locationFaker.GenerateLazy(100);

            var vehicleFaker = new Faker<Vehicle>()
                .RuleFor(p => p.Name, f => $"Vehicle{f.IndexFaker}")
                .RuleFor(p => p.Location, f => f.PickRandom(locations));

            var vehicles = vehicleFaker.Generate(10);

            GeoEntry[] geoEntries = vehicles
                .Select(v => new GeoEntry(v.Location.Longitude, v.Location.Latitude, v.Name))
                .ToArray();

            using (ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("localhost"))
            {
                IDatabase db = redis.GetDatabase();
                
                db.KeyDelete(key, CommandFlags.FireAndForget);

                db.GeoAdd(key, location.Longitude, location.Latitude, "vehicleA");
                db.GeoAdd(key, location.Longitude + 5, location.Latitude + 3, "vehicleB");

                db.GeoAdd(key, geoEntries);

                double? distance = db.GeoDistance(key, "Vehicle1", "Vehicle3", GeoUnit.Kilometers);

                Console.WriteLine($"Distance: {distance} km");

                // redis-cli georadius locations 0 0 22000 km

                var results = 
                    db.GeoRadius(key, 0, 0, 22000, 
                    GeoUnit.Kilometers, 100, 
                    Order.Ascending, 
                    GeoRadiusOptions.WithDistance);

                foreach (var result in results)
                {
                    Console.WriteLine($"{result.Member} distance = {result.Distance} km");
                }


            }



        }

        private static void ConnectionTest()
        {
            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("localhost");

            // ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("server1:6379,server2:6379");

            // docker run --name my-redis - d - p 6379:6379 redis

            string key = "abc";

            // select 
            IDatabase db = redis.GetDatabase();
            db.StringSet(key, "Foo");

            string value = db.StringGet(key);


        }

        private static void TtlTest()
        {
            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("localhost");

            // ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("server1:6379,server2:6379");

            // docker run --name my-redis - d - p 6379:6379 redis

            string key = "abc";

            // select 
            IDatabase db = redis.GetDatabase();
            db.StringSet(key, "Foo", TimeSpan.FromSeconds(10));

            TimeSpan? ttl = db.KeyTimeToLive(key);

            Thread.Sleep(TimeSpan.FromSeconds(11));

            string value = db.StringGet(key);


        }
    }
}
