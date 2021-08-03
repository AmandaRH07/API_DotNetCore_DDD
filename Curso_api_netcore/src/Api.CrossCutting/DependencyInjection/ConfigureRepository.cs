using System;
using Api.Data.Context;
using Api.Data.Implamentations;
using Api.Data.Repository;
using Api.Domain.Interface;
using Api.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Api.CrossCutting.DependencyInjection
{
    public class ConfigureRepository
    {
        public static void ConfigureDependenciesRepository(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            serviceCollection.AddScoped<IUserRepository, UserImplementation>();

             if (Environment.GetEnvironmentVariable("DATABASE").ToLower() == "SQLSERVER".ToLower())
            {
                serviceCollection.AddDbContext<MyContext>(
                    options => options.UseSqlServer(Environment.GetEnvironmentVariable("DB_CONNECTION"))
                );
            }
        }
    }
}