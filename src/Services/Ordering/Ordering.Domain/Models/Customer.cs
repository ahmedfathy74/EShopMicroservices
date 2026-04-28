using Ordering.Domain.Abstractions;
using Ordering.Domain.ValueObjects;

namespace Ordering.Domain.Models;

public class Customer : Entity<CustomerId>
{
    public string Name { get; private set; } = default!;
    public string Email { get; private set; } = default!;

    /// <summary>
    /// Create a Customer with the specified identifier, name, and email.
    /// </summary>
    /// <param name="id">The customer's identifier.</param>
    /// <param name="name">The customer's full name; must not be null or whitespace.</param>
    /// <param name="email">The customer's email address; must not be null or whitespace.</param>
    /// <returns>The created <see cref="Customer"/> instance.</returns>
    /// <exception cref="ArgumentException">Thrown if <paramref name="name"/> or <paramref name="email"/> is null or consists only of white-space characters.</exception>
    public static Customer Create(CustomerId id, string name, string email)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        ArgumentException.ThrowIfNullOrWhiteSpace(email);

        var customer = new Customer
        {
            Id = id,
            Name = name,
            Email = email
        };

        return customer;
    }
}