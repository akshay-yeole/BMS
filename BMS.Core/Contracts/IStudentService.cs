using BMS.Core.Common;
using BMS.Domain.Dto;
using BMS.Domain.Models;

namespace BMS.Core.Contracts
{
    public interface IStudentService
    {
        Task<Result<IEnumerable<StudentDto>>> GetAllStudentsAsync();
        Task<IEnumerable<StudentDto>> GetStudentDetailsByStdAndDivAsync(int std, char div);
        Task<Result<bool>> AddStudentAsync(StudentDto studentDto);
        Task<Result<StudentDto>> GetStudentDetails(int Std, char div, int rollNo);
        Task<Result<bool>> UpdateStudentAsync(StudentDto studentDto, Guid studentId);
        Task<Result<bool>> DeleteStudentAsync(Guid studentId);
    }
}
