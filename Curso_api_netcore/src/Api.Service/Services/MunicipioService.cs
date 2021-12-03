using AutoMapper;
using Domain.Dtos.Municipio;
using Domain.Entities;
using Domain.Interface.Services;
using Domain.Models;
using Domain.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Services
{
    public class MunicipioService : IMunicipioService
    {
        private IMunicipioRepository _municipioRepository;
        private readonly IMapper _mapper;

        public MunicipioService(IMunicipioRepository municipioRepository, IMapper mapper)
        {
            _municipioRepository = municipioRepository;
            _mapper = mapper;
        }

        public async Task<MunicipioDto> Get(Guid id)
        {
            var entity = await _municipioRepository.SelectAsync(id);
            return _mapper.Map<MunicipioDto>(entity);
        }

        public async Task<MunicipioDtoCompleto> GetCompleteById(Guid id)
        {
            var entity = await _municipioRepository.GetCompleteById(id);
            return _mapper.Map<MunicipioDtoCompleto>(entity);
        }

        public async Task<MunicipioDtoCompleto> GetCompleteByIBGE(int codIBGE)
        {
            var entity = await _municipioRepository.GetCompleteByIBGE(codIBGE);
            return _mapper.Map<MunicipioDtoCompleto>(entity);
        }

        public async Task<IEnumerable<MunicipioDto>> GetAll()
        {
            var listEntity = await _municipioRepository.SelectAsync();
            return _mapper.Map<IEnumerable<MunicipioDto>>(listEntity);
        }

        public async Task<MunicipioDtoCreateResult> Post(MunicipioDtoCreate municipio)
        {
            var model = _mapper.Map<MunicipioModel>(municipio);
            var entity = _mapper.Map<MunicipioEntity>(model);
            var result = await _municipioRepository.InsertAsync(entity);

            return _mapper.Map<MunicipioDtoCreateResult>(result);
        }

        public async Task<MunicipioDtoUpdateResult> Put(MunicipioDtoUpdate municipio)
        {
            var model = _mapper.Map<MunicipioModel>(municipio);
            var entity = _mapper.Map<MunicipioEntity>(model);
            var result = await _municipioRepository.UpdateAsync(entity);

            return _mapper.Map<MunicipioDtoUpdateResult>(result);
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _municipioRepository.DeleteAsync(id);
        }
    }
}
