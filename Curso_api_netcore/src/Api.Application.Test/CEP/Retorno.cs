using application.Controllers;
using Domain.Dtos.Cep;
using Domain.Dtos.Municipio;
using Domain.Interface.Services.Cep;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Api.Application.Test.CEP
{
    public class Retorno
    {
        private CepController _controller;

        #region Get
        [Fact(DisplayName = "É Possivel Realizar o Get.")]
        public async Task E_Possivel_Invocar_a_Controller_Get_BadRequest()
        {
            var serviceMock = new Mock<ICepService>();
            serviceMock.Setup(m => m.Get(It.IsAny<Guid>())).ReturnsAsync(
               new CepDto
               {
                   Id = Guid.NewGuid(),
                   Logradouro = "teste"
               });

            _controller = new CepController(serviceMock.Object);
            _controller.ModelState.AddModelError("Id", "FormatoInválido");

            var result = await _controller.Get(Guid.NewGuid());
            Assert.True(result is BadRequestObjectResult);
        }

        [Fact(DisplayName = "É Possivel Realizar o Get.")]
        public async Task E_Possivel_Invocar_a_Controller_Get_Ok()
        {
            var serviceMock = new Mock<ICepService>();
            serviceMock.Setup(m => m.Get(It.IsAny<Guid>())).ReturnsAsync(
                new CepDto
                {
                    Id = Guid.NewGuid(),
                    Logradouro = "teste"
                });

            _controller = new CepController(serviceMock.Object);

            var result = await _controller.Get(Guid.NewGuid());
            Assert.True(result is OkObjectResult);
        }

        [Fact(DisplayName = "É Possivel Realizar o Get.")]
        public async Task E_Possivel_Invocar_a_Controller_Get_Not_Found()
        {
            var serviceMock = new Mock<ICepService>();
            serviceMock.Setup(m => m.Get(It.IsAny<Guid>())).Returns(Task.FromResult((CepDto)null));

            _controller = new CepController(serviceMock.Object);

            var result = await _controller.Get(Guid.NewGuid());
            Assert.True(result is NotFoundResult);
        }
        #endregion

        #region Get Complete by ID
        [Fact(DisplayName = "É Possivel Realizar o Get.")]
        public async Task E_Possivel_Invocar_a_Controller_GetCompleteByID_BadRequest()
        {
            var serviceMock = new Mock<ICepService>();
            serviceMock.Setup(m => m.Get(It.IsAny<string>())).ReturnsAsync(
               new CepDto
               {
                   Id = Guid.NewGuid(),
                   Logradouro = "teste"
               });

            _controller = new CepController(serviceMock.Object);
            _controller.ModelState.AddModelError("Id", "FormatoInválido");

            var result = await _controller.Get("teste");
            Assert.True(result is BadRequestObjectResult);
        }

        [Fact(DisplayName = "É Possivel Realizar o Get.")]
        public async Task E_Possivel_Invocar_a_Controller_GetCompleteByID_Ok()
        {
            var serviceMock = new Mock<ICepService>();
            serviceMock.Setup(m => m.Get(It.IsAny<string>())).ReturnsAsync(
                 new CepDto
                 {
                     Id = Guid.NewGuid(),
                     Logradouro = "teste"
                 });

            _controller = new CepController(serviceMock.Object);

            var result = await _controller.Get("teste");
            Assert.True(result is OkObjectResult);
        }

        [Fact(DisplayName = "É Possivel Realizar o Get.")]
        public async Task E_Possivel_Invocar_a_Controller_GetCompleteByID_Not_Found()
        {
            var serviceMock = new Mock<ICepService>();
            serviceMock.Setup(m => m.Get(It.IsAny<Guid>())).Returns(Task.FromResult((CepDto)null));

            _controller = new CepController(serviceMock.Object);

            var result = await _controller.Get("");
            Assert.True(result is NotFoundResult);
        }
        #endregion

        #region Post
        [Fact(DisplayName = "É Possivel Realizar o Created.")]
        public async Task E_Possivel_Invocar_a_Controller_Post_BadRequest()
        {
            var serviceMock = new Mock<ICepService>();
            serviceMock.Setup(m => m.Post(It.IsAny<CepDtoCreate>())).ReturnsAsync(
                new CepDtoCreateResult
                {
                    Id = Guid.NewGuid(),
                    Logradouro = "teste",
                    CreateAt = DateTime.UtcNow
                });

            _controller = new CepController(serviceMock.Object);
            _controller.ModelState.AddModelError("Nome", "É um campo obrigatório");

            Mock<IUrlHelper> url = new Mock<IUrlHelper>();
            url.Setup(x => x.Link(It.IsAny<string>(), It.IsAny<object>())).Returns("https://localhost:5000");
            _controller.Url = url.Object;

            var cepDtoCreate = new CepDtoCreate
            {
                Logradouro = "teste",
                Numero= "123"
            };

            var result = await _controller.Post(cepDtoCreate);
            Assert.True(result is BadRequestObjectResult);
        }

        [Fact(DisplayName = "É Possivel Realizar o Created.")]
        public async Task E_Possivel_Invocar_a_Controller_Post_Ok()
        {
            var serviceMock = new Mock<ICepService>();
            serviceMock.Setup(m => m.Post(It.IsAny<CepDtoCreate>())).ReturnsAsync(
                new CepDtoCreateResult
                {
                    Id = Guid.NewGuid(),
                    Logradouro = "teste",
                    CreateAt = DateTime.UtcNow
                });

            _controller = new CepController(serviceMock.Object);

            Mock<IUrlHelper> url = new Mock<IUrlHelper>();
            url.Setup(x => x.Link(It.IsAny<string>(), It.IsAny<object>())).Returns("https://localhost:5000");
            _controller.Url = url.Object;

            var cepDtoCreate = new CepDtoCreate
            {
                Logradouro = "teste",
                Numero = "123"
            };

            var result = await _controller.Post(cepDtoCreate);
            Assert.True(result is CreatedResult);
        }
        #endregion

        #region Update
        [Fact(DisplayName = "É Possivel Realizar o Updeted.")]
        public async Task E_Possivel_Invocar_a_Controller_Put_BadRequest()
        {
            var serviceMock = new Mock<ICepService>();
            serviceMock.Setup(m => m.Put(It.IsAny<CepDtoUpdate>())).ReturnsAsync(
                new CepDtoUpdateResult
                {
                    Id = Guid.NewGuid(),
                    UpdateAt = DateTime.Now
                });

            _controller = new CepController(serviceMock.Object);
            _controller.ModelState.AddModelError("Nome", "É um campo obrigatório");

            var cepDtoUpdate = new CepDtoUpdate
            {
                Logradouro = "teste",
                Numero = "123",
                Cep = "12345-678",
                MunicipioId = Guid.NewGuid(),
            };

            var result = await _controller.Put(cepDtoUpdate);
            Assert.True(result is BadRequestObjectResult);
        }

        [Fact(DisplayName = "É Possivel Realizar o Updeted.")]
        public async Task E_Possivel_Invocar_a_Controller_Put_Ok()
        {
            var serviceMock = new Mock<ICepService>();
            serviceMock.Setup(m => m.Put(It.IsAny<CepDtoUpdate>())).ReturnsAsync(
                new CepDtoUpdateResult
                {
                    Id = Guid.NewGuid(),
                    Logradouro = "teste",
                    Numero = "123",
                    Cep = "12345-678",
                    MunicipioId = Guid.NewGuid(),
                });

            _controller = new CepController(serviceMock.Object);

            var cepDtoUpdate = new CepDtoUpdate
            {
                Id = Guid.NewGuid(),
                Logradouro = "teste",
                Numero = "123",
                Cep = "12345-678",
                MunicipioId = Guid.NewGuid(),
            };

            var result = await _controller.Put(cepDtoUpdate);
            Assert.True(result is OkObjectResult);
        }
        #endregion

        #region Delete
        [Fact(DisplayName = "É Possivel Realizar o Delete.")]
        public async Task E_Possivel_Invocar_a_Controller_Delete_Ok()
        {
            var serviceMock = new Mock<ICepService>();
            serviceMock.Setup(m => m.Delete(It.IsAny<Guid>())).ReturnsAsync(true);

            _controller = new CepController(serviceMock.Object);

            var result = await _controller.Delete(Guid.NewGuid());
            Assert.True(result is OkObjectResult);
        }

        [Fact(DisplayName = "É Possivel Realizar o Delete.")]
        public async Task E_Possivel_Invocar_a_Controller_Delete_BadRequest()
        {
            var serviceMock = new Mock<ICepService>();
            serviceMock.Setup(m => m.Delete(It.IsAny<Guid>())).ReturnsAsync(true);

            _controller = new CepController(serviceMock.Object);
            _controller.ModelState.AddModelError("Id", "Formato Inválido");

            var result = await _controller.Delete(Guid.NewGuid());
            Assert.True(result is BadRequestObjectResult);
        }
        #endregion
    }
}