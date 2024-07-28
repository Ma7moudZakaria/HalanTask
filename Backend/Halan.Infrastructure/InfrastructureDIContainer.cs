using Halan.Application.Repositories;
using Halan.Infrastructure.Persistence;
using Halan.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Halan.Infrastructure
{
    public static class InfrastructureDIContainer
    {
        public static IServiceCollection AddInfrastructureDIContainer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ITicketRepository, TicketRepository>();

            services.AddDbContext<HalanDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddSwaggerGenerator();

            return services;
        }
    }

    public static class SwaggerExtensions
    {
        public static IServiceCollection AddSwaggerGenerator(this IServiceCollection services)
        {
            services.AddSwaggerGen(config =>
            {
                config.CustomSchemaIds(type => type.FullName.Replace("+", "_"));

                config.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Halan API",
                    Version = "v1"
                });

                config.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please insert JWT with Bearer into field (Add Space between Bearer and JWT Token)",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });

                config.AddSecurityRequirement(new OpenApiSecurityRequirement {
                   {
                     new OpenApiSecurityScheme
                     {
                       Reference = new OpenApiReference
                       {
                         Type = ReferenceType.SecurityScheme,
                         Id = "Bearer"
                       }
                      },
                      Array.Empty<string>()
                    }
                  });
            });

            return services;
        }
    }
}
