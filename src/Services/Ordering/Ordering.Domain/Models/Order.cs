namespace Ordering.Domain.Models;

public class Order : Aggregate<OrderId>
{
    private readonly List<OrderItem> _orderItems = new();
    public IReadOnlyList<OrderItem> OrderItems => _orderItems.AsReadOnly();

    public CustomerId CustomerId { get; private set; } = default!;
    public OrderName OrderName { get; private set; } = default!;
    public Address ShippingAddress { get; private set; } = default!;
    public Address BillingAddress { get; private set; } = default!;
    public Payment Payment { get; private set; } = default!;
    public OrderStatus Status { get; private set; } = OrderStatus.Pending;
    public decimal TotalPrice
    {
        get => OrderItems.Sum(x => x.Price * x.Quantity);
        private set { }
    }

    /// <summary>
    /// Create a new Order aggregate initialized with the provided identity, customer, addresses, and payment information.
    /// </summary>
    /// <param name="id">The unique identifier for the order.</param>
    /// <param name="customerId">Identifier of the customer who placed the order.</param>
    /// <param name="orderName">The display name or title for the order.</param>
    /// <param name="shippingAddress">The shipping address for the order.</param>
    /// <param name="billingAddress">The billing address for the order.</param>
    /// <param name="payment">Payment details associated with the order.</param>
    /// <returns>The newly created Order with its status set to Pending and an OrderCreatedEvent added to its domain events.</returns>
    public static Order Create(OrderId id, CustomerId customerId, OrderName orderName, Address shippingAddress, Address billingAddress, Payment payment)
    {
        var order = new Order
        {
            Id = id,
            CustomerId = customerId,
            OrderName = orderName,
            ShippingAddress = shippingAddress,
            BillingAddress = billingAddress,
            Payment = payment,
            Status = OrderStatus.Pending
        };

        order.AddDomainEvent(new OrderCreatedEvent(order));

        return order;
    }

    /// <summary>
    /// Updates the order's customer-facing details and status.
    /// </summary>
    /// <param name="orderName">The new name or label for the order.</param>
    /// <param name="shippingAddress">The new shipping address for the order.</param>
    /// <param name="billingAddress">The new billing address for the order.</param>
    /// <param name="payment">The new payment information for the order.</param>
    /// <param name="status">The new order status.</param>
    /// <remarks>
    /// Adds an OrderUpdatedEvent to the order's domain events after applying the changes.
    /// </remarks>
    public void Update(OrderName orderName, Address shippingAddress, Address billingAddress, Payment payment, OrderStatus status)
    {
        OrderName = orderName;
        ShippingAddress = shippingAddress;
        BillingAddress = billingAddress;
        Payment = payment;
        Status = status;

        AddDomainEvent(new OrderUpdatedEvent(this));
    }

    /// <summary>
    /// Adds a new order item for the specified product to this order.
    /// </summary>
    /// <param name="productId">The identifier of the product to add.</param>
    /// <param name="quantity">The number of units to add; must be greater than zero.</param>
    /// <param name="price">The unit price for the item; must be greater than zero.</param>
    /// <exception cref="System.ArgumentOutOfRangeException">Thrown when <paramref name="quantity"/> or <paramref name="price"/> is less than or equal to zero.</exception>
    public void Add(ProductId productId, int quantity, decimal price)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(quantity);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(price);

        var orderItem = new OrderItem(Id, productId, quantity, price);
        _orderItems.Add(orderItem);
    }

    /// <summary>
    /// Removes the first order item that matches the specified product identifier from the order. If no matching item exists, no action is taken.
    /// </summary>
    /// <param name="productId">The product identifier of the item to remove.</param>
    public void Remove(ProductId productId)
    {
        var orderItem = _orderItems.FirstOrDefault(x => x.ProductId == productId);
        if (orderItem is not null)
        {
            _orderItems.Remove(orderItem);
        }
    }
}