using WebApplication1.Services.Interfaces;

namespace WebApplication1;

public static class Data
{
    public static ValueTask InitializeAsync(IUserService userService, IOrderService orderService)
    {
        userService.Create()
    } 
}