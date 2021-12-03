using Domain.Interface.Services;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace Api.Service.Test.Município
{
    public class QuandoForExecutadoUpdate : MunicipioTestes
    {

        private IMunicipioService _municipioService;
        private Mock<IMunicipioService> _serviceMock;

        [Fact(DisplayName = "É possível executar Método Update.")]
        public async Task E_Possivel_Executar_Metodo_Update()
        {
            _serviceMock = new Mock<IMunicipioService>();
            _serviceMock.Setup(m => m.Put(municipioDtoUpdate)).ReturnsAsync(municipioDtoUpdateResult);
            _municipioService = _serviceMock.Object;

            var resultUpdate = await _municipioService.Put(municipioDtoUpdate);
            Assert.NotNull(resultUpdate);
            Assert.Equal(NomeMunicipio, resultUpdate.Nome);
            Assert.Equal(CodigoIBGEMunicipio, resultUpdate.CodIBGE);
            Assert.Equal(IdUf, resultUpdate.UfId);
        }
    }
}
