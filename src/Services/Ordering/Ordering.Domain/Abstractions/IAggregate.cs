namespace Ordering.Domain.Abstractions;

public interface IAggregate<T> : IAggregate, IEntity<T>
{
}

public interface IAggregate : IEntity
{
    IReadOnlyList<IDomainEvent> DomainEvents { get; }
    /// <summary>
/// Retrieves and removes all domain events currently recorded by the aggregate.
/// </summary>
/// <returns>An array containing the domain events that were cleared; empty if there were none.</returns>
IDomainEvent[] ClearDomainEvents();
}
