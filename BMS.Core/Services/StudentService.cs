using AutoMapper;
using BMS.Core.Common;
using BMS.Core.Contracts;
using BMS.Domain.Constants;
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

        public async Task<Result<IEnumerable<StudentDto>>> GetAllStudentsAsync()
        {
            var students = _context.Students.ToList();
            if (!students.Any())
                return Result.Fail<IEnumerable<StudentDto>>(ErrorMessages.StudentNotFound, StatusCodes.NotFoundError);
            var allStudents = _mapper.Map<IEnumerable<StudentDto>>(students);
            return Result.Ok(allStudents);
        }

        public async Task<Result<StudentDto>> GetStudentDetails(int Std, char div, int rollNo)
        {
            var studentDetails = await _context.Students.Where(x => x.Std == Std && x.Div == div && x.RollNo == rollNo).FirstOrDefaultAsync();
            if (studentDetails == null)
                return Result.Fail<StudentDto>(ErrorMessages.StudentNotFound, StatusCodes.NotFoundError);
            return Result.Ok(_mapper.Map<StudentDto>(studentDetails));
        }

        public async Task<Result<bool>> AddStudentAsync(StudentDto studentDto)
        {
            var isStudentExists = GetStudentDetails(studentDto.Std, studentDto.Div, studentDto.RollNo);
            if (isStudentExists != null)
                return Result.Fail<bool>(ErrorMessages.StudentyExist, StatusCodes.NotFoundError);
            var student = _mapper.Map<Student>(studentDto);
            student.Id = Guid.NewGuid();
            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();
            return Result.Ok(true);
        }

        public async Task<Result<bool>> DeleteStudentAsync(Guid studentId)
        {
            var isStudentExists = await _context.Students.Where(x=>x.Id ==studentId).FirstOrDefaultAsync();
            if (isStudentExists == null)
                return Result.Fail<bool>(ErrorMessages.StudentNotFound, StatusCodes.NotFoundError);
            _context.Students.Remove(isStudentExists);
            await _context.SaveChangesAsync();
            return Result.Ok(true);
        }

        public async Task<Result<bool>> UpdateStudentAsync(StudentDto studentDto, Guid studentId)
        {
            var isStudentExists = await _context.Students.Where(x => x.Id == studentId).FirstOrDefaultAsync();
            if (isStudentExists == null)
                return Result.Fail<bool>(ErrorMessages.StudentNotFound, StatusCodes.NotFoundError);
            _mapper.Map(studentDto, isStudentExists);
            await _context.SaveChangesAsync();
            return Result.Ok(true);
        }

        public async Task<IEnumerable<StudentDto>> GetStudentDetailsByStdAndDivAsync(int std, char div)
        {
            var students = await _context.Students.Where(x => x.Std == std && x.Div == div).ToListAsync();
            if (students == null)
                throw new Exception();
            return _mapper.Map<IEnumerable<StudentDto>>(students);
        }
    }
}
