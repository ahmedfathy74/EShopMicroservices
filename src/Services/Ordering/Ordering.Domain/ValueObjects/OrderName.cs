namespace Ordering.Domain.ValueObjects;

public record OrderName
{
    private const int DefaultLength = 5;
    public string Value { get; }
    /// <summary>
/// Initializes a new instance of the <see cref="OrderName"/> record with the specified value.
/// </summary>
/// <param name="value">The validated order name to assign to <see cref="Value"/>.</param>
private OrderName(string value) => Value = value;
    /// <summary>
    /// Creates an <see cref="OrderName"/> from the provided string after validating it.
    /// </summary>
    /// <param name="value">The order name string that must be non-empty, not whitespace, and exactly <see cref="DefaultLength"/> characters long.</param>
    /// <returns>The created <see cref="OrderName"/> containing the validated value.</returns>
    /// <exception cref="ArgumentException">Thrown when <paramref name="value"/> is null, empty, or consists only of whitespace.</exception>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="value"/> length is not equal to <see cref="DefaultLength"/>.</exception>
    public static OrderName Of(string value)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(value);
        ArgumentOutOfRangeException.ThrowIfNotEqual(value.Length, DefaultLength);

        return new OrderName(value);
    }
}