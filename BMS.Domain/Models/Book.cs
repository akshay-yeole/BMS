using System.ComponentModel.DataAnnotations;

namespace BMS.Domain.Models
{
    public class Book
    {
        [Key]
        public Guid BookCode { get; set; }
        public string BookName { get; set; }
        public bool CopiesAvailable { get; set; }
        public string Author { get; set; }
        
        public Guid Categoryid { get; set; }
        public BookCategory Category { get; set; }
    }
}
