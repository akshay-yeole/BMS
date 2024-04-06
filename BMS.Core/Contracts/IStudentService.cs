using BMS.Domain.Dto;
using BMS.Domain.Models;

namespace BMS.Core.Contracts
{
    public interface IStudentService
    {
        Task<IEnumerable<StudentDto>> GetAllStudentsAsync();
        Task<StudentDto> AddStudentAsync(StudentDto studentDto);
        Student GetStudentDetails(int Std, char div, int rollNo);
        Task UpdateStudentAsync(StudentDto studentDto, Guid studentId);
        Task DeleteStudentAsync(Guid studentId);
    }
}
