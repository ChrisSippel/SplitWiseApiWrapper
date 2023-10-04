using System.Text.Json.Serialization;

namespace splitwise_csharp.Models;

public class Picture
{
    [JsonPropertyName("small")]
    public string Small { get; init; }

    [JsonPropertyName("medium")]
    public string Medium { get; init; }

    [JsonPropertyName("large")]
    public string Large { get; init; }
}