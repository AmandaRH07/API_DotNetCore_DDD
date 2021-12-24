using Api.Data.Context;
using Api.Data.Implamentations;
using Api.Data.Repository;
using Api.Domain.Interface;
using Api.Domain.Repository;
using Data.Implamentations;
using Domain.Repository;
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

            serviceCollection.AddScoped<IUfRepository, UfImplementation>();
            serviceCollection.AddScoped<ICepRepository, CepImplementation>();
            serviceCollection.AddScoped<IMunicipioRepository, MunicipioImplementation>();


            serviceCollection.AddDbContext<MyContext>(
                options => options.UseSqlServer("Server= NT-04611\\SQLEXPRESS;Database=dbnetcoreapi;Trusted_Connection=True")
            );

        }
    }
}
