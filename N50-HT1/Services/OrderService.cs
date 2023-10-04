using System.Linq.Expressions;
using WebApplication1.Models;
using WebApplication1.Models.Entities;
using WebApplication1.Services.Interfaces;

namespace WebApplication1.Services;

public class OrderService : IOrderService
{
    private List<Order> _orders;

    public OrderService(List<Order> orders)
    {
        _orders = orders;
    }

    public IQueryable<Order> Get(Expression<Func<Order, bool>> predicate)
    {
        return _orders.Where(predicate.Compile()).AsQueryable();
    }

    public Order Create(Order order)
    {
        _orders.Add(order);
        return order;
    }

    public Order Update(Order order)
    {
        var founded = Get(order.Id);
        if (founded != null)
        {
            founded.Amount = order.Amount;
        }

        return founded;
    }

    public Order Get(Guid id)
    {
        return _orders.FirstOrDefault(o => o.Id == id);
    }

    public List<Order> GetAll()
    {
        return _orders;
    }

    public void Delete(Guid id)
    {
        var founded = Get(id);
        _orders.Remove(founded);
    }

    public void Delete(Order order)
    {
        _orders.Remove(order);
    }
}