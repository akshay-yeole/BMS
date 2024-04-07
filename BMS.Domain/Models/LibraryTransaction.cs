using System.ComponentModel.DataAnnotations;

namespace BMS.Domain.Models
{
    public class LibraryTransaction
    {
        [Key]
        public Guid Id { get; set; }
        public Guid BookCode { get; set; }
        public Guid StudentId { get; set; }
        public DateTime IssuedDate { get; set; }
        public DateTime? ReturnedDate { get; set; }
        public DateTime ExpectedReturnedDate { get; set; }
    }
}
