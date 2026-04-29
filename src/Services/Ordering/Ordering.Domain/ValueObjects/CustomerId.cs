using Ordering.Domain.Exceptions;

namespace Ordering.Domain.ValueObjects;

public record CustomerId
{
    public Guid Value { get; }
    /// <summary>
/// Initializes a new instance of CustomerId with the specified GUID.
/// </summary>
/// <param name="value">The GUID to store as the customer identifier.</param>
private CustomerId(Guid value) => Value = value;
    /// <summary>
    /// Creates a new <see cref="CustomerId"/> from the provided GUID after validating it.
    /// </summary>
    /// <param name="value">The GUID to wrap as a <see cref="CustomerId"/>.</param>
    /// <returns>A new <see cref="CustomerId"/> instance containing the provided GUID.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="value"/> is null.</exception>
    /// <exception cref="Ordering.Domain.Exceptions.DomainException">Thrown when <paramref name="value"/> is <see cref="Guid.Empty"/>.</exception>
    public static CustomerId Of(Guid value)
    {
        ArgumentNullException.ThrowIfNull(value);
        if (value == Guid.Empty)
        {
            throw new DomainException("CustomerId cannot be empty.");
        }

        return new CustomerId(value);
    }
}
