using System.ComponentModel.DataAnnotations;
using Arvato.Payment.Infrastrcute.JsonConverters;
using Newtonsoft.Json;

namespace Arvato.Payment.Api.Models.V1;

public class PaymentInfoDto
{
    [Required]
    [JsonConverter(typeof(NoWhiteSpaceStringConverter))]
    public string CardNumber { get; set; } = null!;

    [Required]
    [JsonConverter(typeof(NoWhiteSpaceStringConverter))]
    public string CVC { get; set; } = null!;

    [Required] public string CardOwner { get; set; } = null!;

    [Required] public DateTime ExpirationDate { get; set; }
}