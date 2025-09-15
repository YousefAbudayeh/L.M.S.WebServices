using System.Text.Json.Serialization;

namespace L.M.S.Application.Common.Responses;

public abstract class ResponseBase
{
    [JsonPropertyName("message")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Message { get; set; }

    [JsonIgnore]
    public bool Success { get; set; }

    [JsonIgnore]
    public int? StatusCode { get; set; }
}