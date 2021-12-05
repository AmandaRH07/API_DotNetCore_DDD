using Domain.Interface.Services.Cep;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Api.Service.Test.Cep
{
    public class QuandoForExecutadoDelete : CepTestes
    {
        private ICepService _cepService;
        private Mock<ICepService> _serviceMock;

        [Fact(DisplayName = "É possível executar Método Delete")]
        public async Task E_Possivel_Executar_Metodo_Delete()
        {
            _serviceMock = new Mock<ICepService>();
            _serviceMock.Setup(c => c.Delete(IdCep)).ReturnsAsync(true);
            _cepService = _serviceMock.Object;

            var result = await _cepService.Delete(IdCep);
            Assert.True(result);

            _serviceMock = new Mock<ICepService>();
            _serviceMock.Setup(c => c.Delete(IdCep)).ReturnsAsync(false);
            _cepService = _serviceMock.Object;

            result = await _cepService.Delete(IdCep);
            Assert.False(result);
        }
    }
}
