using System.Text.Json.Serialization;

namespace Jellyfin.Plugin.Jellio.Models;

/// <summary>
/// Stremio stream behaviour hints. Only the subset Jellio needs is modelled.
/// </summary>
public class BehaviorHintsDto
{
    /// <summary>
    /// Gets or sets the binge group. Streams sharing a binge group are treated as
    /// interchangeable by Stremio, so the choice made for one episode is reused
    /// automatically for the next instead of re-prompting.
    /// </summary>
    [JsonPropertyName("bingeGroup")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? BingeGroup { get; set; }
}
