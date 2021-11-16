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
    public class QuandoForExecutadoGetAll : UfTestes
    {
        private IUfService _ufService;

        private Mock<IUfService> _serviceMock;

        [Fact(DisplayName = "É possível Executar método GET ALL")]
        public async Task E_Possivel_Executar_Metodo_Get_All()
        {
            _serviceMock = new Mock<IUfService>();
            _serviceMock.Setup(m => m.GetAll()).ReturnsAsync(listaUfDto);
            _ufService = _serviceMock.Object;

            var result = await _ufService.GetAll();
            Assert.NotNull(result);
            Assert.True(result.Count() == 10);

            var _listResult = new List<UfDto>();

            _serviceMock = new Mock<IUfService>();
            _serviceMock.Setup(m => m.GetAll()).ReturnsAsync(_listResult.AsEnumerable);
            _ufService = _serviceMock.Object;

            var _resultEmpty = await _ufService.GetAll();
            Assert.Empty(_resultEmpty);
            Assert.True(_resultEmpty.Count() == 0);
        }
    }
}
