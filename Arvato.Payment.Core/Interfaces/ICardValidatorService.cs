using Arvato.Payment.Core.Entities;

namespace Arvato.Payment.Core.Interfaces;

public interface ICardValidatorService
{
    bool ValidateCard(PaymentInfo paymentInfo);
}