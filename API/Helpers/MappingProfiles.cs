using API.Dtos;
using AutoMapper;
using Core.Entidades;

namespace API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Lugar, LugarDto>()
            .ForMember(d => d.Pais, o => o.MapFrom(s => s.Pais.Nombre)) // para que mapee el nombre del pais
            .ForMember(d => d.Categoria, o => o.MapFrom(s => s.Categoria.Nombre)) // para que mapee el nombre de la categoria
            .ForMember(d => d.ImagenUrl, o => o.MapFrom<LugarUrlResolver>()); // para que mapee la imagen
        }        
    }
}