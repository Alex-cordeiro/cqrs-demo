using System;

namespace CQRS.Demo.API.Domain.Base;

public class BaseEntity
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public DateTime CreatedAt { get; init; } = DateTime.UtcNow;
}
