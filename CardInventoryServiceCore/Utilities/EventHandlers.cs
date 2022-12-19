using Newtonsoft.Json;
using StackExchange.Redis;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Threading.Channels;
using IDatabase = StackExchange.Redis.IDatabase;

namespace CardInventoryServiceCore.Utilities
{
    public class EventHandlers
    {
        // Create a connection to the Redis server
        ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("localhost:6379");
        private const string Channel = "providus-channel";
        public string Publish<T>(T model)
        {
            var puSub = redis.GetSubscriber();
            //IDatabase db = redis.GetDatabase();

            string message = JsonConvert.SerializeObject(model);
            puSub.Publish(Channel, message, CommandFlags.FireAndForget);
            return $"Message Successfully sent to {Channel}";
        }
    }
}