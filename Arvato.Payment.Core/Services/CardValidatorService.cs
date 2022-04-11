using Arvato.Payment.Core.Entities;
using Arvato.Payment.Core.Enum;
using Arvato.Payment.Core.Exceptions;
using Arvato.Payment.Core.Helpers;
using Arvato.Payment.Core.Interfaces;

namespace Arvato.Payment.Core.Services;

public class CardValidatorService : ICardValidatorService
{
    private readonly ICardService _cardService;

    public CardValidatorService(ICardService cardService)
    {
        _cardService = cardService;
    }

    public bool ValidateCard(PaymentInfo paymentInfo)
    {
        var exceptions = new Dictionary<string, Exception>();

        var cardType = _cardService.GetCardType(paymentInfo);

        if (cardType == CardType.Unknown)
        {
            exceptions.Add(nameof(CardType), new InvalidCardException("Invalid card type!"));
        }

        if (!ValidateOwner(paymentInfo))
        {
            exceptions.Add(nameof(PaymentInfo.CardOwner), new InvalidCardException("Invalid card owner!"));
        }

        if (!ValidateCvc(paymentInfo, cardType))
        {
            exceptions.Add(nameof(PaymentInfo.CVC), new InvalidCardException("Invalid CVC!"));
        }

        if (!ValidateCardDate(paymentInfo))
        {
            exceptions.Add(nameof(PaymentInfo.ExpirationDate), new InvalidCardException("Expired card!"));
        }

        if (!ValidateCardNumberLuhn(paymentInfo))
        {
            exceptions.Add(nameof(PaymentInfo.CardNumber), new InvalidCardException("Invalid card checksum!"));
        }

        if (exceptions.Any())
        {
            throw new ValidationException(exceptions);
        }

        return true;
    }

    public static bool ValidateOwner(PaymentInfo paymentInfo)
    {
        return StringHelpers.IsAllAlphabetic(paymentInfo.CardOwner);
    }

    public static bool ValidateCvc(PaymentInfo paymentInfo, CardType? cardType = null)
    {
        if (!StringHelpers.IsAllNumeric(paymentInfo.CVC)) return false;

        var type = cardType ?? paymentInfo.CardType;
        var lengthResult = type switch
        {
            CardType.Visa or CardType.MasterCard => paymentInfo.CVC!.Length == 3,
            CardType.AmericanExpress => paymentInfo.CVC!.Length == 4,
            _ => false
        };

        return lengthResult;
    }

    public static bool ValidateCardDate(PaymentInfo paymentInfo)
    {
        return paymentInfo.ExpirationDate >= DateTime.UtcNow;
    }

    public static bool ValidateCardNumberLuhn(PaymentInfo paymentInfo)
    {
        var cardNumber = StringHelpers.ReplaceWhitespace(paymentInfo.CardNumber!);
        var cardNumberLength = cardNumber!.Length;

        var nSum = 0;
        var isSecond = false;
        for (var i = cardNumberLength - 1; i >= 0; i--)
        {
            var d = cardNumber[i] - '0';

            if (isSecond)
                d *= 2;

            nSum += d / 10;
            nSum += d % 10;

            isSecond = !isSecond;
        }

        return nSum % 10 == 0;
    }
}