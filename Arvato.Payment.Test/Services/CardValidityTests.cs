using Arvato.Payment.Core.Enum;
using Arvato.Payment.Core.Services;
using Arvato.Payment.Test.Helpers;

namespace Arvato.Payment.Test.Services;

public class CardValidityTests
{
    [Fact]
    public void Card_Owner_Name_Empty_Owner_Validation_Should_Return_False()
    {
        var cardInfo = TestCardHelper.GetCard(CardType.Visa);
        cardInfo.CardOwner = "";
        var ownerValidationResult = CardValidatorService.ValidateOwner(cardInfo);

        Assert.False(ownerValidationResult);
    }

    [Fact]
    public void Card_Owner_Name_Numeric_Owner_Validation_Should_Return_False()
    {
        var cardInfo = TestCardHelper.GetCard(CardType.Visa);
        cardInfo.CardOwner = "TEST 1 NAME";
        var ownerValidationResult = CardValidatorService.ValidateOwner(cardInfo);

        Assert.False(ownerValidationResult);
    }

    [Fact]
    public void CVC_Too_Long_CVC_Validation_Should_Return_False()
    {
        var cardInfo = TestCardHelper.GetCard(CardType.Visa);
        cardInfo.CVC = "1111";
        var cvcValidationResult = CardValidatorService.ValidateCvc(cardInfo);

        Assert.False(cvcValidationResult);
    }

    [Fact]
    public void CVC_Alphabetic_CVC_Validation_Should_Return_False()
    {
        var cardInfo = TestCardHelper.GetCard(CardType.Visa);
        cardInfo.CVC = "AAA";
        var cvcValidationResult = CardValidatorService.ValidateCvc(cardInfo);

        Assert.False(cvcValidationResult);
    }

    [Fact]
    public void Expired_Card_Date_Validation_Should_Return_False()
    {
        var cardInfo = TestCardHelper.GetCard(CardType.Visa);
        cardInfo.ExpirationDate = DateTime.UtcNow.AddYears(-1);
        var dateValidationResult = CardValidatorService.ValidateCardDate(cardInfo);

        Assert.False(dateValidationResult);
    }

    [Fact]
    public void Invalid_Card_Number_Luhn_Validation_Should_Return_False()
    {
        var cardInfo = TestCardHelper.GetCard(CardType.Visa);
        cardInfo.CardNumber = "12321312312312";
        var dateValidationResult = CardValidatorService.ValidateCardNumberLuhn(cardInfo);

        Assert.False(dateValidationResult);
    }
}