using Arvato.Payment.Core.Entities;
using Arvato.Payment.Core.Enum;

namespace Arvato.Payment.Core.Interfaces;

public interface ICardService
{
    void SetCardType(PaymentInfo paymentInfo);
    CardType GetCardType(PaymentInfo paymentInfo);
}