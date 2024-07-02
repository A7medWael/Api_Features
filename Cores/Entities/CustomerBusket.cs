using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cores.Entities
{
    public class CustomerBusket
    {
        public CustomerBusket( string id)
        {
            Id = id;
        }
        public string Id { get; set; }
        public int DelivaryMethod { get; set; }
        public decimal ShippingPrice { get; set; }
        public List<BasketItem> BasketItems { get; set; } = new List<BasketItem>();
    }
}
