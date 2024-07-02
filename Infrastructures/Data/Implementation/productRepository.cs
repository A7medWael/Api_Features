using Cores.Entities;
using Cores.Interfaces;
using Infrastructures.Data;
using Infrastructures.Data.Implementation;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Implementation
{
    public class productRepository : GenericRepository<Product>,IproductRepository
    {




        private readonly ApplicationDbContext _context;
        public productRepository(ApplicationDbContext context):base(context)
        {
            _context = context;
        }
        //public async Task<IReadOnlyList<ProductBrand>> GetBrandAsync()
        //{
        //   var prod = await _context.ProductBrands.ToListAsync();
        //    return prod;
        //}

        //public async Task<IReadOnlyList<Product>> GetProductAsync()
        //{
        //    var prod = await _context.Products.Include(pr => pr.ProductType).Include(p => p.ProductBrand).ToListAsync();
        //    return prod;
        //}

        //public async Task<Product> GetProductbyIdAsync(int? id)
        //{
        //    var prod = await _context.Products.FirstOrDefaultAsync(p=>p.Id == id); 
        //    return prod;
        //}

        //public async Task<IReadOnlyList<ProductType>> GetTypeAsync()
        //{
        //    var prod = await _context.ProductTypes.ToListAsync();
        //    return prod;
        //}
    }
}
