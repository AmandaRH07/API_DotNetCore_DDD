using Api.Domain.Dtos.User;
using Api.Domain.Interface.Services.Users;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Api.Service.Test.Usuario
{
    public class QuandoForExecutadoUpdate : UsuarioTestes
    {
        private IUserService _service;
        private Mock<IUserService> _serviceMock;

        [Fact(DisplayName = "Executar método Update")]
        public async Task E_Possivel_Executar_Metodo_Update()
        {
            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m => m.Post(userDtoCreate)).ReturnsAsync(userDtoCreateResult);
            _service = _serviceMock.Object;

            var result = await _service.Post(userDtoCreate);
            Assert.NotNull(result);
            Assert.Equal(NomeUsuario, result.Name);
            Assert.Equal(EmailUsuario, result.Email);

            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m => m.Put(userDtoUpdate)).ReturnsAsync(userDtoUpdateResult);
            _service = _serviceMock.Object;

            var resultUpdate = await _service.Put(userDtoUpdate);
            Assert.NotNull(resultUpdate);
            Assert.Equal(NomeUsuarioAlterado, resultUpdate.Name);
            Assert.Equal(EmailUsuarioAlterado, resultUpdate.Email);
        }
    }
}