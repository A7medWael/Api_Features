using ApiDemoo.ResponseMedule;
using Cores.Interfaces;
using Cores.Mappers;
using Infrastructure.Data.Implementation;
using Infrastructures.Data.Implementation;
using Microsoft.AspNetCore.Mvc;

namespace ApiDemoo.Extentions
{
    public static class ApplicationServiceExtention
    {
        public static IServiceCollection AddAppServices(this IServiceCollection services)
        {
            services.AddScoped<IproductRepository, productRepository>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddAutoMapper(prof => prof.AddProfile(new ProdictProfile()));
            services.AddAutoMapper(prof => prof.AddProfile(new MappingProfile()));
            services.AddScoped<IBasketReposatory, BasketReposatory>();
            services.Configure<ApiBehaviorOptions>(opt => opt.InvalidModelStateResponseFactory = actionContext =>
            {
                var errors = actionContext.ModelState.Where(e => e.Value.Errors.Count > 0).
                SelectMany(e => e.Value.Errors).Select(e => e.ErrorMessage).ToArray();
                var errorrespone = new ApiValidationErrorResponse
                {
                    Errors = errors
                };
                return new BadRequestObjectResult(errorrespone);
            }); 
            return services;
        }
    }
}
