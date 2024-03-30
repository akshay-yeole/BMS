using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMS.Domain.Dto
{
    public class BookDto
    {
        public Guid BookCode { get; set; }
        public string BookName { get; set; }
        public bool CopiesAvailable { get; set; }
        public string Author { get; set; }
        public Guid Categoryid { get; set; }
    }
}
