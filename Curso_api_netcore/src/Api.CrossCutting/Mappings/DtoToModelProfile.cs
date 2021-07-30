using Api.Domain.Dtos.User;
using Api.Domain.Models;
using AutoMapper;

namespace Api.CrossCutting.Mappings
{
    public class DtoToModelProfile : Profile
    {
        public DtoToModelProfile()
        {
        // Mapeando do <Source para o, destino>
            CreateMap<UserModel, UserDto>()
                .ReverseMap();
        }
    }
}