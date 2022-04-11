namespace Arvato.Payment.Core.Exceptions;

public class InvalidCardException : Exception
{
    public InvalidCardException(string message) : base(message)
    {
    }
}