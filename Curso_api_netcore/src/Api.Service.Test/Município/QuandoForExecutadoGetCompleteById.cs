using Domain.Interface.Services;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace Api.Service.Test.Município
{
    public class QuandoForExecutadoGetCompleteById : MunicipioTestes
    {
        private IMunicipioService _municipioService;
        private Mock<IMunicipioService> _serviceMock;

        [Fact(DisplayName = "É possível executar Método Get Complete By Id.")]
        public async Task E_Possivel_Executar_Metodo_Get_Complete_By_Id_Ok()
        {
            _serviceMock = new Mock<IMunicipioService>();
            _serviceMock.Setup(m => m.GetCompleteById(IdMunicipio)).ReturnsAsync(municipioDtoCompleto);
            _municipioService = _serviceMock.Object;

            var result = await _municipioService.GetCompleteById(IdMunicipio);
            Assert.NotNull(result);
            Assert.True(result.Id == IdMunicipio);
            Assert.Equal(NomeMunicipio, result.Nome);
            Assert.Equal(CodigoIBGEMunicipio, result.CodIBGE);
            Assert.NotNull(result.Uf);
        }
    }
}
