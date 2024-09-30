﻿namespace api_fameza.Models.Responses
{
    public class ApiResponse
    {
        public int StatusCode { get; set; }
        public string Message { get; set; } = null!;
        public string Error { get; set; }
        public bool Success { get; set; }
    }
}
