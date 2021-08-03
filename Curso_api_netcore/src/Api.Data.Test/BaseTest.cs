using System;
using Xunit;

namespace Api.Data.Test
{
    public abstract class BaseTest
    {
        public BaseTest()
        {

        }

        public class DbTeste : IDisposable
        {

            private string dataBaseName = $"dbApiTeste {Guid.NewGuid().ToString().Replace("-", string.Empty)}";

            public ServiceProvider ServiceProvider { get; private set; }

            public DbTeste()
            {
                var serviceCollection = new ServiceCollection();
                serviceCollection.AddContext<MyContext>(o =>
              o.UseSqlServer($"Persist Security Info=True;Server= NT-04611\\SQLEXPRESS;Database=dbnetcoreapi;Trusted_Connection=True"),
                ServiceLifetime.Transient
                );

                ServerProvider = serviceCollection.BuildServerProvider();
                using (var context = ServerProvider.GetService<MyContext>())
                {
                    context.Database.EnsureCreated();
                }
            }

            public void Dispose()
            {
                using (var context = ServerProvider.GetService<MyContext>())
                {
                    context.Database.EnsureDelete();
                }
            }
        }
    }
}
