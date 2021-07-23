using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Options;

namespace Api.Data.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<MyContext>
    {
        public MyContext CreateDbContext(string[] args){
            var connectionString = "Server=localhost;Port=3306;Database=dbNetCoreAPI;Uid=root;Pwd=sa@1234";
            var optionsBuilder = new DbContextOptionsBuilder<MyContext> ();
            optionsBuilder.UseMySql (connectionString);
            return new MyContext (optionsBuilder.Options);
        }
    }
}