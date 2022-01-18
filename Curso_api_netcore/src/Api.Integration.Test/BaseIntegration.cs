using Api.CrossCutting.Mappings;
using Api.Data.Context;
using application;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Api.Integration.Test
{
    public abstract class BaseIntegration : IDisposable
    {
        public MyContext myContext { get; private set; }
        public HttpClient client { get; private set; }
        public IMapper mapper { get; set; }
        public string hostApi { get; set; }
        public HttpResponseMessage response { get; set; }

        public BaseIntegration()
        {
            hostApi = "http://localhost:5000/api";

            var builder = new WebHostBuilder()
                .UseEnvironment("Testing")
                .UseStartup<Startup>();

            var server = new TestServer(builder);

            myContext = server.Host.Services.GetService(typeof(MyContext)) as MyContext;
            myContext.Database.Migrate();
            mapper = new AutoMapperFixture().GetMapper();

            client = server.CreateClient();
        }
         

        public async Task AdicionarToken()
        {
            //var loginDto = new LoginDto()
            //{
            //    Email = "user@example.com"
            //};
            //var resultLogin = await PostJsonAsync(loginDto, $"{hostApi}/login", client);
            //var jsonLogin = await resultLogin.Content.ReadAsStringAsync();

            //var testeIgnore = new JsonSerializerSettings
            //{
            //    NullValueHandling = NullValueHandling.Ignore,
            //    MissingMemberHandling = MissingMemberHandling.Ignore
            //};

            //var loginObject = JsonConvert.DeserializeObject<LoginResponseDto>(jsonLogin, testeIgnore);

            var loginObject = new LoginResponseDto()
            {
                authenticated = true,
                create = DateTime.UtcNow,
                expiration= DateTime.Today.AddDays(2),
                accessToken= "eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6WyJ1c2VyQGV4YW1wbGUuY29tIiwidXNlckBleGFtcGxlLmNvbSJdLCJqdGkiOiIyOTQxMzQ1MC1lZjA0LTQ1ZGItOTYxMi01MTUyMzdjOGVkZjQiLCJuYmYiOjE2NDIxMTQzMTcsImV4cCI6MTY0MjE0MzExNywiaWF0IjoxNjQyMTE0MzE3LCJpc3MiOiJFeGVtcGxvSXNzdWVyIiwiYXVkIjoiRXhlbXBsb0F1ZGllbmNlIn0.AhEFO3sAFohR-hVpdztl4JmCG4ncP-iSQY7fixx9vTgHVoLz3QtV5Xr3jsHAn1FkSUk2IUdpA845XTSkB7qC6O_9d_FFXe8_CQ1NKXtpa1vI811hW89jLnCQ84m-9WaYalx9d6RVKSngZH9lLRliyLZadJy4B6lcpXJIuUDOfZNGc6DoBOysbsULwhzA_DNbfDQbZQYARXtbNWpxlA7XBbGzb7yEFKJXHjFjc_bCVG3JamQhuw0AUd4__Zeib3UEr6vrlPiE5JM0ASq6WPI8W0txcfJNwK9BkZ9DDzeT3JD-4irzx6ha5t1Tl-lnaDDLG3lLh8ZqS6G4dMiskoY1Sw",
                userName= "user@example.com",
                name= "Administrador",
                message= "Usuário Logado com sucesso"
            };

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer ",
                                                            loginObject.accessToken);
        }

        public static async Task<HttpResponseMessage> PostJsonAsync(object dataclass, string url, HttpClient client)
        {
            return await client.PostAsync(url, 
                new StringContent(JsonConvert.SerializeObject(dataclass), System.Text.Encoding.UTF8, "application/json"));
        }

        public void Dispose()
        {
            myContext.Dispose();
            client.Dispose();
        }
    }

    public class AutoMapperFixture : IDisposable
    {

        public IMapper GetMapper()
        {
            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new DtoToModelProfile());
                cfg.AddProfile(new EntityToDtoProfile());
                cfg.AddProfile(new ModelToEntityProfile());
            });

            return config.CreateMapper();
        }
        public void Dispose(){ }
    }
}
