using System.ComponentModel.DataAnnotations;
using Arvato.Payment.Infrastrcute.JsonConverters;
using Newtonsoft.Json;

namespace Arvato.Payment.Api.Models.V1;

public class PaymentInfoDto
{
    [Required]
    [JsonConverter(typeof(TrimmedStringConverter))]
    public string CardNumber { get; set; }
    [Required]
    public string CVC { get; set; }
    [Required]
    public string CardOwner { get; set; }
    [Required]
    public DateTime ExpirationDate { get; set; }
}