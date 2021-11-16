using Domain.Dtos.Uf;
using Domain.Interface.Services.Uf;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Api.Service.Test.Uf
{
    public class QuandoForExecutadoGet : UfTestes
    {
        private IUfService _ufService;

        private Mock<IUfService> _serviceMock;

        [Fact(DisplayName = "É possível Executar método GET")]
        public async Task E_Possivel_Executar_Metodo_Get()
        {
            _serviceMock = new Mock<IUfService>();
            _serviceMock.Setup(m => m.Get(IdUf)).ReturnsAsync(ufDto);
            _ufService = _serviceMock.Object;

            var result = await _ufService.Get(IdUf);
            Assert.NotNull(result);
            Assert.True(result.Id == IdUf);
            Assert.Equal(Nome, result.Nome);

            _serviceMock = new Mock<IUfService>();
            _serviceMock.Setup(m => m.Get(It.IsAny<Guid>())).Returns(Task.FromResult((UfDto)null));
            _ufService = _serviceMock.Object;

            var _record = await _ufService.Get(IdUf);
            Assert.Null(_record);
        }
    }
}
