namespace Ordering.Domain.Exceptions;

public class DomainException : Exception
{
    /// <summary>
    /// Initializes a new DomainException that embeds the provided text in a standardized domain-layer error message.
    /// </summary>
    /// <param name="message">A descriptive message explaining the domain error.</param>
    public DomainException(string message)
        : base($"Domain Exception: \"{message}\" throws from Domain Layer.")
    {
    }
}
