using System.Text.RegularExpressions;
using Arvato.Payment.Core.Entities;
using Arvato.Payment.Core.Enum;
using Arvato.Payment.Core.Interfaces;

namespace Arvato.Payment.Core.Services;

public class CardService : ICardService
{
    private readonly Dictionary<CardType, string> _cardRegexes = new()
    {
        {
            CardType.Visa,
            "^4[0-9]{12}(?:[0-9]{3})?$"
        },
        {
            CardType.MasterCard,
            "^(5[1-5][0-9]{14}|2(22[1-9][0-9]{12}|2[3-9][0-9]{13}|[3-6][0-9]{14}|7[0-1][0-9]{13}|720[0-9]{12}))$"
        },
        {
            CardType.AmericanExpress,
            "^3[47][0-9]{13}$"
        }
    };

    public void SetCardType(PaymentInfo paymentInfo)
    {
        paymentInfo.CardType = GetCardType(paymentInfo);
    }

    public CardType GetCardType(PaymentInfo paymentInfo)
    {
        foreach (var keyValuePair in _cardRegexes.Where(keyValuePair => Regex.IsMatch(paymentInfo.CardNumber?.Trim()!,
                     keyValuePair.Value)))
        {
            return keyValuePair.Key;
        }

        return CardType.Unknown;
    }
}