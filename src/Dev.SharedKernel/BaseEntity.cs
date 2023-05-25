using System.ComponentModel.DataAnnotations.Schema;

namespace Dev.SharedKernel;
public abstract class BaseEntity
{
    private List<DomainEventBase> _domainEvents = new();
    [NotMapped]
    public IEnumerable<DomainEventBase> DomainEvents => _domainEvents.AsReadOnly();

    protected void RegisterDomainEvent(DomainEventBase domainEvent) => _domainEvents.Add(domainEvent);
    internal void ClearDomainEvents() => _domainEvents.Clear();

    public void CopyValues<TEntity>(TEntity source, TEntity target) where TEntity : BaseEntity
    {
        Type t = typeof(TEntity);

        var properties = t.GetProperties().Where(prop => prop.CanRead && prop.CanWrite);

        foreach (var prop in properties)
        {
            var value = prop.GetValue(source, null);
            if (value != null)
                prop.SetValue(target, value, null);
        }
    }
}
