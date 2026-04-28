namespace Ordering.Domain.ValueObjects;

public record Payment
{
    public string? CardName { get; } = default!;
    public string CardNumber { get; } = default!;
    public string Expiration { get; } = default!;
    public string CVV { get; } = default!;
    public int PaymentMethod { get; } = default!;

    /// <summary>
    /// Parameterless constructor used by serializers and frameworks to create an instance without initialization.
    /// </summary>
    /// <remarks>
    /// Protected to preserve immutability while allowing framework/deserialization infrastructure to construct the record.
    /// </remarks>
    protected Payment()
    {
    }

    /// <summary>
    /// Initializes a new <see cref="Payment"/> instance with the specified payment details.
    /// </summary>
    /// <param name="cardName">The cardholder name; may be null.</param>
    /// <param name="cardNumber">The card number.</param>
    /// <param name="expiration">The card expiration date, typically in MM/YY or MM/YYYY format.</param>
    /// <param name="cvv">The card verification value.</param>
    /// <param name="paymentMethod">An integer identifying the payment method.</param>
    private Payment(string cardName, string cardNumber, string expiration, string cvv, int paymentMethod)
    {
        CardName = cardName;
        CardNumber = cardNumber;
        Expiration = expiration;
        CVV = cvv;
        PaymentMethod = paymentMethod;
    }

    /// <summary>
    /// Creates a Payment value object from the provided card details.
    /// </summary>
    /// <param name="cardName">The name on the card; must not be null, empty, or whitespace.</param>
    /// <param name="cardNumber">The card number; must not be null, empty, or whitespace.</param>
    /// <param name="expiration">The card expiration value (e.g., month/year) as a string.</param>
    /// <param name="cvv">The card CVV code; must not be null, empty, or whitespace and its length must be at most 3 characters.</param>
    /// <param name="paymentMethod">An integer representing the payment method.</param>
    /// <returns>A new <see cref="Payment"/> initialized with the supplied values.</returns>
    /// <exception cref="ArgumentException">Thrown if <paramref name="cardName"/>, <paramref name="cardNumber"/>, or <paramref name="cvv"/> is null, empty, or whitespace.</exception>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if <paramref name="cvv"/> has a length greater than 3.</exception>
    public static Payment Of(string cardName, string cardNumber, string expiration, string cvv, int paymentMethod)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(cardName);
        ArgumentException.ThrowIfNullOrWhiteSpace(cardNumber);
        ArgumentException.ThrowIfNullOrWhiteSpace(cvv);
        ArgumentOutOfRangeException.ThrowIfGreaterThan(cvv.Length, 3);

        return new Payment(cardName, cardNumber, expiration, cvv, paymentMethod);
    }
}
