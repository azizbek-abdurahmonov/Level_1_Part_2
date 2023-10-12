using N53_HT1.Api.Models;

namespace N53_HT1.Api.Events;

public class BonusEventStore
{
    public event Func<Bonus, ValueTask>? BonusAchievedEvent;

    public async ValueTask CreateBonusAchievedEventAsync(Bonus bonus)
    {
        if (BonusAchievedEvent != null)
            BonusAchievedEvent?.Invoke(bonus);
    }
}
