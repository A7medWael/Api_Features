using Cores.Entities;
using Cores.Interfaces;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Infrastructures.Data.Implementation
{
    public class BasketReposatory : IBasketReposatory
    {
        private readonly IDatabase _database;
        public BasketReposatory(IConnectionMultiplexer Redis)
        {
            _database=Redis.GetDatabase();
        }
        public async Task DeleteBusketAsync(string BasketId) => await _database.KeyDeleteAsync(BasketId);


        public async Task<CustomerBusket> GetBusketAsync(string BasketId)
        {
          var data=  await _database.StringGetAsync(BasketId);
            return data.IsNullOrEmpty ? null : JsonSerializer.Deserialize<CustomerBusket>(data);
        }

        public async Task<CustomerBusket> UpdateBusketAsync(CustomerBusket busket)
        {
            var created = await _database.StringSetAsync(busket.Id, JsonSerializer.Serialize(busket), TimeSpan.FromDays(30));
            if (!created)
                return null;
            return await GetBusketAsync(busket.Id);
        }
    }
}
