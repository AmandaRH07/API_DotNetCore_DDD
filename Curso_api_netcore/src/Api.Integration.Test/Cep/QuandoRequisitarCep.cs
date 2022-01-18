using Domain.Dtos.Cep;
using Domain.Dtos.Municipio;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Api.Integration.Test.Cep
{
    public class QuandoRequisitarCep : BaseIntegration
    {
        [Fact]
        public async Task E_Possivel_Realizar_Consulta_Cep()
        {
            await AdicionarToken();

            //Post Municipio
            var municipioDtoCreate = new MunicipioDtoCreate()
            {
                Nome = "São Paulo",
                CodIBGE = 3550308,
                UfId = new Guid("e7e416de-477c-4fa3-a541-b5af5f35ccf6")
            };

            var response = await PostJsonAsync(municipioDtoCreate, $"{hostApi}/municipios", client);
            var postResult = await response.Content.ReadAsStringAsync();
            var registroPostMuncipio = JsonConvert.DeserializeObject<MunicipioDtoCreateResult>(postResult);

            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            Assert.Equal("São Paulo", registroPostMuncipio.Nome);
            Assert.Equal(3550308, registroPostMuncipio.CodIBGE);
            Assert.True(registroPostMuncipio.Id != default(Guid));

            //Post
            var cepDtoCreate = new CepDtoCreate()
            {
                Cep = "12345-678",
                Logradouro = "Rua Teste",
                Numero = "123",
                MunicipioId = registroPostMuncipio.Id
            };

            response = await PostJsonAsync(cepDtoCreate, $"{hostApi}/cep", client);
            postResult = await response.Content.ReadAsStringAsync();
            var registroPost = JsonConvert.DeserializeObject<CepDtoCreateResult>(postResult);

            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            Assert.Equal(cepDtoCreate.Cep, registroPost.Cep);
            Assert.Equal(cepDtoCreate.Logradouro, registroPost.Logradouro);
            Assert.Equal(cepDtoCreate.Numero, registroPost.Numero);
            Assert.True(registroPost.Id != default(Guid));

            //Put
            var updateCepDto = new CepDtoUpdate()
            {
                Id = registroPost.Id,
                Cep = "87654-321",
                Logradouro = "Rua Teste 2",
                Numero = "321",
                MunicipioId = new Guid("e7e416de-477c-4fa3-a541-b5af5f35ccf6")
            };

            var stringContent = new StringContent(JsonConvert.SerializeObject(updateCepDto), Encoding.UTF8, "application/json");
            response = await client.PutAsync($"{hostApi}/cep/", stringContent);
            var jsonResult = await response.Content.ReadAsStringAsync();
            var registroAtualizado = JsonConvert.DeserializeObject<CepDtoUpdateResult>(jsonResult);

            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            Assert.Equal(updateCepDto.Cep, registroAtualizado.Cep);
            Assert.Equal(updateCepDto.Logradouro, registroAtualizado.Logradouro);
            Assert.Equal(updateCepDto.Numero, registroAtualizado.Numero);

            // Get by ID
            response = await client.GetAsync($"{hostApi}/cep/{registroAtualizado.Id}");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            jsonResult = await response.Content.ReadAsStringAsync();
            var registroSelecionado = JsonConvert.DeserializeObject<CepDto>(jsonResult);
            Assert.NotNull(registroSelecionado);
            Assert.Equal(registroSelecionado.Cep, registroAtualizado.Cep);
            Assert.Equal(registroSelecionado.Logradouro, registroAtualizado.Logradouro);
            Assert.Equal(registroSelecionado.Numero, registroAtualizado.Numero);

            // Get by CEP
            response = await client.GetAsync($"{hostApi}/cep/byCep/{registroAtualizado.Cep}");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            jsonResult = await response.Content.ReadAsStringAsync();
            var registroSelecionadoCompletoCEP = JsonConvert.DeserializeObject<CepDto>(jsonResult);
            Assert.NotNull(registroSelecionadoCompletoCEP);
            Assert.Equal(registroSelecionadoCompletoCEP.Cep, registroAtualizado.Cep);
            Assert.Equal(registroSelecionadoCompletoCEP.Logradouro, registroAtualizado.Logradouro);
            Assert.Equal(registroSelecionadoCompletoCEP.Numero, registroAtualizado.Numero);
            
            // Delete
            response = await client.GetAsync($"{hostApi}/cep/{registroSelecionado.Id}");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            // Get by ID delete
            response = await client.GetAsync($"{hostApi}/cep/{registroSelecionado.Id}");
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}
