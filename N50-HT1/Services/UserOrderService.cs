using WebApplication1.Models;
using WebApplication1.Models.Entities;
using WebApplication1.Services.Interfaces;

namespace WebApplication1.Services;

public class UserOrderService : IUserOrderService
{
    private IUserService _userService;
    private IOrderService _orderService;

    public UserOrderService(IUserService userService, IOrderService orderService)
    {
        _userService = userService;
        _orderService = orderService;
    }

    public KeyValuePair<User, List<Order>> GetUserOrdersByUserId(Guid userId)
    {
        return new KeyValuePair<User, List<Order>>(_userService.Get(userId),
            _orderService.Get(order => order.UserId == userId).ToList());
    }
}