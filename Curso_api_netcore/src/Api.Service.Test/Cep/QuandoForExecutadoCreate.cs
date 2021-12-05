using Domain.Interface.Services.Cep;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace Api.Service.Test.Cep
{
    public class QuandoForExecutadoCreate : CepTestes
    {
        private ICepService _cepService;
        private Mock<ICepService> _serviceMock;

        [Fact(DisplayName = "É possível executar Método Create")]
        public async Task E_Possivel_Executar_Metodo_Create()
        {
            _serviceMock = new Mock<ICepService>();
            _serviceMock.Setup(c => c.Post(cepDtoCreate)).ReturnsAsync(cepDtoCreateResult);
            _cepService = _serviceMock.Object;

            var result = await _cepService.Post(cepDtoCreate);
            Assert.NotNull(result);
            Assert.Equal(CodCep, result.Cep);
            Assert.Equal(LogradouroCep, result.Logradouro);
            Assert.Equal(NumeroCep, result.Numero);
            Assert.Equal(IdMunicipio, result.MunicipioId);
        }
    }
}
