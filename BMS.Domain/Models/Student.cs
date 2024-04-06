namespace BMS.Domain.Models
{
    public class Student 
    {
        public Guid Id { get; set; }
        public int Std { get; set; }
        public char Div { get; set; }
        public int RollNo { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
