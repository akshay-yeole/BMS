using AutoMapper;
using BMS.Domain.Dto;
using BMS.Domain.Models;

namespace BMS.API.Profiles
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            CreateMap<StudentDto,Student>().ReverseMap();
        }
    }
}
