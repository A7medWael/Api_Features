using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cores.Entities
{
    public class AddProduct
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string? PictureUrl { get; set; }
       
        public int ProductTypeId { get; set; }
        
        public int ProductBrandId { get; set; }
    }
}
