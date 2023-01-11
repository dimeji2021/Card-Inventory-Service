using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardInventoryServiceDomain.Core.Utilities
{
    public class Publisher
    {
        // Create a connection to the Redis server
        ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("localhost:6379,abortConnect=false");
        private const string Channel = "providus-channel";
        public void Publish<T>(T model)
        {
            var puSub = redis.GetSubscriber();
            string message = JsonConvert.SerializeObject(model);
            puSub.PublishAsync(Channel, message, CommandFlags.FireAndForget);
        }
    }
}
