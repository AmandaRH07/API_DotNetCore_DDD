using Api.Domain.Dtos.User;
using Api.Domain.Interface.Services.Users;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Api.Service.Test.Usuario
{
    public class QuandoForExecutadoDelete : UsuarioTestes
    {
        private IUserService _service;
        private Mock<IUserService> _serviceMock;

        [Fact(DisplayName = "Executar método Delete")]
        public async Task E_Possivel_Executar_Metodo_Delete()
        {
            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m => m.Delete(It.IsAny<Guid>())).ReturnsAsync(true);
            _service = _serviceMock.Object;

            var deleted = await _service.Delete(IdUsuario);
            Assert.True(deleted);

            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m => m.Delete(It.IsAny<Guid>())).ReturnsAsync(false);
            _service = _serviceMock.Object;

            deleted = await _service.Delete(Guid.NewGuid());
            Assert.False(deleted);

        }
    }
}