using Domain.Dtos.Municipio;
using Domain.Interface.Services;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Api.Service.Test.Município
{
    public class QuandoForExecutadoGetAll : MunicipioTestes
    {
        private IMunicipioService _municipioService;
        private Mock<IMunicipioService> _serviceMock;

        [Fact(DisplayName = "É possível executar Método Get All.")]
        public async Task E_Possivel_Executar_Metodo_Get_All_Ok()
        {
            _serviceMock = new Mock<IMunicipioService>();
            _serviceMock.Setup(m => m.GetAll()).ReturnsAsync(listaDto);
            _municipioService = _serviceMock.Object;

            var result = await _municipioService.GetAll();
            Assert.NotNull(result);
            Assert.True(result.Count() == 10);
        }

        [Fact(DisplayName = "Método Get não retorna nenhum valor")]
        public async Task E_Possivel_Executar_Metodo_Get_All_Error()
        {
            var _listaResult = new List<MunicipioDto>();
            _serviceMock = new Mock<IMunicipioService>();
            _serviceMock.Setup(m => m.GetAll()).ReturnsAsync(_listaResult);
            _municipioService = _serviceMock.Object;

            var result = await _municipioService.GetAll();
            Assert.NotNull(result);
            Assert.True(result.Count() == 0);
        }
    }
}
