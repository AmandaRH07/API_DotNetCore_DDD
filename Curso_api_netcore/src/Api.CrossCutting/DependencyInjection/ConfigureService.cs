using Api.Domain.Interface.Services.Users;
using Api.Service.Services;
using Domain.Interface.Services;
using Domain.Interface.Services.Cep;
using Domain.Interface.Services.Uf;
using Microsoft.Extensions.DependencyInjection;
using Service.Services;

namespace Api.CrossCutting.DependencyInjection
{
    public class ConfigureService
    {
        public static void ConfigureDependenciesService(IServiceCollection serviceCollection){
            serviceCollection.AddTransient<IUserService, UserService> ();
            serviceCollection.AddTransient<ILoginService, LoginService> ();
            
            serviceCollection.AddTransient<IUfService, UfService> ();
            serviceCollection.AddTransient<IMunicipioService, MunicipioService> ();
            serviceCollection.AddTransient<ICepService, CepService> ();

        }
    }
}