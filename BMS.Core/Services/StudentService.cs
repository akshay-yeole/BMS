using AutoMapper;
using BMS.Core.Contracts;
using BMS.Domain.Dto;
using BMS.Domain.Models;
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
            var students = _context.Students.ToList();
            return _mapper.Map<IEnumerable<StudentDto>>(students);
        }

        public Student GetStudentDetails(int Std, char div, int rollNo)
        {
            return _context.Students.Where(x => x.Std == Std && x.Div == div && x.RollNo == rollNo).FirstOrDefault();
        }

        public async Task<StudentDto> AddStudentAsync(StudentDto studentDto)
        {
            var isStudentExists = GetStudentDetails(studentDto.Std, studentDto.Div, studentDto.RollNo);
            if (isStudentExists != null)
                return null;
            var student = _mapper.Map<Student>(studentDto);
            student.Id = Guid.NewGuid();
            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();
            return studentDto;
        }

        public async Task DeleteStudentAsync(Guid studentId)
        {
            var isStudentExists = await _context.Students.Where(x=>x.Id ==studentId).FirstOrDefaultAsync();
            if (isStudentExists == null)
                throw new Exception();
            _context.Students.Remove(isStudentExists);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateStudentAsync(StudentDto studentDto, Guid studentId)
        {
            var isStudentExists = await _context.Students.Where(x => x.Id == studentId).FirstOrDefaultAsync();
            if (isStudentExists == null)
                throw new Exception();
            _mapper.Map(studentDto, isStudentExists);
            await _context.SaveChangesAsync();
        }
    }
}
