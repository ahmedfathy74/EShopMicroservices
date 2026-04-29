namespace Ordering.Domain.ValueObjects;

public record Address
{
    public string FirstName { get; } = default!;
    public string LastName { get; } = default!;
    public string? EmailAddress { get; } = default!;
    public string AddressLine { get; } = default!;
    public string Country { get; } = default!;
    public string State { get; } = default!;
    public string ZipCode { get; } = default!;
    /// <summary>
    /// Initializes a new instance of <see cref="Address"/> for use by serializers or persistence frameworks.
    /// </summary>
    protected Address()
    {
    }

    /// <summary>
    /// Initializes a new <see cref="Address"/> instance with the provided name, contact, and location values.
    /// </summary>
    /// <param name="firstName">The recipient's first name.</param>
    /// <param name="lastName">The recipient's last name.</param>
    /// <param name="emailAddress">The recipient's email address, if any.</param>
    /// <param name="addressLine">The primary street or mailing address line.</param>
    /// <param name="country">The country name or code.</param>
    /// <param name="state">The state, province, or region.</param>
    /// <param name="zipCode">The postal or ZIP code.</param>
    private Address(string firstName, string lastName, string emailAddress, string addressLine, string country, string state, string zipCode)
    {
        FirstName = firstName;
        LastName = lastName;
        EmailAddress = emailAddress;
        AddressLine = addressLine;
        Country = country;
        State = state;
        ZipCode = zipCode;
    }

    /// <summary>
    /// Creates a new Address value object from the provided name and address components.
    /// </summary>
    /// <param name="emailAddress">The contact email for the address; must not be null, empty, or whitespace.</param>
    /// <param name="addressLine">The primary street address; must not be null, empty, or whitespace.</param>
    /// <returns>The created Address instance populated with the provided values.</returns>
    /// <exception cref="ArgumentException">Thrown when <paramref name="emailAddress"/> or <paramref name="addressLine"/> is null, empty, or consists only of white-space characters.</exception>
    public static Address Of(string firstName, string lastName, string emailAddress, string addressLine, string country, string state, string zipCode)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(emailAddress);
        ArgumentException.ThrowIfNullOrWhiteSpace(addressLine);

        return new Address(firstName, lastName, emailAddress, addressLine, country, state, zipCode);
    }
}