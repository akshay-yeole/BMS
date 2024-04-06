using System.ComponentModel.DataAnnotations;

namespace BMS.Domain.Models
{
    public class BookCategory 
    {
        [Key]
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}
