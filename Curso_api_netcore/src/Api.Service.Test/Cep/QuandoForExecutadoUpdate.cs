using Domain.Interface.Services.Cep;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace Api.Service.Test.Cep
{
    public class QuandoForExecutadoUpdate : CepTestes
    {
        private ICepService _cepService;
        private Mock<ICepService> _serviceMock;

        [Fact(DisplayName = "É possível executar Método Update")]
        public async Task E_Possivel_Executar_Metodo_Update()
        {
            _serviceMock = new Mock<ICepService>();
            _serviceMock.Setup(c => c.Put(cepDtoUpdate)).ReturnsAsync(cepDtoUpdateResult);
            _cepService = _serviceMock.Object;

            var result = await _cepService.Put(cepDtoUpdate);
            Assert.NotNull(result);
            Assert.Equal(CodCep, result.Cep);
            Assert.Equal(LogradouroCep, result.Logradouro);
            Assert.Equal(NumeroCep, result.Numero);
            Assert.Equal(IdMunicipio, result.MunicipioId);
        }
    }
}
