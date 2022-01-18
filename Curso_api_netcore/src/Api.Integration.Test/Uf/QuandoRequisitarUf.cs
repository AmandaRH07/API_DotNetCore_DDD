using Domain.Dtos.Municipio;
using Domain.Dtos.Uf;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Api.Integration.Test.Uf
{
    public class QuandoRequisitarUf: BaseIntegration
    { 
        [Fact]
        public async Task E_Possivel_Realizar_Consulta_Ufs()
        {
            await AdicionarToken();

            //Get All
            response = await client.GetAsync($"{hostApi}/ufs");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var jsonResult = await response.Content.ReadAsStringAsync();
            var listaFromJson = JsonConvert.DeserializeObject<IEnumerable<UfDto>>(jsonResult);
            Assert.NotNull(listaFromJson);
            Assert.True(listaFromJson.Count() == 27);
            Assert.True(listaFromJson.Where(s => s.Sigla == "SP").Count() == 1);

            // Get by ID
            var id = listaFromJson.Where(r => r.Sigla == "SP").FirstOrDefault().Id;
            response = await client.GetAsync($"{hostApi}/ufs/{id}");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            jsonResult = await response.Content.ReadAsStringAsync();
            var registroSelecionado = JsonConvert.DeserializeObject<UfDto>(jsonResult);
            Assert.NotNull(registroSelecionado);
            Assert.Equal("São Paulo", registroSelecionado.Nome);
            Assert.Equal("SP", registroSelecionado.Sigla);
        }
    }
}
