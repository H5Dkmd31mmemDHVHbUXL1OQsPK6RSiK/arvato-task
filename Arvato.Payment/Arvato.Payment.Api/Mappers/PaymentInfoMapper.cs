using Arvato.Payment.Api.Models.V1;
using Arvato.Payment.Core.Entities;
using AutoMapper;

namespace Arvato.Payment.Api.Mappers;

public class PaymentInfoMapper : Profile
{
    public PaymentInfoMapper()
    {
        CreateMap<PaymentInfoDto, PaymentInfo>();
    }
}