namespace Arvato.Payment.Core.Exceptions;

public class ValidationException : Exception
{
    public Dictionary<string, ExceptionDetails>? Exceptions { get; set; }

    public ValidationException(Dictionary<string, Exception> exceptions)
    {
        Exceptions = exceptions.ToDictionary(kvp =>
            kvp.Key, kvp => new ExceptionDetails()
        {
            Message = kvp.Value.Message,
            Type = kvp.Value.GetType().ToString()
        });
    }
}