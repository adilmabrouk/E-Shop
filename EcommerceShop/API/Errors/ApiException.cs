namespace API.Errors
{
    public class ApiException : ApiResponse
    {
        public ApiException(int statusCode, string messageError = null,string details = null) : base(statusCode, messageError)
        {
            Details = details;  
        }
        public string Details { get; set; }
    }
}
