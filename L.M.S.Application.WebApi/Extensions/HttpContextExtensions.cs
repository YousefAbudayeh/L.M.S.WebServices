using L.M.S.Application.Common.Responses;
using Microsoft.AspNetCore.Mvc;

namespace L.M.S.Application.WebApi.Extensions;

public static class HttpContextExtensions
{
    public static JsonResult ToJsonResult<T>(this HttpContext httpContext, Response<T> response)
    {
        if (response.Success)
        {
            return new JsonResult(new
            {
                data = response.Data,
                message = response.Message
            })
            {
                StatusCode = response.StatusCode ?? 200
            };
        }

        return new JsonResult(new
        {
            message = response.Message
        })
        {
            StatusCode = response.StatusCode ?? 400
        };
    }
}