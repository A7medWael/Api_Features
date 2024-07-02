using Cores.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cores.Interfaces
{
    public interface IproductRepository:IGenericRepository<Product>
    {
        //Task<Product> GetProductbyIdAsync(int? id);
        //Task<IReadOnlyList<Product>> GetProductAsync();
        //Task<IReadOnlyList<ProductBrand>> GetBrandAsync();
        //Task<IReadOnlyList<ProductType>> GetTypeAsync();
    }
}
