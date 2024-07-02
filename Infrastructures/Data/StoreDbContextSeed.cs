using Cores.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Infrastructures.Data
{
    public class StoreDbContextSeed
    {
        public static async Task seedAsync(ApplicationDbContext dbContext, ILoggerFactory loggerf)
        {
            try
            {
                if (dbContext.ProductBrands != null && !dbContext.ProductBrands.Any())
                {
                    var branddata = File.ReadAllText("../Infrastructure/Data/SeedData/brands.json");
                    var brands = JsonSerializer.Deserialize<List<ProductBrand>>(branddata);
                    foreach (var brand in brands)
                        dbContext.ProductBrands.Add(brand);

                    await dbContext.SaveChangesAsync();


                }
                if (dbContext.ProductTypes != null && !dbContext.ProductTypes.Any())
                {
                    var productype = File.ReadAllText("../Infrastructure/Data/SeedData/types.json");
                    var prodtype = JsonSerializer.Deserialize<List<ProductType>>(productype);
                    foreach (var pro in prodtype)
                        dbContext.ProductTypes.Add(pro);

                    await dbContext.SaveChangesAsync();


                }
                if (dbContext.Products != null && !dbContext.Products.Any())
                {
                    var productdata = File.ReadAllText("../Infrastructure/Data/SeedData/products.json");
                    var prodct = JsonSerializer.Deserialize<List<Product>>(productdata);
                    foreach (var pro in prodct)
                        dbContext.Products.Add(pro);

                    await dbContext.SaveChangesAsync();


                }
            }

            catch (Exception ex)
            {
                var logger = loggerf.CreateLogger<StoreDbContextSeed>();
                logger.LogError(ex.Message);
            }

        }
    }
}
