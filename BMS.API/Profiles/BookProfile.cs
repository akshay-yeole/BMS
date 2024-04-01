using AutoMapper;
using BMS.Domain.Dto;
using BMS.Domain.Models;

namespace BMS.Core.Profiles
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<BookDto, Book>().ReverseMap();
        }
    }
}
