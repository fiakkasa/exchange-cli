using System.Text.Json.Serialization;

namespace ExchangeCli.Models;

public record struct Query
{
    [JsonPropertyName("from")]
    public string? From { get; set; }

    [JsonPropertyName("to")]
    public string? To { get; set; }

    [JsonPropertyName("amount")]
    public double? Amount { get; set; }
}
