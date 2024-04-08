namespace BMS.API.Common
{
    public class ErrorModel
    {
        public string Code { get; set; }
        public string Message { get; set; }
        public bool IsErrorOrEcxception { get; set; } = true;
        public List<string> Errors { get; set; } = new();
    }
}
