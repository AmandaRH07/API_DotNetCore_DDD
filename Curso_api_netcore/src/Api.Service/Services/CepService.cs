using AutoMapper;
using Domain.Dtos.Cep;
using Domain.Entities;
using Domain.Interface.Services.Cep;
using Domain.Models;
using Domain.Repository;
using System;
using System.Threading.Tasks;

namespace Service.Services
{
    public class CepService : ICepService
    {
        private ICepRepository _cepRepository;
        private readonly IMapper _mapper;

        public CepService(ICepRepository cepRepository, IMapper mapper)
        {
            _cepRepository = cepRepository;
            _mapper = mapper;
        }

        public async Task<CepDto> Get(Guid id)
        {
            var entity = await _cepRepository.SelectAsync(id);
            return _mapper.Map<CepDto>(entity);
        }

        public async Task<CepDto> Get(string cep)
        {
            var entity = await _cepRepository.SelectAsync(cep);
            return _mapper.Map<CepDto>(entity);
        }

        public async Task<CepDtoCreateResult> Post(CepDtoCreate cep)
        {
            var model = _mapper.Map<CepModel>(cep);
            var entity = _mapper.Map<CepEntity>(model);
            var result = await _cepRepository.InsertAsync(entity);

            return _mapper.Map<CepDtoCreateResult>(result);
        }

        public async Task<CepDtoUpdateResult> Put(CepDtoUpdate cep)
        {
            var model = _mapper.Map<CepModel>(cep);
            var entity = _mapper.Map<CepEntity>(model);
            var result = await _cepRepository.InsertAsync(entity);

            return _mapper.Map<CepDtoUpdateResult>(result);
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _cepRepository.DeleteAsync(id);
        }
    }
}
