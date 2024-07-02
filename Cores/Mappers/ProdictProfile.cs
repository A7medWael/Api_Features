using AutoMapper;
using Cores.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cores.Mappers
{
    public class ProdictProfile:Profile
    {
        public ProdictProfile()
        {
         CreateMap<Product,AddProduct>().ReverseMap();
        }
    }
}
