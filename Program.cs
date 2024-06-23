
using ApiDemoo.Extentions;
using ApiDemoo.MiddleWares;
using Cores.Interfaces;
using Cores.Mappers;
using Infrastructure.Data.Implementation;
using Infrastructures.Data;
using Infrastructures.Data.Implementation;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;

namespace ApiDemoo
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<ApplicationDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("Default")));
            builder.Services.AddSingleton<IConnectionMultiplexer>(config =>
            {
                var configuration = ConfigurationOptions.Parse(builder.Configuration.GetConnectionString("Redis"), true);
                return ConnectionMultiplexer.Connect(configuration);
            });
            builder.Services.AddControllers();
            builder.Services.AddAppServices();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

             var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var service = scope.ServiceProvider;
                var loggerfactory = service.GetRequiredService<ILoggerFactory>();
                try
                {
                    var context = service.GetRequiredService<ApplicationDbContext>();
                    await context.Database.MigrateAsync();
                    await StoreDbContextSeed.seedAsync(context, loggerfactory);
                }
                catch (Exception ex)
                {
                    var logger = loggerfactory.CreateLogger<Program>();
                    logger.LogError(ex, "error ecured while seeding Data!!");
                }
            }
            //Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
              
            }
            

            app.UseHttpsRedirection();

            app.UseAuthorization();
  app.UseMiddleware<ExpetionMiddleWares>();

            app.MapControllers();

            app.Run();
        }
    }
}
