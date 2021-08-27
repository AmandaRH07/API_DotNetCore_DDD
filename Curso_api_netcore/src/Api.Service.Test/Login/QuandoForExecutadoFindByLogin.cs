using Api.Domain.Dtos;
using Api.Domain.Interface.Services.Users;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Api.Service.Test.Login
{
    public class QuandoForExecutadoFindByLogin
    {
        private ILoginService _service;
        private Mock<ILoginService> _serviceMock;

        [Fact(DisplayName = "É Possivel Executar Método FindByLogin")]
        public async Task E_Possivel_Executar_Metodo_FindByLogin()
        {
            var email = Faker.Internet.Email();
            var objetoRetorno = new
            {
                authenticated = true,
                createDate = DateTime.UtcNow,
                expirationDate = DateTime.UtcNow.AddHours(8),
                acessToken = Guid.NewGuid(),
                userName = email,
                name = Faker.Name.FullName(),
                message = "Usuário Logado com sucesso"
            };

            var loginDto = new LoginDto
            {
                Email = email
            };

            _serviceMock = new Mock<ILoginService>();
            _serviceMock.Setup(m => m.FindByLogin(loginDto)).ReturnsAsync(objetoRetorno);
            _service = _serviceMock.Object;

            var result = await _service.FindByLogin(loginDto);
            Assert.NotNull(result);

        }

    }
}
