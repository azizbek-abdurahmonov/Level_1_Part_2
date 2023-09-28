using N48_HT1.DataAccess;
using N48_HT1.Models;
using N48_HT1.Services.Interfaces;
using System.Linq.Expressions;

namespace N48_HT1.Services;

public class OrderService : IOrderService
{
    private IDataContext _dataContext;

    public OrderService(IDataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async ValueTask<Order> CreateAsync(Order order, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        await _dataContext.Orders.AddAsync(order, cancellationToken);

        if (saveChanges)
            await _dataContext.Orders.SaveChangesAsync();

        return order;
    }

    public async ValueTask<Order> DeleteAsync(Guid id, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        var foundedOrder = _dataContext.Orders.FirstOrDefault(o => o.Id == id);

        if (foundedOrder == null)
            throw new InvalidOperationException("Order not found!");

        await _dataContext.Orders.RemoveAsync(foundedOrder, cancellationToken);

        if (saveChanges)
            await _dataContext.Orders.SaveChangesAsync(cancellationToken);

        return foundedOrder;
    }

    public async ValueTask<Order> DeleteAsync(Order order, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return await DeleteAsync(order.Id, saveChanges, cancellationToken);
    }

    public IQueryable<Order> Get(Expression<Func<Order, bool>> predicate)
    {
        return _dataContext.Orders.Where(predicate.Compile()).AsQueryable();
    }

    public ValueTask<ICollection<Order>> GetAsync(IEnumerable<Guid> ids, CancellationToken cancellationToken = default)
    {
        return new ValueTask<ICollection<Order>>(_dataContext.Orders.Where(order => ids.Contains(order.Id)).ToList());
    }

    public ValueTask<Order?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return new ValueTask<Order?>(_dataContext.Orders.FirstOrDefault(x => x.Id == id));
    }

    public async ValueTask<Order> UpdateAsync(Order order, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        var foundedOrder = await GetByIdAsync(order.Id);

        if (foundedOrder == null)
            throw new InvalidOperationException("Order not found!");

        foundedOrder.Amount = order.Amount;
        foundedOrder.UserId = order.UserId;

        if (saveChanges)
            await _dataContext.Orders.SaveChangesAsync();

        return foundedOrder;
    }
}
