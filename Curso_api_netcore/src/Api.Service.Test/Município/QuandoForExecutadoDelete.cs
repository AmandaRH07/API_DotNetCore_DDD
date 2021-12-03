using Domain.Interface.Services;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Api.Service.Test.Município
{
    public class QuandoForExecutadoDelete : MunicipioTestes
    {

        private IMunicipioService _municipioService;
        private Mock<IMunicipioService> _serviceMock;

        [Fact(DisplayName = "É possível executar Método Delete.")]
        public async Task E_Possivel_Executar_Metodo_Delete()
        {
            _serviceMock = new Mock<IMunicipioService>();
            _serviceMock.Setup(m => m.Delete(IdMunicipio)).ReturnsAsync(true);
            _municipioService = _serviceMock.Object;

            var resultDelete = await _municipioService.Delete(IdMunicipio);
            Assert.True(resultDelete);

            _serviceMock = new Mock<IMunicipioService>();
            _serviceMock.Setup(m => m.Delete(It.IsAny<Guid>())).ReturnsAsync(false);
            _municipioService = _serviceMock.Object;

            resultDelete = await _municipioService.Delete(It.IsAny<Guid>());
            Assert.False(resultDelete);
        }
    }
}
