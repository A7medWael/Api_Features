using Cores.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cores.DToS
{
    public class CustomerDto
    {
        public string Id { get; set; }
        public int DelivaryMethod { get; set; }
        public decimal ShippingPrice { get; set; }
        public List<BasketItemDto> BasketItems { get; set; } = new List<BasketItemDto>();
    }
}
