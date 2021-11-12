using AutoMapper;
using Domain.Dtos.Uf;
using Domain.Interface.Services.Uf;
using Domain.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Services
{
    public class UfService : IUfService
    {
        private IUfRepository _ufRepository;
        private readonly IMapper _mapper;

        public UfService(IUfRepository ufRepository, IMapper mapper)
        {
            _ufRepository = ufRepository;
            _mapper = mapper; 
        }

        public async Task<UfDto> Get(Guid id)
        {
            var entity = await _ufRepository.SelectAsync(id);
            return _mapper.Map<UfDto>(entity);
        }

        public async Task<IEnumerable<UfDto>> GetAll()
        {
            var listEntity = await _ufRepository.SelectAsync();
            return _mapper.Map<IEnumerable<UfDto>>(listEntity);
        }
    }
}
