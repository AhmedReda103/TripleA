using Microsoft.Extensions.Configuration;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TripleA.Service.Abstracts;

namespace TripleA.Service.implementations
{
    public class CashingService : ICashingService
    {
        private IDatabase _cashDB;
        public CashingService(IConfiguration configuration)
        {
            var redis = ConnectionMultiplexer.Connect(configuration.GetSection("CashingConnectionString:redisConnection").Value);
            _cashDB = redis.GetDatabase();
        }
        public async Task<T> GetData<T>(string key)
        {
            var value = await _cashDB.StringGetAsync(key);
            if (!string.IsNullOrEmpty(value))
                return JsonSerializer.Deserialize<T>(value);
            return default(T);
        }

        public async Task<bool> setData<T>(string key, T value, TimeSpan expiryTime)
        {
            return await _cashDB.StringSetAsync(key, JsonSerializer.Serialize(value), expiryTime);
        }

        public async Task<bool> removeData(string key)
        {
            var isExist = await _cashDB.KeyExistsAsync(key);
            if (isExist)
                return await _cashDB.KeyDeleteAsync(key);
            return false;
        }
    }
}
