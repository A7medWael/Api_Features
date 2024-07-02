using Azure;
using Cores.Interfaces;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Infrastructures.Serviceses
{
    public class ResponseCashService : IResponseCashService
    {
        private readonly IDatabase _database;
        public ResponseCashService(IConnectionMultiplexer redis)
        {
            
            _database=redis.GetDatabase();
        }
        public  async Task CashResponseAsync(string CashKey, string Response, TimeSpan TimeToLive)
        {
           if(Response is null)
                return;
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
            var  SerializedResponse=JsonSerializer.Serialize(Response, options);
            await _database.StringSetAsync(CashKey, SerializedResponse, TimeToLive);
        }

        public async Task<string> GetCashResponse(string CashKey)
        {
           var cashrespone=await _database.StringGetAsync(CashKey);
            if (cashrespone.IsNullOrEmpty)
                return null;
            return cashrespone;
        }
    }
}
