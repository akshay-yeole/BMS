namespace BMS.Domain.Dto
{
    public class StudentDto
    {
        public Guid Id { get; set; }
        public int Std { get; set; }
        public char Div { get; set; }
        public int RollNo { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
