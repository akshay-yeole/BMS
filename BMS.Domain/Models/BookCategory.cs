using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

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
