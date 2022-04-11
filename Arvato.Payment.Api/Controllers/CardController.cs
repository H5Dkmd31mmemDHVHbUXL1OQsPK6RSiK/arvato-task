using System.ComponentModel.DataAnnotations;
using Arvato.Payment.Api.Models;
using Arvato.Payment.Api.Models.V1;
using Arvato.Payment.Core.Entities;
using Arvato.Payment.Core.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Arvato.Payment.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CardController : Controller
{
    private readonly ICardService _cardService;
    private readonly ICardValidatorService _cardValidatorService;
    private readonly IMapper _mapper;

    public CardController(ICardService cardService, IMapper mapper, ICardValidatorService cardValidatorService)
    {
        _cardService = cardService;
        _mapper = mapper;
        _cardValidatorService = cardValidatorService;
    }

    [HttpPost("validate")]
    [SwaggerOperation(Summary = "Endpoint for validating card and getting its' type")]
    [ProducesResponseType(200, Type = typeof(ValidationResultDto))]
    [ProducesResponseType(400, Type = typeof(ErrorResponseModel))]
    [ProducesResponseType(500, Type = typeof(ErrorResponseModel))]
    public IActionResult ValidateCard([FromBody] [Required] PaymentInfoDto infoDto)
    {
        var mapped = _mapper.Map<PaymentInfo>(infoDto);
        _cardValidatorService.ValidateCard(mapped);
        _cardService.SetCardType(mapped);

        return Ok(new ValidationResultDto
        {
            CardType = mapped.CardType.ToString()
        });
    }
}