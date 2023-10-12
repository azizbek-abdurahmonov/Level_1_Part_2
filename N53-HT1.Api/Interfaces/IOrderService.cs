using N53_HT1.Api.Models;
using System.Linq.Expressions;

namespace N53_HT1.Api.Interfaces;

public interface IOrderService
{
    IQueryable<Order> Get(Expression<Func<Order, bool>> predicate);

    ValueTask<Order> CreateAsync(Order order);
}
