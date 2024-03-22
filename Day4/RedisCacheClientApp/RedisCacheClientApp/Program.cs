
using StackExchange.Redis;

string connectionString = "testday4redisks2024.redis.cache.windows.net:6380,password=AaCY7z9FY98ygqCJfZTdjSEChpcQrwdQXAzCaJYbSIE=,ssl=True,abortConnect=False";

ConnectionMultiplexer redis = ConnectionMultiplexer.Connect(connectionString);



void GetCacheData()
{
    IDatabase database = redis.GetDatabase();
    if (database.KeyExists("message"))
        Console.WriteLine(database.StringGet("message"));
    else
        Console.WriteLine("key does not exist");

}
void SetCacheData(string key, string value)
{
    IDatabase database = redis.GetDatabase();

    database.StringSet(key, value);

    Console.WriteLine("Cache data set");
}
GetCacheData();
//SetCacheData("message2", "in day4");
Console.WriteLine("End");
