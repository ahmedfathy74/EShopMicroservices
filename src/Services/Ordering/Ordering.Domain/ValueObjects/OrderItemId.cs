using Ordering.Domain.Exceptions;

namespace Ordering.Domain.ValueObjects;

public record OrderItemId
{
    public Guid Value { get; }
    /// <summary>
/// Initializes a new instance of <see cref="OrderItemId"/> with the specified identifier.
/// </summary>
/// <param name="value">The identifier Guid to assign to the instance; must be greater than <see cref="Guid.Empty"/>.</param>
private OrderItemId(Guid value) => Value = value;
    /// <summary>
    /// Creates an <see cref="OrderItemId"/> from the provided <see cref="Guid"/>, validating the input.
    /// </summary>
    /// <param name="value">The GUID to wrap as an OrderItemId.</param>
    /// <returns>The created <see cref="OrderItemId"/> containing the provided GUID.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="value"/> is null.</exception>
    /// <exception cref="DomainException">Thrown when <paramref name="value"/> is <see cref="Guid.Empty"/>.</exception>
    public static OrderItemId Of(Guid value)
    {
        ArgumentNullException.ThrowIfNull(value);
        if (value == Guid.Empty)
        {
            throw new DomainException("OrderItemId cannot be empty.");
        }

        return new OrderItemId(value);
    }
}
