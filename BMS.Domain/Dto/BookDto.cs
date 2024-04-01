namespace BMS.Domain.Dto
{
    public class BookDto
    {
        public string BookName { get; set; }
        public bool CopiesAvailable { get; set; }
        public string Author { get; set; }
        public Guid Categoryid { get; set; }
    }
}
