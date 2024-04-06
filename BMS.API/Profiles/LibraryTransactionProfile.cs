using AutoMapper;
using BMS.Domain.Dto;
using BMS.Domain.Models;

namespace BMS.API.Profiles
{
    public class LibraryTransactionProfile : Profile
    {
        public LibraryTransactionProfile()
        {
            CreateMap<LibraryTransactionDto, LibraryTransaction>().ReverseMap();
        }
    }
}
