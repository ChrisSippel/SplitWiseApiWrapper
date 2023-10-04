using System.Text.Json.Serialization;

namespace splitwise_csharp.Models;

public class Notifications
{
    [JsonPropertyName("added_as_friend")]
    public bool AddedAsFriend { get; init; }

    [JsonPropertyName("added_to_group")]
    public bool AddedToGroup { get; init; }

    [JsonPropertyName("expense_added")]
    public bool ExpenseAdded { get; init; }

    [JsonPropertyName("expense_updated")]
    public bool ExpenseUpdated { get; init; }

    [JsonPropertyName("bills")]
    public bool Bills { get; init; }

    [JsonPropertyName("payments")]
    public bool Payments { get; init; }

    [JsonPropertyName("monthly_summary")]
    public bool MonthlySummary { get; init; }

    [JsonPropertyName("announcements")]
    public bool Announcements { get; init; }
}

internal class UserRoot
{
    [JsonPropertyName("user")]
    public User User { get; init; }
}

public class User
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

    [JsonPropertyName("force_refresh_at")]
    public object ForceRefreshAt { get; init; }

    [JsonPropertyName("locale")]
    public string Locale { get; init; }

    [JsonPropertyName("country_code")]
    public string CountryCode { get; init; }

    [JsonPropertyName("date_format")]
    public string DateFormat { get; init; }

    [JsonPropertyName("default_currency")]
    public string DefaultCurrency { get; init; }

    [JsonPropertyName("default_group_id")]
    public int DefaultGroupId { get; init; }

    [JsonPropertyName("notifications_read")]
    public DateTime NotificationsRead { get; init; }

    [JsonPropertyName("notifications_count")]
    public int NotificationsCount { get; init; }

    [JsonPropertyName("notifications")]
    public Notifications Notifications { get; init; }
}