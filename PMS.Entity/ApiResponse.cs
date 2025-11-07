using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace PMS.Entity
{
    public class ApiResponse<T>
    {
        public bool Result { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public string Message { get; set; } = string.Empty;
        public T Data { get; set; }
    }

    public static class JsonResponse
    {
        public static JsonResult GenerateResponse<T>(bool result, T data, HttpStatusCode statusCode, string message)
        {
            return new JsonResult(new ApiResponse<T>
            {
                Result = result,
                Data = data,
                StatusCode = statusCode,
                Message = message,
            });
        }

        public static JsonResult SuccessResponse<T>(T data, string message)
        {
            return GenerateResponse(true, data, HttpStatusCode.OK, message);

        }

        public static JsonResult FailureResponse(string message, HttpStatusCode statusCode = HttpStatusCode.BadRequest)
        {
            return GenerateResponse(false, string.Empty, statusCode, message);
        }


    }
}
