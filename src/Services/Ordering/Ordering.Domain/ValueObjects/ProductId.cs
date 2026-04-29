using Ordering.Domain.Exceptions;

namespace Ordering.Domain.ValueObjects;

public record ProductId
{
    public Guid Value { get; }
    /// <summary>
/// Initializes a new ProductId with the specified Guid value.
/// </summary>
/// <param name="value">The Guid to wrap as the ProductId's underlying value.</param>
private ProductId(Guid value) => Value = value;
    /// <summary>
    /// Create a ProductId from the provided GUID.
    /// </summary>
    /// <param name="value">The underlying GUID to wrap as a ProductId.</param>
    /// <returns>A new <see cref="ProductId"/> instance containing the specified GUID.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="value"/> is null.</exception>
    /// <exception cref="DomainException">Thrown when <paramref name="value"/> is <see cref="Guid.Empty"/> with message "ProductId cannot be empty."</exception>
    public static ProductId Of(Guid value)
    {
        ArgumentNullException.ThrowIfNull(value);
        if (value == Guid.Empty)
        {
            throw new DomainException("ProductId cannot be empty.");
        }

        return new ProductId(value);
    }
}
