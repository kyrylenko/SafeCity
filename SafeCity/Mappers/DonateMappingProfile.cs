using System;
using AutoMapper;
using SafeCity.Core.Entities;
using SafeCity.Services.DTOs;

namespace SafeCity.Mappers
{
    public class DonateMappingProfile: Profile
    {
        public DonateMappingProfile()
        {
            CreateMap<LiqPayResponse, Donation>()
                .ForMember(dest => dest.Id,
                    opt => opt.MapFrom(
                        src => src.OrderId))
                .ForMember(dest => dest.Action,
                    opt => opt.MapFrom(
                        src => MapPaymentAction(src.Action)))
                .ForMember(dest => dest.DateTime,
                    opt => opt.MapFrom(
                        src => DateTime.Now));
        }

        public static PaymentAction MapPaymentAction(string action)
        {
            return action switch
            {
                "pay" => PaymentAction.Pay,
                "paydonate" => PaymentAction.PayDonate,
                "subscribe" => PaymentAction.Subscribe,
                "regular" => PaymentAction.Regular,
                _ => PaymentAction.None
            };
        }
    }
}
