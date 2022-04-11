using Arvato.Payment.Core.Enum;
using Arvato.Payment.Core.Services;
using Arvato.Payment.Test.Helpers;

namespace Arvato.Payment.Test.Services;

public class CardTypeTest
{
    private readonly CardService _cardService;

    public CardTypeTest()
    {
        _cardService = new CardService();
    }

    [Fact]
    public void Correct_Visa_Card_Should_Be_Card_Type_Visa()
    {
        var cardInfo = CardHelper.GetCard(CardType.Visa);

        _cardService.SetCardType(cardInfo);

        Assert.Equal(CardType.Visa, cardInfo.CardType);
    }

    [Fact]
    public void Correct_Amex_Card_Should_Be_Card_Type_Amex()
    {
        var cardInfo = CardHelper.GetCard(CardType.AmericanExpress);

        _cardService.SetCardType(cardInfo);

        Assert.Equal(CardType.AmericanExpress, cardInfo.CardType);
    }

    [Fact]
    public void Correct_Master_Card_Card_Should_Be_Card_Type_Master_Card()
    {
        var cardInfo = CardHelper.GetCard(CardType.MasterCard);

        _cardService.SetCardType(cardInfo);

        Assert.Equal(CardType.MasterCard, cardInfo.CardType);
    }

    [Fact]
    public void Incorrect_Card_Should_Be_Card_Type_Unknown()
    {
        var cardInfo = CardHelper.GetCard(CardType.MasterCard);

        //random card number
        cardInfo.CardNumber = "999781151978097890651111111111";

        _cardService.SetCardType(cardInfo);

        Assert.Equal(CardType.Unknown, cardInfo.CardType);
    }
}