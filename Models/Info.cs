using System.Text.Json.Serialization;

namespace ExchangeCli.Models;

public record struct Info
{
    [JsonPropertyName("rate")]
    public double? Rate { get; set; }
}
