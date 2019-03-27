using StackExchange.Redis;
using System;
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
