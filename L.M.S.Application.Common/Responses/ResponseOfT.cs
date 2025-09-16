using System.Net;

namespace L.M.S.Application.Common.Responses;

public class Response<T> : ResponseBase
{
    public T Data { get; set; }

    public static Response<T> Fail(string message, HttpStatusCode statusCode = HttpStatusCode.BadRequest)
    {
        return new Response<T>
        {
            Success = false,
            Message = message,
            StatusCode = (int)statusCode
        };
    }

    public static Response<T> InternalServerError(string? message = null)
    {
        return new Response<T>
        {
            Success = false,
            Message = message ?? "Sorry, something went wrong",
            StatusCode = (int)HttpStatusCode.InternalServerError
        };
    }

    public static Response<T> Forbidden(string? message = null)
    {
        return new Response<T>
        {
            Success = false,
            Message = message ?? "Access is forbidden",
            StatusCode = (int)HttpStatusCode.Forbidden
        };
    }

    public static Response<T> Succeed(T data, string message, HttpStatusCode statusCode = HttpStatusCode.OK)
    {
        return new Response<T>
        {
            Success = true,
            Message = message,
            StatusCode = (int)statusCode,
            Data = data
        };
    }

    public static Response<T> Succeed(T data, HttpStatusCode statusCode)
    {
        return new Response<T>
        {
            Success = true,
            Message = default(string),
            StatusCode = (int)statusCode,
            Data = data
        };
    }

    public static Response<T> Succeed(HttpStatusCode statusCode = HttpStatusCode.OK)
    {
        return Succeed(default(T), default(string), statusCode);
    }

    public static Response<T> Succeed(T data)
    {
        return Succeed(data, default(string));
    }
}
