using N48_HT1.Models;
using N48_HT1.Services.Interfaces;

namespace N48_HT1.Services
{
    public class UserOrders : IUserOrders
    {
        private IOrderService _orderService;

        public UserOrders(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public IQueryable<Order> GetUserOrders(Guid userId)
        {
            return _orderService.Get(x => x.Id == userId);
        }
    }
}
