using AutoMapper;
using N90_HT1.Application.Common.Notifications.Models;
using N90_HT1.Domain.Entities;

namespace N90_HT1.Infrastructure.Common.Mappers;

public class NotificationHistoryMapper : Profile
{
    public NotificationHistoryMapper()
    {
        CreateMap<EmailMessage, EmailHistory>()
            .ForMember(dest => dest.TemplateId, opt => opt.MapFrom(src => src.Template.Id))
            .ForMember(dest => dest.Content, opt => opt.MapFrom(src => src.Body));
    }
}