using Domain.Dtos.Municipio;
using Domain.Entities;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Api.Service.Test.AutoMapper
{
    public class MunicipioMapper : BaseTesteService
    {
        [Fact(DisplayName = "É Possível Mapear os Modelos de Municipio")]
        public void E_Possivel_Mapear_Os_Modelos_Municipio()
        {
            var model = new MunicipioModel
            {
                Id = Guid.NewGuid(),
                Nome = Faker.Address.UsState(),
                CodIBGE = Faker.RandomNumber.Next(1, 1000),
                UfId = Guid.NewGuid(),
                CreateAt = DateTime.UtcNow,
                UpdateAt = DateTime.UtcNow
            };

            var listaEntity = new List<MunicipioEntity>();

            for (int i = 0; i < 5; i++)
            {
                var item = new MunicipioEntity
                {
                    Id = Guid.NewGuid(),
                    Nome = Faker.Address.UsState(),
                    CodIBGE = Faker.RandomNumber.Next(1, 1000),
                    UfId = Guid.NewGuid(),
                    CreateAt = DateTime.UtcNow,
                    UpdateAt = DateTime.UtcNow,
                    Uf = new UfEntity
                    {
                        Id = Guid.NewGuid(),
                        Nome = Faker.Address.UsState(),
                        Sigla = Faker.Address.UsState().Substring(1, 3),
                    }

                };
                listaEntity.Add(item);
            }

            //Model -> Entity
            var entity = Mapper.Map<MunicipioEntity>(model);
            Assert.Equal(entity.Id, model.Id);
            Assert.Equal(entity.Nome, model.Nome);
            Assert.Equal(entity.CodIBGE, model.CodIBGE);
            Assert.Equal(entity.UfId, model.UfId);
            Assert.Equal(entity.CreateAt, model.CreateAt);
            Assert.Equal(entity.UpdateAt, model.UpdateAt);

            //Entity -> Dto
            var userDto = Mapper.Map<MunicipioDto>(entity);
            Assert.Equal(userDto.Id, entity.Id);
            Assert.Equal(userDto.Nome, entity.Nome);
            Assert.Equal(userDto.CodIBGE, entity.CodIBGE);
            Assert.Equal(userDto.UfId, entity.UfId);

            var userDtoCompleto = Mapper.Map<MunicipioDtoCompleto>(listaEntity.FirstOrDefault());
            Assert.Equal(userDtoCompleto.Id, listaEntity.FirstOrDefault().Id);
            Assert.Equal(userDtoCompleto.Nome, listaEntity.FirstOrDefault().Nome);
            Assert.Equal(userDtoCompleto.CodIBGE, listaEntity.FirstOrDefault().CodIBGE);
            Assert.Equal(userDtoCompleto.UfId, listaEntity.FirstOrDefault().UfId);
            Assert.NotNull(userDtoCompleto.Uf);

            var listaDto = Mapper.Map<List<MunicipioDto>>(listaEntity);
            Assert.True(listaDto.Count() == listaEntity.Count());

            for (int i = 0; i < listaDto.Count(); i++)
            {
                Assert.Equal(listaDto[i].Id, listaEntity[i].Id);
                Assert.Equal(listaDto[i].Nome, listaEntity[i].Nome);
                Assert.Equal(listaDto[i].CodIBGE, listaEntity[i].CodIBGE);
                Assert.Equal(listaDto[i].UfId, listaEntity[i].UfId);
            }

            var userDtoCreateResult = Mapper.Map<MunicipioDtoCreateResult>(entity);
            Assert.Equal(userDtoCreateResult.Id, entity.Id);
            Assert.Equal(userDtoCreateResult.Nome, entity.Nome);
            Assert.Equal(userDtoCreateResult.CodIBGE, entity.CodIBGE);
            Assert.Equal(userDtoCreateResult.UfId, entity.UfId);
            Assert.Equal(userDtoCreateResult.CreateAt, entity.CreateAt);

            var userDtoUpdateResult = Mapper.Map<MunicipioDtoUpdateResult>(entity);
            Assert.Equal(userDtoUpdateResult.Id, entity.Id);
            Assert.Equal(userDtoUpdateResult.Nome, entity.Nome);
            Assert.Equal(userDtoUpdateResult.CodIBGE, entity.CodIBGE);
            Assert.Equal(userDtoUpdateResult.UfId, entity.UfId);
            Assert.Equal(userDtoUpdateResult.UpdateAt, entity.UpdateAt);

            //Dto -> Model
            var userModel = Mapper.Map<MunicipioDto>(model);
            Assert.Equal(userModel.Id, model.Id);
            Assert.Equal(userModel.Nome, model.Nome);
            Assert.Equal(userModel.CodIBGE, model.CodIBGE);
            Assert.Equal(userModel.UfId, model.UfId);

            var userDtopCreate = Mapper.Map<MunicipioDtoCreate>(model);
            Assert.Equal(userDtopCreate.Nome, model.Nome);
            Assert.Equal(userDtopCreate.CodIBGE, model.CodIBGE);
            Assert.Equal(userDtopCreate.UfId, model.UfId);

            var userDtoUpdate = Mapper.Map<MunicipioDtoUpdate>(model);
            Assert.Equal(userDtoUpdate.Id, model.Id);
            Assert.Equal(userDtoUpdate.Nome, model.Nome);
            Assert.Equal(userDtoUpdate.CodIBGE, model.CodIBGE);
            Assert.Equal(userDtoUpdate.UfId, model.UfId);
        }
    }
}
