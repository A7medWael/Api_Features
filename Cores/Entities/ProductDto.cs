﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cores.Entities
{
    public class ProductDto
    {
      
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string? PictureUrl { get; set; }
        public string ProductType { get; set; }
        
        public string ProductBrand { get; set; }
       
    }
}
