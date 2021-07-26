using System.Threading.Tasks;
using Api.Domain.Dtos;


namespace Api.Domain.Interface.Services.Users
{
    public interface ILoginService
    {
         Task<object> FindByLogin (LoginDto user);
    }
}