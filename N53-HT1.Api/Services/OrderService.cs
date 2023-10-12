using N53_HT1.Api.DataAccess;
using N53_HT1.Api.Events;
using N53_HT1.Api.Interfaces;
using N53_HT1.Api.Models;
using System.Linq.Expressions;

namespace N53_HT1.Api.Services
{
    public class OrderService : IOrderService
    {
        private readonly IDataContext _context;
        private readonly OrderEventStore _eventStore;

        public OrderService(IDataContext context, OrderEventStore eventStore)
        {
            _context = context;
            _eventStore = eventStore;
        }

        public async ValueTask<Order> CreateAsync(Order order)
        {
            var entity = await _context.Orders.AddAsync(order);

            await _context.SaveChangesAsync();

            await _eventStore.CreateOrderAddedEventAsync(order);

            return entity.Entity;
        }

        public IQueryable<Order> Get(Expression<Func<Order, bool>> predicate)
            => _context.Orders.Where(predicate.Compile()).AsQueryable();
    }
}