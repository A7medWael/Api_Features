using Cores.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cores.Interfaces
{
    public interface IBasketReposatory
    {
        Task<CustomerBusket> GetBusketAsync(string BasketId);
        Task<CustomerBusket> UpdateBusketAsync(CustomerBusket busket);
        Task DeleteBusketAsync(string BasketId);

    }
}
