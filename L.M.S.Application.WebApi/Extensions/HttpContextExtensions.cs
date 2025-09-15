using L.M.S.Application.Common.Responses;
using Microsoft.AspNetCore.Mvc;

namespace L.M.S.Application.WebApi.Extensions;

public static class HttpContextExtensions
{
    public static JsonResult ToJsonResult<T>(this HttpContext httpContext, Response<T> response)
    {
        return new JsonResult(response.Success ? response.Data : response)
        {
            StatusCode = response.StatusCode ?? (response.Success ? 200 : 400)
        };
    }
}