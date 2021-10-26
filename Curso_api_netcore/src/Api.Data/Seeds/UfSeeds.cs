
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace Data.Seeds
{
    public static class UfSeeds
    {
        public static void Ufs(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UfEntity>().HasData(
                 new UfEntity()
                 {
                     Id = new Guid("22ffbd18-cdb9-45cc-97b0-51e97700bf71"),
                     Sigla = "AC",
                     Nome = "Acre",
                     CreateAt = DateTime.UtcNow
                 },
                new UfEntity()
                {
                    Id = new Guid("7cc33300-586e-4be8-9a4d-bd9f01ee9ad8"),
                    Sigla = "AL",
                    Nome = "Alagoas",
                    CreateAt = DateTime.UtcNow
                },
                new UfEntity()
                {
                    Id = new Guid("cb9e6888-2094-45ee-bc44-37ced33c693a"),
                    Sigla = "AM",
                    Nome = "Amazonas",
                    CreateAt = DateTime.UtcNow
                },
                 new UfEntity()
                 {
                     Id = new Guid("409b9043-88a4-4e86-9cca-ca1fb0d0d35b"),
                     Sigla = "AP",
                     Nome = "Amapá",
                     CreateAt = DateTime.UtcNow
                 },
                 new UfEntity()
                 {
                     Id = new Guid("5abca453-d035-4766-a81b-9f73d683a54b"),
                     Sigla = "BA",
                     Nome = "Bahia",
                     CreateAt = DateTime.UtcNow
                 },
                 new UfEntity()
                 {
                     Id = new Guid("5ff1b59e-11e7-414d-827e-609dc5f7e333"),
                     Sigla = "CE",
                     Nome = "Ceará",
                     CreateAt = DateTime.UtcNow
                 },
                 new UfEntity()
                 {
                     Id = new Guid("bd08208b-bfca-47a4-9cd0-37e4e1fa5006"),
                     Sigla = "DF",
                     Nome = "Distrito Federal",
                     CreateAt = DateTime.UtcNow
                 },
                 new UfEntity()
                 {
                     Id = new Guid("c623f804-37d8-4a19-92c1-67fd162862e6"),
                     Sigla = "ES",
                     Nome = "Espírito Santo",
                     CreateAt = DateTime.UtcNow
                 },
                 new UfEntity()
                 {
                     Id = new Guid("837a64d3-c649-4172-a4e0-2b20d3c85224"),
                     Sigla = "GO",
                     Nome = "Goiás",
                     CreateAt = DateTime.UtcNow
                 },
                 new UfEntity()
                 {
                     Id = new Guid("57a9e9f7-9aea-40fe-a783-65d4feb59fa8"),
                     Sigla = "MA",
                     Nome = "Maranhão",
                     CreateAt = DateTime.UtcNow
                 },
                 new UfEntity()
                 {
                     Id = new Guid("27f7a92b-1979-4e1c-be9d-cd3bb73552a8"),
                     Sigla = "MG",
                     Nome = "Minas Gerais",
                     CreateAt = DateTime.UtcNow
                 },
                 new UfEntity()
                 {
                     Id = new Guid("3739969c-fd8a-4411-9faa-3f718ca85e70"),
                     Sigla = "MS",
                     Nome = "Mato Grosso do Sul",
                     CreateAt = DateTime.UtcNow
                 },
                 new UfEntity()
                 {
                     Id = new Guid("29eec4d3-b061-427d-894f-7f0fecc7f65f"),
                     Sigla = "MT",
                     Nome = "Mato Grosso",
                     CreateAt = DateTime.UtcNow
                 },
                 new UfEntity()
                 {
                     Id = new Guid("8411e9bc-d3b2-4a9b-9d15-78633d64fc7c"),
                     Sigla = "PA",
                     Nome = "Pará",
                     CreateAt = DateTime.UtcNow
                 },
                 new UfEntity()
                 {
                     Id = new Guid("1109ab04-a3a5-476e-bdce-6c3e2c2badee"),
                     Sigla = "PB",
                     Nome = "Paraíba",
                     CreateAt = DateTime.UtcNow
                 },
                 new UfEntity()
                 {
                     Id = new Guid("ad5969bd-82dc-4e23-ace2-d8495935dd2e"),
                     Sigla = "PE",
                     Nome = "Pernambuco",
                     CreateAt = DateTime.UtcNow
                 },
                 new UfEntity()
                 {
                     Id = new Guid("f85a6cd0-2237-46b1-a103-d3494ab27774"),
                     Sigla = "PI",
                     Nome = "Piauí",
                     CreateAt = DateTime.UtcNow
                 },
                 new UfEntity()
                 {
                     Id = new Guid("1dd25850-6270-48f8-8b77-2f0f079480ab"),
                     Sigla = "PR",
                     Nome = "Paraná",
                     CreateAt = DateTime.UtcNow
                 },
                 new UfEntity()
                 {
                     Id = new Guid("43a0f783-a042-4c46-8688-5dd4489d2ec7"),
                     Sigla = "RJ",
                     Nome = "Rio de Janeiro",
                     CreateAt = DateTime.UtcNow
                 },
                 new UfEntity()
                 {
                     Id = new Guid("542668d1-50ba-4fca-bbc3-4b27af108ea3"),
                     Sigla = "RN",
                     Nome = "Rio Grande do Norte",
                     CreateAt = DateTime.UtcNow
                 },
                 new UfEntity()
                 {
                     Id = new Guid("924e7250-7d39-4e8b-86bf-a8578cbf4002"),
                     Sigla = "RO",
                     Nome = "Rondônia",
                     CreateAt = DateTime.UtcNow
                 },
                 new UfEntity()
                 {
                     Id = new Guid("9fd3c97a-dc68-4af5-bc65-694cca0f2869"),
                     Sigla = "RR",
                     Nome = "Roraima",
                     CreateAt = DateTime.UtcNow
                 },
                 new UfEntity()
                 {
                     Id = new Guid("88970a32-3a2a-4a95-8a18-2087b65f59d1"),
                     Sigla = "RS",
                     Nome = "Rio Grande do Sul",
                     CreateAt = DateTime.UtcNow
                 },
                 new UfEntity()
                 {
                     Id = new Guid("b81f95e0-f226-4afd-9763-290001637ed4"),
                     Sigla = "SC",
                     Nome = "Santa Catarina",
                     CreateAt = DateTime.UtcNow
                 },
                 new UfEntity()
                 {
                     Id = new Guid("fe8ca516-034f-4249-bc5a-31c85ef220ea"),
                     Sigla = "SE",
                     Nome = "Sergipe",
                     CreateAt = DateTime.UtcNow
                 },
                 new UfEntity()
                 {
                     Id = new Guid("e7e416de-477c-4fa3-a541-b5af5f35ccf6"),
                     Sigla = "SP",
                     Nome = "São Paulo",
                     CreateAt = DateTime.UtcNow
                 },
                 new UfEntity()
                 {
                     Id = new Guid("971dcb34-86ea-4f92-989d-064f749e23c9"),
                     Sigla = "TO",
                     Nome = "Tocantins",
                     CreateAt = DateTime.UtcNow
                 }
            );
        }
    }
}
