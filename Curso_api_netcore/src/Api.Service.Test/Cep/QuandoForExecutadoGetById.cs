using Domain.Dtos.Cep;
using Domain.Interface.Services.Cep;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Api.Service.Test.Cep
{
    public class QuandoForExecutadogetById : CepTestes
    {
        private ICepService _cepService;
        private Mock<ICepService> _serviceMock;

        [Fact(DisplayName = "É possível executar Método Get By Id")]
        public async Task E_Possivel_Executar_Metodo_Get_By_Id()
        {
            _serviceMock = new Mock<ICepService>();
            _serviceMock.Setup(c => c.Get(IdCep)).ReturnsAsync(cepDto);
            _cepService = _serviceMock.Object;

            var result = await _cepService.Get(IdCep);
            Assert.NotNull(result);
            Assert.True(result.Id == IdCep);
            Assert.Equal(CodCep, result.Cep);
            Assert.Equal(LogradouroCep, result.Logradouro);
            Assert.Equal(NumeroCep, result.Numero);
            Assert.Equal(IdMunicipio, result.MunicipioId);
        }

        [Fact(DisplayName = "Método Get não retorna nenhum valor")]
        public async Task E_Possivel_Executar_Metodo_Get_Error()
        {
            _serviceMock = new Mock<ICepService>();
            _serviceMock.Setup(m => m.Get(It.IsAny<Guid>())).Returns(Task.FromResult((CepDto)null));
            _cepService = _serviceMock.Object;

            var record = await _cepService.Get(Guid.NewGuid());
            Assert.Null(record);
        }
    }
}
