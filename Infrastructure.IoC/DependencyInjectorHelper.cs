using Domain.Model.Interfaces.Infrastructure;
using Domain.Model.Interfaces.Repositores;
using Domain.Model.Interfaces.Services;
using Domain.Services.Services;
using Infrastructure.Data.Context;
using Infrastructure.Data.Repositories;
using Infrastructure.Services.Blob;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.IoC
{
   public class DependencyInjectorHelper
    {
        public static void Register(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AzureContext>(options =>
                    options.UseSqlServer(configuration.GetConnectionString("AzureContext")));

            services.AddScoped<IJogoRepository, JogoRepository>();

            services.AddScoped<IJogoService, JogoService>();
        }


    }
}
