namespace MVC5.Helpers
{
    public class JsonResultBase
    {
        public bool IsValid { get; set; }
        public string Message { get; set; }
        public string[] Errors { get; set; }
        public bool Succeeded { get; set; }

        public JsonResultBase()
        {
            this.IsValid = false;
            this.Succeeded = false;
        }
    }
}