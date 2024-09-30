namespace api_fameza.Models.Responses
{
    public class DataResponse<T> : ApiResponse
    {
        public T? Data { get; set; }
    }
}
