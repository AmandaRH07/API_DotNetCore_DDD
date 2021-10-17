using Domain.Dtos.Cep;
using System;
using System.Threading.Tasks;

namespace Domain.Interface.Services.Cep
{
    public interface ICepService
    {
        Task<CepDto> Get(Guid id);

        Task<CepDto> Get(string cep);

        Task<CepDtoCreateResult> Post(CepDtoCreate cep);

        Task<CepDtoUpdateResult> Put(CepDtoUpdate cep);

        Task<bool> Delete(Guid id);
    }
}
