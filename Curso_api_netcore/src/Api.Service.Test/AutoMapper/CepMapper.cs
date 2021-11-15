using Domain.Dtos.Cep;
using Domain.Entities;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Api.Service.Test.AutoMapper
{
    public class CepMapper : BaseTesteService
    {
        [Fact(DisplayName = "É Possível Mapear os Modelos de Cep")]
        public void E_Possivel_Mapear_Os_Modelos_Cep()
        {
            var model = new CepModel
            {
                Id = Guid.NewGuid(),
                Cep = Faker.RandomNumber.Next(1, 1000).ToString(),
                Logradouro = Faker.Address.StreetName(),
                Numero = "",
                CreateAt = DateTime.UtcNow,
                UpdateAt = DateTime.UtcNow,
                MunicipioId = Guid.NewGuid()
            };

            var listaEntity = new List<CepEntity>();

            for (int i = 0; i < 5; i++)
            {
                var item = new CepEntity
                {
                    Id = Guid.NewGuid(),
                    Cep = Faker.RandomNumber.Next(1, 1000).ToString(),
                    Logradouro = Faker.Address.StreetName(),
                    Numero = Faker.RandomNumber.Next(1, 10000).ToString(),
                    CreateAt = DateTime.UtcNow,
                    UpdateAt = DateTime.UtcNow,
                    MunicipioId = Guid.NewGuid(),
                    Municipio = new MunicipioEntity
                    {
                        Id = Guid.NewGuid(),
                        Nome = Faker.Address.UsState(),
                        CodIBGE = Faker.RandomNumber.Next(1, 1000),
                        UfId = Guid.NewGuid(),
                        CreateAt = DateTime.UtcNow,
                        UpdateAt = DateTime.UtcNow
                    }
                };
                listaEntity.Add(item);
            }

            //Model -> Entity
            var entity = Mapper.Map<CepEntity>(model);
            Assert.Equal(entity.Id, model.Id);
            Assert.Equal(entity.Logradouro, model.Logradouro);
            Assert.Equal(entity.Numero, model.Numero);
            Assert.Equal(entity.Cep, model.Cep);
            Assert.Equal(entity.CreateAt, model.CreateAt);
            Assert.Equal(entity.UpdateAt, model.UpdateAt);

            //Entity -> Dto
            var cepDto = Mapper.Map<CepDto>(entity);
            Assert.Equal(cepDto.Id, entity.Id);
            Assert.Equal(cepDto.Logradouro, entity.Logradouro);
            Assert.Equal(cepDto.Numero, entity.Numero);
            Assert.Equal(cepDto.Cep, entity.Cep);

            var cepDtoCompleto = Mapper.Map<CepDto>(listaEntity.FirstOrDefault());
            Assert.Equal(cepDtoCompleto.Id, listaEntity.FirstOrDefault().Id);
            Assert.Equal(cepDtoCompleto.Cep, listaEntity.FirstOrDefault().Cep);
            Assert.Equal(cepDtoCompleto.Logradouro, listaEntity.FirstOrDefault().Logradouro);
            Assert.Equal(cepDtoCompleto.Numero, listaEntity.FirstOrDefault().Numero);
            Assert.NotNull(cepDtoCompleto.Municipio);
            Assert.Null(cepDtoCompleto.Municipio.Uf);

            var listaDto = Mapper.Map<List<CepDto>>(listaEntity);
            Assert.True(listaDto.Count() == listaEntity.Count());

            for (int i = 0; i < listaDto.Count(); i++)
            {
                Assert.Equal(listaDto[i].Id, listaEntity[i].Id);
                Assert.Equal(listaDto[i].Logradouro, listaEntity[i].Logradouro);
                Assert.Equal(listaDto[i].Numero, listaEntity[i].Numero);
                Assert.Equal(listaDto[i].Cep, listaEntity[i].Cep);
            }

            var cepDtoCreateResult = Mapper.Map<CepDtoCreateResult>(entity);
            Assert.Equal(cepDtoCreateResult.Id, entity.Id);
            Assert.Equal(cepDtoCreateResult.Logradouro, entity.Logradouro);
            Assert.Equal(cepDtoCreateResult.Numero, entity.Numero);
            Assert.Equal(cepDtoCreateResult.Cep, entity.Cep);
            Assert.Equal(cepDtoCreateResult.CreateAt, entity.CreateAt);

            var cepDtoUpdateResult = Mapper.Map<CepDtoUpdateResult>(entity);
            Assert.Equal(cepDtoUpdateResult.Id, entity.Id);
            Assert.Equal(cepDtoUpdateResult.Logradouro, entity.Logradouro);
            Assert.Equal(cepDtoUpdateResult.Numero, entity.Numero);
            Assert.Equal(cepDtoUpdateResult.Cep, entity.Cep);
            Assert.Equal(cepDtoUpdateResult.UpdateAt, entity.UpdateAt);

            //Dto -> Model
            cepDto.Numero = "";
            var cepModel = Mapper.Map<CepModel>(cepDto);
            Assert.Equal(cepModel.Id, cepDto.Id);
            Assert.Equal(cepModel.Logradouro, cepDto.Logradouro);
            Assert.Equal(cepModel.Cep, cepDto.Cep);
            Assert.Equal("S/N", cepModel.Numero);

            var cepDtopCreate = Mapper.Map<CepDtoCreate>(model);
            Assert.Equal(cepDtopCreate.Logradouro, model.Logradouro);
            Assert.Equal(cepDtopCreate.Cep, model.Cep);
            Assert.Equal(cepDtopCreate.Numero, model.Numero);

            var cepDtoUpdate = Mapper.Map<CepDtoUpdate>(model);
            Assert.Equal(cepDtoUpdate.Logradouro, model.Logradouro);
            Assert.Equal(cepDtoUpdate.Cep, model.Cep);
            Assert.Equal(cepDtoUpdate.Numero, model.Numero);
        }
    }
}
