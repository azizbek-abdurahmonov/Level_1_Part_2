using N48_HT1.Models;

namespace N48_HT1.Services.Interfaces;

public interface IUserOrders
{
    IQueryable<Order> GetUserOrders(Guid userId);
}
