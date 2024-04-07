namespace BMS.Domain.Dto
{
    public class LibraryTransactionDto
    {
        public Guid BookCode { get; set; }
        public Guid StudentId { get; set; }
        public DateTime IssuedDate { get; set; }
        public DateTime ReturnedDate { get; set; }
        public DateTime ExpectedReturnedDate { get; set; }
    }
}
