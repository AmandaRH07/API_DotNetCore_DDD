using Domain.Interface.Services;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace Api.Service.Test.Município
{
    public class QuandoForExecutadoCreate : MunicipioTestes
    {

        private IMunicipioService _municipioService;
        private Mock<IMunicipioService> _serviceMock;

        [Fact(DisplayName = "É possível executar Método Create.")]
        public async Task E_Possivel_Executar_Metodo_Create()
        {
            _serviceMock = new Mock<IMunicipioService>();
            _serviceMock.Setup(m => m.Post(municipioDtoCreate)).ReturnsAsync(municipioDtoCreateResult);
            _municipioService = _serviceMock.Object;

            var result = await _municipioService.Post(municipioDtoCreate);
            Assert.NotNull(result);
            Assert.Equal(NomeMunicipio, result.Nome);
            Assert.Equal(CodigoIBGEMunicipio, result.CodIBGE);
            Assert.Equal(IdUf, result.UfId);
        }
    }
}
