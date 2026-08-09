using System.Text.RegularExpressions;

namespace Jellyfin.Plugin.Jellio.Helpers;

/// <summary>
/// Strips credentials out of text before it reaches <see cref="LogBuffer"/>.
/// </summary>
/// <remarks>
/// The buffer is served by <c>GET /jellio/logs</c>, which accepts <em>any</em>
/// authenticated Jellyfin user rather than an administrator. Stream URLs embed
/// the requesting user's session token as <c>api_key</c>, so logging one raw
/// would let any account on the server read another user's token and act as
/// them. Everything URL-shaped must go through <see cref="Redact"/>.
/// </remarks>
public static class LogRedaction
{
    private static readonly Regex ApiKeyPattern = new(
        "api_key=[^&\\s]*",
        RegexOptions.IgnoreCase | RegexOptions.CultureInvariant);

    /// <summary>
    /// Replaces the value of any <c>api_key</c> query parameter with a placeholder.
    /// </summary>
    /// <param name="value">Text that may contain a stream URL.</param>
    /// <returns>The text with any api_key value masked.</returns>
    public static string Redact(string? value)
    {
        return string.IsNullOrEmpty(value)
            ? string.Empty
            : ApiKeyPattern.Replace(value, "api_key=***");
    }
}
