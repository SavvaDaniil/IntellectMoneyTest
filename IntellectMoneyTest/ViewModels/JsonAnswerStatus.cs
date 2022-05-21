namespace IntellectMoneyTest.ViewModels
{
    public class JsonAnswerStatus
    {
        public string status { get; set; }
        public string errors { get; set; }
        public string message { get; set; }

        public JsonAnswerStatus(string status)
        {
            this.status = status;
        }

        public JsonAnswerStatus(string status, string errors) : this(status)
        {
            this.errors = errors;
        }

        public JsonAnswerStatus(string status, string errors, string message) : this(status, errors)
        {
            this.message = message;
        }
    }
}
