using System;

namespace API.Errors
{
    public class ApiResponse
    {
        public ApiResponse(int statusCode, string messageError = null)
        {
            StatusCode = statusCode;
            MessageError = messageError ?? DefaultMessageError(StatusCode);
        }


        public int StatusCode { get; set; }
        public string MessageError { get; set; }

        private string DefaultMessageError(int statusCode)
        {
            return statusCode switch
            {
                400 => "A bad Request, you have made",
                401 => "Authorized, you are not",
                404 => "Resource found, it was not",
                500 => "Errors are the path to the dark side, Errors Lead to anger, Anger lead to hate, Hate lead to carrer change ",
                _=> null
            };
        }
    }
}
