using BMS.Domain.Dto;

namespace BMS.Core.Contracts
{
    public interface IStudentService
    {
        Task<IEnumerable<StudentDto>> GetAllStudentsAsync();
    }
}
