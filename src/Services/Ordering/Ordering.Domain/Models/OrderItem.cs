namespace Ordering.Domain.Models;

public class OrderItem : Entity<OrderItemId>
{
    /// <summary>
    /// Initializes a new OrderItem with the specified order, product, quantity, and price.
    /// </summary>
    /// <param name="orderId">Identifier of the order that owns this item.</param>
    /// <param name="productId">Identifier of the product for this item.</param>
    /// <param name="quantity">Number of product units for this item.</param>
    /// <param name="price">Price of the item (per unit).</param>
    internal OrderItem(OrderId orderId, ProductId productId, int quantity, decimal price)
    {
        Id = OrderItemId.Of(Guid.NewGuid());
        OrderId = orderId;
        ProductId = productId;
        Quantity = quantity;
        Price = price;
    }

    public OrderId OrderId { get; private set; } = default!;
    public ProductId ProductId { get; private set; } = default!;
    public int Quantity { get; private set; } = default!;
    public decimal Price { get; private set; } = default!;
}