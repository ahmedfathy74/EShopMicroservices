namespace Ordering.Domain.Models;

public class Product : Entity<ProductId>
{
    public string Name { get; private set; } = default!;
    public decimal Price { get; private set; } = default!;

    /// <summary>
    /// Creates a new Product with the specified identifier, name, and price.
    /// </summary>
    /// <param name="id">The identifier to assign to the created product.</param>
    /// <param name="name">The product name; must not be null, empty, or whitespace.</param>
    /// <param name="price">The product price; must be greater than zero.</param>
    /// <returns>The newly created <see cref="Product"/> instance.</returns>
    /// <exception cref="ArgumentException">Thrown when <paramref name="name"/> is null, empty, or consists only of whitespace.</exception>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="price"/> is less than or equal to zero.</exception>
    public static Product Create(ProductId id, string name, decimal price)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(price);

        var product = new Product
        {
            Id = id,
            Name = name,
            Price = price
        };

        return product;
    }
}