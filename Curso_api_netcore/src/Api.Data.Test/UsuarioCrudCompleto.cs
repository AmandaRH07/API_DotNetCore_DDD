using System;
using System.Threading.Tasks;
using Api.Data.Context;
using Api.Data.Implamentations;
using Api.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Api.Data.Test
{
    public class UsuarioCrudCompleto : BaseTest, IClassFixture<DbTeste>
    {
        private ServiceProvider _serviceProvider;

        public UsuarioCrudCompleto(DbTeste dbTeste)
        {
            _serviceProvider = dbTeste.ServiceProvider;
        }

        [Fact(DisplayName = "CRUD de Usuário")]
        [Trait("CRUD", "UserEntity")]
        public async Task E_Possivel_Realizar_CRUD_Usuario()
        {
            using(var context = _serviceProvider.GetService<MyContext>())
            {
                UserImplementation _repositorio = new UserImplementation(context);
                UserEntity _entity = new UserEntity(){
                    Email = Faker.Internet.Email(),
                    Name = Faker.Name.FullName()
                };

                var _registroCriado = await _repositorio.InsertAsync(_entity);
                Assert.NotNull(_registroCriado);
                Assert.Equal(_entity.Email, _registroCriado.Email);
                Assert.Equal(_entity.Name, _registroCriado.Name);
                Assert.False(_registroCriado.Id == Guid.Empty);
            }
        }
    }
}

