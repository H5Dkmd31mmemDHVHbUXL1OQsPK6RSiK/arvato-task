using Arvato.Payment.Core.Entities.Abstract;
using Arvato.Payment.Core.Enum;

namespace Arvato.Payment.Core.Entities;

public class PaymentInfo : BaseEntity
{
    public CardType? CardType { get; set; }
    public string? CardNumber { get; set; }
    public string? CVC { get; set; }
    public string? CardOwner { get; set; }
    public DateTime ExpirationDate { get; set; }
}