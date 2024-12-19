namespace Pizza4Ps.PizzaService.API.Models
{
    public class ApiResponse
    {
        public bool Success { get; set; }
        public object? Result { get; set; }
        public string Message { get; set; }
        public int StatusCode { get; set; }

        // Constructor cho thành công
        public ApiResponse()
        {
            Success = true;
        }
    }
}
