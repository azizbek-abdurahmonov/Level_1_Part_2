namespace N90_HT1.Domain.Common.Entities;

public abstract class Entity : IEntity
{
    public Guid Id { get; set; }
}