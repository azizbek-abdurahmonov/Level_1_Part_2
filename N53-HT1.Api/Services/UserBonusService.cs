using N53_HT1.Api.Events;
using N53_HT1.Api.Interfaces;
using N53_HT1.Api.Models;

namespace N53_HT1.Api.Services;

public class UserBonusService
{
    private OrderEventStore _orderEventStore;
    private IUserService _userService;
    private IBonusService _bonusService;
    private BonusEventStore _bonusEventStore;
    private IEnumerable<INotificationService> _notificationServices;

    public UserBonusService(OrderEventStore orderEventStore,
         IUserService userService, IBonusService bonusService, BonusEventStore bonusEventStore,
        IEnumerable<INotificationService> notificationServices)
    {
        _orderEventStore = orderEventStore;


        _userService = userService;

        _bonusService = bonusService;

        _bonusEventStore = bonusEventStore;

        _notificationServices = notificationServices;


        _orderEventStore.OrderCreatedEvent += HandleOrderCreatedEventAsync;
    }

    public async ValueTask HandleOrderCreatedEventAsync(Order order)
    {
        //user va uni bonusini olish
        var user = _userService.Get(user => user.Id == order.UserId).FirstOrDefault();
        var bonus = _bonusService.Get(x => x.UserId == user.Id).FirstOrDefault();

        //tekshirish
        var oldBonusLength = bonus.Amount.ToString().Length;
        var newBonusLenght = (bonus.Amount + order.Amount).ToString().Length;

        // bonus ni update qilish
        var updatedBonus = new Bonus(bonus.Id, bonus.Amount + order.Amount, bonus.UserId);
        await _bonusService.UpdateAsync(updatedBonus);


        if (oldBonusLength < newBonusLenght)
        {
            await _bonusEventStore.CreateBonusAchievedEventAsync(bonus);
            return;
        }


        var stringNum = "1";
        for (int _ = 0; _ < oldBonusLength; _++)
        {
            stringNum += "0";
        }

        var num = int.Parse(stringNum);

        foreach (var service in _notificationServices)
        {
            await service.SendAsync(user.Id, $"Bonus olish uchun yana {num - bonus.Amount} qoldi :)");
        }

    }
}
