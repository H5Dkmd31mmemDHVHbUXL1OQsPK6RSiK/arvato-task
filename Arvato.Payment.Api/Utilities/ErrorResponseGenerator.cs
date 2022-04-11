using Arvato.Payment.Api.Models;
using Arvato.Payment.Core.Exceptions;
using Newtonsoft.Json;

namespace Arvato.Payment.Api.Utilities;

public static class ErrorResponseGenerator
{
    private const string ResponseContentType = "application/json";

    public static Task GenerateJsonResponse(
        HttpContext context,
        string message,
        int statusCode,
        JsonSerializerSettings serializerSettings,
        string? errorCode = null,
        Dictionary<string, ExceptionDetails>? errors = null)
    {
        var errorDto = new ErrorResponseModel
        {
            Title = message,
            Status = statusCode,
            ErrorCode = errorCode,
            Errors = errors
        };

        var result = JsonConvert.SerializeObject(errorDto, serializerSettings);

        context.Response.ContentType = ResponseContentType;
        context.Response.StatusCode = statusCode;

        return context.Response.WriteAsync(result);
    }
}