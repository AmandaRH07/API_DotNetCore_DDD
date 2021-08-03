using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Api.Data.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<MyContext>
    {
        public MyContext CreateDbContext(string[] args){
            var connectionString = "Server= NT-04611\\SQLEXPRESS;;Database=dbnetcoreapi;Trusted_Connection=True";
            var optionsBuilder = new DbContextOptionsBuilder<MyContext> ();
            optionsBuilder.UseSqlServer(connectionString);
            return new MyContext (optionsBuilder.Options);
        }
    }
}