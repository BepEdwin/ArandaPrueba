namespace ArandaPrueba.Api.Responses
{
    public class ResponseApi
    {
        public ResponseApi(bool success, string? message, string? errorMessage, object? data)
        {
            Success = success;
            Message = message;
            ErrorMessage = errorMessage;
            Data = data;
        }

        public bool Success { get; set; }

        public string? Message { get; set; }

        public string? ErrorMessage { get; set; }

        public object? Data { get; set; }
    }
}