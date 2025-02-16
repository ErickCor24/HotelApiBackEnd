namespace HotelApi.Models.DTO
{
    public class ResponseDTO
    {
        public bool Success { get; set; } = true;
        public string Message { get; set; } = string.Empty;
        public Object? Data { get; set; }

        public ResponseDTO(bool success, string error , object? data)
        {
            this.Success = success;
            this.Message = error;
            this.Data = data;
        }
    }
}
