using Arvato.Payment.Core.Exceptions;

namespace Arvato.Payment.Api.Models;

public class ErrorResponseModel
{
    public string? Title { get; set; }
    public int Status { get; set; }
    public string? ErrorCode { get; set; }
    public Dictionary<string, ExceptionDetails>? Errors { get; set; }
}