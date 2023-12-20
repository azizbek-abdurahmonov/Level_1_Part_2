using AutoMapper;
using N90_HT1.Application.Common.Notifications.Events;
using N90_HT1.Application.Common.Notifications.Models;

namespace N90_HT1.Infrastructure.Common.Mappers;

public class NotificationRequestMapper : Profile
{
    public NotificationRequestMapper()
    {
        CreateMap<ProcessNotificationEvent, EmailProcessNotificationEvent>();
    }
}