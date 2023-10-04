using System.Diagnostics;
using System.Text.Json.Serialization;

namespace splitwise_csharp.Models;

[DebuggerDisplay("{FirstName} {LastName}")]
public class Friend
{
    [JsonPropertyName("id")]
    public int Id { get; init; }

    [JsonPropertyName("first_name")]
    public string FirstName { get; init; }

    [JsonPropertyName("last_name")]
    public string LastName { get; init; }

    [JsonPropertyName("email")]
    public string Email { get; init; }

    [JsonPropertyName("registration_status")]
    public string RegistrationStatus { get; init; }

    [JsonPropertyName("picture")]
    public Picture Picture { get; init; }

    [JsonPropertyName("balance")]
    public List<Balance> Balance { get; init; }

    [JsonPropertyName("groups")]
    public List<FriendGroup> Groups { get; init; }

    [JsonPropertyName("updated_at")]
    public DateTime UpdatedAt { get; init; }
}

public class FriendGroup
{
    [JsonPropertyName("group_id")]
    public int GroupId { get; init; }

    [JsonPropertyName("balance")]
    public List<Balance> Balance { get; init; }
}

internal class FriendsRoot
{
    [JsonPropertyName("friends")]
    public List<Friend> Friends { get; init; }
}

internal class FriendRoot
{
    [JsonPropertyName("friend")]
    public Friend Friend { get; init; }
}