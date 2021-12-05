using Domain.Dtos.Cep;
using Domain.Dtos.Municipio;
using Domain.Dtos.Uf;
using System;
using System.Collections.Generic;

namespace Api.Service.Test.Cep
{
    public class CepTestes
    {
        public static string CodCep { get; set; }
        public static string LogradouroCep { get; set; }
        public static string NumeroCep { get; set; }
        public static Guid IdCep { get; set; }
        public static Guid IdMunicipio { get; set; }
        public static MunicipioDtoCompleto MunicipioCep { get; set; }

        public List<CepDto> listaDto = new List<CepDto>();

        public CepDto cepDto;
        public CepDtoCreate cepDtoCreate;
        public CepDtoCreateResult cepDtoCreateResult;
        public CepDtoUpdate cepDtoUpdate;
        public CepDtoUpdateResult cepDtoUpdateResult;

        public CepTestes()
        {
            IdCep = Guid.NewGuid();
            CodCep = Faker.RandomNumber.Next(1, 1000).ToString();
            LogradouroCep = Faker.Address.StreetName();
            NumeroCep = Faker.RandomNumber.Next(1, 10000).ToString();
            IdMunicipio = Guid.NewGuid();

            for (int i = 0; i < 10; i++)
            {
                var dto = new CepDto()
                {
                    Id = Guid.NewGuid(),
                    Cep = Faker.RandomNumber.Next(1, 1000).ToString(),
                    Logradouro = Faker.Address.StreetName(),
                    Numero = Faker.RandomNumber.Next(1, 10000).ToString(),
                    MunicipioId = Guid.NewGuid(),
                    Municipio = new MunicipioDtoCompleto
                    {
                        Id = IdMunicipio,
                        Nome = Faker.Address.City(),
                        CodIBGE = Faker.RandomNumber.Next(1, 10000),
                        UfId = Guid.NewGuid(),
                        Uf = new UfDto
                        {
                            Id = Guid.NewGuid(),
                            Nome = Faker.Address.UsState(),
                            Sigla = Faker.Address.UsState().Substring(1, 3)
                        }
                    }
                };
                listaDto.Add(dto);
            }

            cepDto = new CepDto
            {
                Id = IdCep,
                Cep = CodCep,
                Logradouro = LogradouroCep,
                Numero = NumeroCep,
                MunicipioId = IdMunicipio
            };

            cepDtoCreate = new CepDtoCreate
            {
                Cep = CodCep,
                Numero = NumeroCep,
                Logradouro = LogradouroCep,
                MunicipioId = IdMunicipio
            };

            cepDtoCreateResult = new CepDtoCreateResult
            {
                Id = IdCep,
                Cep = CodCep,
                Logradouro = LogradouroCep,
                Numero = NumeroCep,
                MunicipioId = IdMunicipio,
                CreateAt = DateTime.UtcNow
            };

            cepDtoUpdate = new CepDtoUpdate {
                Id = IdCep,
                Cep = CodCep,
                Logradouro = LogradouroCep,
                Numero = NumeroCep,
                MunicipioId = IdMunicipio
            };

            cepDtoUpdateResult = new CepDtoUpdateResult
            {
                Id = IdCep,
                Cep = CodCep,
                Logradouro = LogradouroCep,
                Numero = NumeroCep,
                MunicipioId = IdMunicipio,
                UpdateAt = DateTime.UtcNow
            };
        }
    }
}
