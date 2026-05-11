using AutoMapper;
using DiscoverEgypt.Core.Entities;
using DiscoverEgypt.Core.Features.Notification.DTOs;

namespace DiscoverEgypt.Core.Mapping
{
    public class NotificationProfile : Profile
    {
        public NotificationProfile()
        {
            CreateMap<Notification, NotificationDto>();

            CreateMap<CreateNotificationDto, Notification>()
                .ForMember(dest => dest.IsRead,
                    opt => opt.MapFrom(_ => false));
        }
    }
}