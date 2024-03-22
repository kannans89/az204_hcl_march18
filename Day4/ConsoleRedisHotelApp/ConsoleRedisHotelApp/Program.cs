using StackExchange.Redis;
using System;
using System.Collections.Generic;

class Program
{
    static ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("testday4redisks2024.redis.cache.windows.net:6380,password=AaCY7z9FY98ygqCJfZTdjSEChpcQrwdQXAzCaJYbSIE=,ssl=True,abortConnect=False");
    static IDatabase db = redis.GetDatabase();

    static void Main(string[] args)
    {
        Console.Write("Enter hotel location: ");
        string location = Console.ReadLine();

        List<string> hotels = GetHotels(location);

        foreach (string hotel in hotels)
        {
            Console.WriteLine(hotel);
        }
    }

    static List<string> GetHotels(string location)
    {
        string cacheKey = "hotels:" + location;
        string hotelsData = db.StringGet(cacheKey);

        if (hotelsData != null)
        {
            Console.WriteLine("Cache hit");
            return Deserialize(hotelsData);
        }
        else
        {
            Console.WriteLine("Cache miss");
            List<string> hotels = GenerateHotels(location); // Replace with real data source
            db.StringSet(cacheKey, Serialize(hotels), TimeSpan.FromHours(1));
            return hotels;
        }
    }

    static List<string> GenerateHotels(string location)
    {
        // Mock method to generate a list of hotels for a location
        // Replace with a call to a real API or database
        return new List<string> { $"{location} :Hotel 1", $"{location} :Hotel 2", $"{location} :Hotel 3" };
    }

    static string Serialize(List<string> data)
    {
        // Simple serialization method
        // Replace with a real serialization method if needed
        return string.Join(",", data);
    }

    static List<string> Deserialize(string data)
    {
        // Simple deserialization method
        // Replace with a real deserialization method if needed
        return new List<string>(data.Split(','));
    }
}