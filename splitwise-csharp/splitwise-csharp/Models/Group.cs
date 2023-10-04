using System.Diagnostics;
using System.Text.Json.Serialization;

namespace splitwise_csharp.Models;

public class Avatar
{
    [JsonPropertyName("small")]
    public string Small { get; init; }

    [JsonPropertyName("medium")]
    public string Medium { get; init; }

    [JsonPropertyName("large")]
    public string Large { get; init; }

    [JsonPropertyName("xlarge")]
    public string Xlarge { get; init; }

    [JsonPropertyName("xxlarge")]
    public string Xxlarge { get; init; }

    [JsonPropertyName("original")]
    public string Original { get; init; }
}

public class CoverPhoto
{
    [JsonPropertyName("xxlarge")]
    public string Xxlarge { get; init; }

    [JsonPropertyName("xlarge")]
    public string Xlarge { get; init; }
}

[DebuggerDisplay("{Name}")]
public class Group
{
    [JsonPropertyName("id")]
    public int Id { get; init; }

    [JsonPropertyName("name")]
    public string Name { get; init; }

    [JsonPropertyName("created_at")]
    public DateTime CreatedAt { get; init; }

    [JsonPropertyName("updated_at")]
    public DateTime UpdatedAt { get; init; }

    [JsonPropertyName("members")]
    public List<Member> Members { get; init; }

    [JsonPropertyName("simplify_by_default")]
    public bool SimplifyByDefault { get; init; }

    [JsonPropertyName("original_debts")]
    public List<OriginalDebt> OriginalDebts { get; init; }

    [JsonPropertyName("simplified_debts")]
    public List<SimplifiedDebt> SimplifiedDebts { get; init; }

    [JsonPropertyName("avatar")]
    public Avatar Avatar { get; init; }

    [JsonPropertyName("tall_avatar")]
    public TallAvatar TallAvatar { get; init; }

    [JsonPropertyName("custom_avatar")]
    public bool CustomAvatar { get; init; }

    [JsonPropertyName("cover_photo")]
    public CoverPhoto CoverPhoto { get; init; }

    [JsonPropertyName("whiteboard")]
    public object Whiteboard { get; init; }

    [JsonPropertyName("group_type")]
    public string GroupType { get; init; }

    [JsonPropertyName("invite_link")]
    public string InviteLink { get; init; }

    [JsonPropertyName("group_reminders")]
    public object GroupReminders { get; init; }
}

public class Member
{
    [JsonPropertyName("id")]
    public int Id { get; init; }

    [JsonPropertyName("first_name")]
    public string FirstName { get; init; }

    [JsonPropertyName("last_name")]
    public string LastName { get; init; }

    [JsonPropertyName("picture")]
    public Picture Picture { get; init; }

    [JsonPropertyName("custom_picture")]
    public bool CustomPicture { get; init; }

    [JsonPropertyName("email")]
    public string Email { get; init; }

    [JsonPropertyName("registration_status")]
    public string RegistrationStatus { get; init; }

    [JsonPropertyName("balance")]
    public List<Balance> Balance { get; init; }
}

public class OriginalDebt
{
    [JsonPropertyName("to")]
    public int To { get; init; }

    [JsonPropertyName("from")]
    public int From { get; init; }

    [JsonPropertyName("amount")]
    public string Amount { get; init; }

    [JsonPropertyName("currency_code")]
    public string CurrencyCode { get; init; }
}

internal class GroupsRoot
{
    [JsonPropertyName("groups")]
    public List<Group> Groups { get; init; }
}

internal class GroupRoot
{
    [JsonPropertyName("group")]
    public Group Group { get; init; }
}

public class SimplifiedDebt
{
    [JsonPropertyName("from")]
    public int From { get; init; }

    [JsonPropertyName("to")]
    public int To { get; init; }

    [JsonPropertyName("amount")]
    public string Amount { get; init; }

    [JsonPropertyName("currency_code")]
    public string CurrencyCode { get; init; }
}

public class TallAvatar
{
    [JsonPropertyName("xlarge")]
    public string Xlarge { get; init; }

    [JsonPropertyName("large")]
    public string Large { get; init; }
}