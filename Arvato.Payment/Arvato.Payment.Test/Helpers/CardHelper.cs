using Arvato.Payment.Core.Entities;
using Arvato.Payment.Core.Enum;

namespace Arvato.Payment.Test.Helpers;

public static class CardHelper
{
    public static PaymentInfo GetCard(CardType type)
    {
        var card = new PaymentInfo()
        {
            CardOwner = "CARD OWNER",
            CVC = "911",
            ExpirationDate = DateTime.UtcNow
        };

        card.CardNumber = type switch
        {
            CardType.Visa => "4111111111111111",
            CardType.AmericanExpress => "378282246310005",
            CardType.MasterCard => "5555555555554444",
            _ => card.CardNumber
        };

        return card;
    }
}