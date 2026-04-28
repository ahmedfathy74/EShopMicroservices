using Ordering.Domain.Exceptions;

namespace Ordering.Domain.ValueObjects;

public record OrderId
{
    public Guid Value { get; }
    /// <summary>
/// Initializes a new instance of <see cref="OrderId"/> with the specified identifier.
/// </summary>
/// <param name="value">The GUID to use as the underlying order identifier.</param>
private OrderId(Guid value) => Value = value;
    /// <summary>
    /// Creates an <see cref="OrderId"/> from the specified GUID and enforces its invariants.
    /// </summary>
    /// <param name="value">The GUID to wrap as an OrderId.</param>
    /// <returns>An <see cref="OrderId"/> containing the provided GUID.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="value"/> is null.</exception>
    /// <exception cref="DomainException">Thrown when <paramref name="value"/> is <see cref="Guid.Empty"/> with message "OrderId cannot be empty."</exception>
    public static OrderId Of(Guid value)
    {
        ArgumentNullException.ThrowIfNull(value);
        if (value == Guid.Empty)
        {
            throw new DomainException("OrderId cannot be empty.");
        }

        return new OrderId(value);
    }
}