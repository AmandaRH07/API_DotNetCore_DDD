using Api.Data.Context;
using Data.Implamentations;
using Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Api.Data.Test
{
    public class CepCrud : BaseTest, IClassFixture<DbTeste>
    {
        private ServiceProvider _serviceProvider;

        public CepCrud(DbTeste dbTeste)
        {
            _serviceProvider = dbTeste.ServiceProvider;
        }

        [Fact(DisplayName = "CRUD de Cep")]
        [Trait("CRUD", "CepEntity")]
        public async Task E_Possivel_Realizar_Crud_Cep()
        {
            using (var context = _serviceProvider.GetService<MyContext>())
            {
                MunicipioImplementation _repositorioMunicipio = new MunicipioImplementation(context);
                MunicipioEntity _entityMunicipio = new MunicipioEntity
                {
                    Nome = Faker.Address.City(),
                    CodIBGE = Faker.RandomNumber.Next(1000000, 9999999),
                    UfId = new Guid("e7e416de-477c-4fa3-a541-b5af5f35ccf6")
                };

                var _registroCriadoMunicipio = await _repositorioMunicipio.InsertAsync(_entityMunicipio);
                Assert.NotNull(_registroCriadoMunicipio);
                Assert.Equal(_entityMunicipio.Nome, _registroCriadoMunicipio.Nome);
                Assert.Equal(_entityMunicipio.CodIBGE, _registroCriadoMunicipio.CodIBGE);
                Assert.Equal(_entityMunicipio.UfId, _registroCriadoMunicipio.UfId);
                Assert.False(_registroCriadoMunicipio.Id == Guid.Empty);

                CepImplementation _repositorioCep = new CepImplementation(context);
                CepEntity _entityCep = new CepEntity
                {
                    Cep = "12365-478",
                    Logradouro = Faker.Address.StreetName(),
                    Numero = "0 até 2000",
                    MunicipioId =_registroCriadoMunicipio.Id
                };

                var _registroCriadoCep = await _repositorioCep.InsertAsync(_entityCep);
                Assert.NotNull(_registroCriadoCep);
                Assert.Equal(_entityCep.Cep, _registroCriadoCep.Cep);
                Assert.Equal(_entityCep.Logradouro, _registroCriadoCep.Logradouro);
                Assert.Equal(_entityCep.Numero, _registroCriadoCep.Numero);
                Assert.Equal(_entityCep.MunicipioId, _registroCriadoCep.MunicipioId);
                Assert.False(_registroCriadoCep.Id == Guid.Empty);

                _entityCep.Logradouro = Faker.Address.StreetName();
                _entityCep.Id = _registroCriadoCep.Id;
                var _registroAtualizado = await _repositorioCep.UpdateAsync(_entityCep);
                Assert.NotNull(_registroAtualizado);
                Assert.Equal(_entityCep.Cep, _registroAtualizado.Cep);
                Assert.Equal(_entityCep.Logradouro, _registroAtualizado.Logradouro);
                Assert.Equal(_entityCep.Numero, _registroAtualizado.Numero);
                Assert.Equal(_entityCep.MunicipioId, _registroAtualizado.MunicipioId);
                Assert.True(_registroCriadoCep.Id == _entityCep.Id);

                var _registroExiste = await _repositorioCep.ExistsAsync(_registroAtualizado.Id);
                Assert.True(_registroExiste);

                var _registroSelecionado = await _repositorioCep.SelectAsync(_registroAtualizado.Id);
                Assert.NotNull(_registroSelecionado);
                Assert.Equal(_entityCep.Cep, _registroSelecionado.Cep);
                Assert.Equal(_entityCep.Logradouro, _registroSelecionado.Logradouro);
                Assert.Equal(_entityCep.Numero, _registroSelecionado.Numero);
                Assert.Equal(_entityCep.MunicipioId, _registroSelecionado.MunicipioId);

                _registroSelecionado = await _repositorioCep.SelectAsync(_registroAtualizado.Cep);
                Assert.NotNull(_registroSelecionado);
                Assert.Equal(_entityCep.Cep, _registroSelecionado.Cep);
                Assert.Equal(_entityCep.Logradouro, _registroSelecionado.Logradouro);
                Assert.Equal(_entityCep.Numero, _registroSelecionado.Numero);
                Assert.Equal(_entityCep.MunicipioId, _registroSelecionado.MunicipioId);
                Assert.NotNull(_registroSelecionado.Municipio);
                Assert.NotNull(_registroSelecionado.Municipio.Uf);

                var _todosRegistros = await _repositorioCep.SelectAsync();
                Assert.NotNull(_todosRegistros);
                Assert.True(_todosRegistros.Count() > 0);

                var _removeu = await _repositorioCep.DeleteAsync(_registroSelecionado.Id);
                Assert.True(_removeu);

                _todosRegistros = await _repositorioCep.SelectAsync();
                Assert.NotNull(_todosRegistros);
                Assert.True(_todosRegistros.Count() == 0);
            }
        }
    }
}
