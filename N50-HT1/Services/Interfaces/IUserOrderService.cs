using WebApplication1.Models;
using WebApplication1.Models.Entities;

namespace WebApplication1.Services.Interfaces;

public interface IUserOrderService
{
    KeyValuePair<User, List<Order>> GetUserOrdersByUserId(Guid userId);
}