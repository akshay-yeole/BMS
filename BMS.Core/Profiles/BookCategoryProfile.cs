using AutoMapper;
using BMS.Domain.Dto;
using BMS.Domain.Models;

namespace BMS.Core.Profiles
{
    public class BookCategoryProfile : Profile
    {
        public BookCategoryProfile()
        {
            CreateMap<BookCategoryDto, BookCategory>().ReverseMap();
        }
    }
}
