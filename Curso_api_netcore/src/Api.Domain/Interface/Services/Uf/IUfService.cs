using Domain.Dtos.Uf;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interface.Services.Uf
{
    public interface IUfService
    {
        Task<UfDto> Get(Guid Id);
        Task<IEnumerable<UfDto>> GetAll();
    }
}
