
using AutoMapper;
using Cores.Entities;
using Microsoft.Extensions.Configuration;

namespace Cores.Helpers
{
    public class ProductUrlResolver : IValueResolver<Product, ProductDto, string>
    {
        private readonly IConfiguration _configuration;

        public ProductUrlResolver(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string Resolve(Product source, ProductDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.PictureUrl))
            {
                return _configuration["ApiUrl"]+source.PictureUrl;
            }
            else
            {
                return null;
            }
        }
    }
}
