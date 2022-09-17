using System.Text.Json.Serialization;

namespace ExchangeCli.Models;

public record struct Response
{
    [JsonPropertyName("success")]
    public bool? Success { get; set; }

    [JsonPropertyName("query")]
    public Query? Query { get; set; }

    [JsonPropertyName("info")]
    public Info? Info { get; set; }

    [JsonPropertyName("historical")]
    public bool? Historical { get; set; }

    [JsonPropertyName("date")]
    public DateTimeOffset? Date { get; set; }

    [JsonPropertyName("result")]
    public double? Result { get; set; }
}
