using FluentValidation;
using N90_HT1.Application.Common.Identity.Services;
using N90_HT1.Application.Common.Notifications.Events;
using N90_HT1.Domain.Enums;

namespace N90_HT1.Infrastructure.Common.Validators;

public class NotificationRequestValidator : AbstractValidator<ProcessNotificationEvent>
{
    public NotificationRequestValidator(IUserService userService)
    {
        // TODO : to external
        var templatesRequireSender = new List<NotificationTemplateType>
        {
            NotificationTemplateType.ReferralNotification
        };

        RuleFor(request => request.SenderUserId)
            .NotEqual(Guid.Empty)
            .NotNull()
            .When(request => templatesRequireSender.Contains(request.TemplateType))
            .CustomAsync(
                async (senderUserId, context, cancellationToken) =>
                {
                    var user = await userService.GetByIdAsync(senderUserId, true, cancellationToken);

                    if (user is null)
                        context.AddFailure("Sender user not found");
                }
            );

        RuleFor(request => request.ReceiverUserId)
            .NotEqual(Guid.Empty)
            .CustomAsync(
                async (senderUserId, context, cancellationToken) =>
                {
                    var user = await userService.GetByIdAsync(senderUserId, true, cancellationToken);

                    if (user is null)
                        context.AddFailure("Sender user not found");
                }
            );
    }
}