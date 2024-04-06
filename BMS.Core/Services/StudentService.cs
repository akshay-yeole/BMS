using AutoMapper;
using BMS.Core.Contracts;
using BMS.Domain.Dto;
using BMS.Sql.Context;
using Microsoft.EntityFrameworkCore;

namespace BMS.Core.Services
{
    public class StudentService : IStudentService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public StudentService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<StudentDto>> GetAllStudentsAsync()
        {
            var students = _context.Students.ToListAsync();
            return _mapper.Map<IEnumerable<StudentDto>>(students);
        }
    }
}
