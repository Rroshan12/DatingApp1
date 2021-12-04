using Application.Activities;
using Application.core;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Persistence;

namespace API.Extensions
{
    public static class  AppilcationServiceExtensions
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services,
         IConfiguration config)
        {
             services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
            });
            services.AddDbContext<Datacontext>(opt =>{
                opt.UseSqlite(config.GetConnectionString("DefaultConnection"));

            });
           services.AddMediatR(typeof(List.Handler).Assembly);
           services.AddAutoMapper(typeof(MappingProfiles).Assembly);
           services.AddCors(); 

           return services;

        }
        
    }
}