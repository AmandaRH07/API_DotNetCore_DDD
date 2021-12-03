using Domain.Dtos.Municipio;
using Domain.Interface.Services;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Api.Service.Test.Município
{
    public class QuandoForExecutadoGet : MunicipioTestes
    {
        private IMunicipioService _municipioService;
        private Mock<IMunicipioService> _serviceMock;

        [Fact(DisplayName = "É possível executar Método Get.")]
        public async Task E_Possivel_Executar_Metodo_Get_Ok()
        {
            _serviceMock = new Mock<IMunicipioService>();
            _serviceMock.Setup(m => m.Get(IdMunicipio)).ReturnsAsync(municipioDto);
            _municipioService = _serviceMock.Object;

            var result = await _municipioService.Get(IdMunicipio);
            Assert.NotNull(result);
            Assert.True(result.Id==IdMunicipio);
            Assert.Equal(NomeMunicipio, result.Nome);
            Assert.Equal(CodigoIBGEMunicipio, result.CodIBGE);
        }

        [Fact(DisplayName = "Método Get não retorna nenhum valor")]
        public async Task E_Possivel_Executar_Metodo_Get_Error()
        {
            _serviceMock = new Mock<IMunicipioService>();
            _serviceMock.Setup(m => m.Get(It.IsAny<Guid>())).Returns(Task.FromResult((MunicipioDto)null));
            _municipioService = _serviceMock.Object;

            var record = await _municipioService.Get(Guid.NewGuid());
            Assert.Null(record);
        }
    }
}
