using System.Net;
using Arvato.Payment.Api.Utilities;
using Arvato.Payment.Core.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Arvato.Payment.Api.Middleware
{
    public class ApiErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ApiErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context,
            IOptions<MvcNewtonsoftJsonOptions> options)
        {
            try
            {
                await _next(context);
            }
            catch (ValidationException exception)
            {
                await ErrorResponseGenerator.GenerateJsonResponse(context, "Validation error",
                    (int)HttpStatusCode.BadRequest, options.Value.SerializerSettings, null, exception.Exceptions);
            }
            catch (Exception exception)
            {
                await ErrorResponseGenerator.GenerateJsonResponse(context, exception.Message,
                    (int)HttpStatusCode.InternalServerError, options.Value.SerializerSettings);
            }
        }
    }
}