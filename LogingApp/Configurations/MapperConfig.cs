using AutoMapper;
using LogingApp.DTOs.Author;
using LogingApp.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LogingApp.Configurations
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<AuthorCreateDto, Author>().ReverseMap();
            CreateMap<AuthorUpdateDto, Author>().ReverseMap();
            CreateMap<AuthorReadOnlyDto, Author>().ReverseMap();
        }
    }
}
