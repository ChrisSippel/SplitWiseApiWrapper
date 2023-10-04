using System.Text.Json.Serialization;

namespace splitwise_csharp.Models;

public sealed class Balance
{
    [JsonPropertyName("currency_code")]
    public string CurrencyCode { get; init; }

    [JsonPropertyName("amount")]
    public string Amount { get; init; }
}