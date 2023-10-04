using System.Linq.Expressions;
using WebApplication1.Models;
using WebApplication1.Models.Entities;

namespace WebApplication1.Services.Interfaces;

public interface IOrderService
{
    IQueryable<Order> Get(Expression<Func<Order, bool>> predicate);
    Order Create(Order order);
    
    Order Update(Order order);
    
    Order Get(Guid id);
    
    List<Order> GetAll();
    
    void Delete(Guid id);
    
    void Delete(Order order);
}