using FluentValidation;
using N90_HT1.Application.Common.Notifications.Events;

namespace N90_HT1.Infrastructure.Common.Validators;

public class ProcessNotificationEventValidator : AbstractValidator<ProcessNotificationEvent>
{
    public ProcessNotificationEventValidator()
    {
        RuleFor(history => history.ReceiverUserId).NotEqual(Guid.Empty);
    }
}