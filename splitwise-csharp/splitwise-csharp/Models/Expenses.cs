using System.Text.Json.Serialization;

namespace splitwise_csharp.Models;

public class Category
{
    [JsonPropertyName("id")]
    public uint Id { get; init; }

    [JsonPropertyName("name")]
    public string Name { get; init; }
}

public class CreatedBy
{
    [JsonPropertyName("id")]
    public uint Id { get; init; }

    [JsonPropertyName("first_name")]
    public string FirstName { get; init; }

    [JsonPropertyName("last_name")]
    public string LastName { get; init; }

    [JsonPropertyName("picture")]
    public Picture Picture { get; init; }

    [JsonPropertyName("custom_picture")]
    public bool CustomPicture { get; init; }
}

public class Expense
{
    [JsonPropertyName("id")]
    public long Id { get; init; }

    [JsonPropertyName("group_id")]
    public int? GroupId { get; init; }

    [JsonPropertyName("friendship_id")]
    public int? FriendshipId { get; init; }

    [JsonPropertyName("expense_bundle_id")]
    public int? ExpenseBundleId { get; init; }

    [JsonPropertyName("description")]
    public string Description { get; init; }

    [JsonPropertyName("repeats")]
    public bool Repeats { get; init; }

    [JsonPropertyName("repeat_interval")]
    public string RepeatInterval { get; init; }

    [JsonPropertyName("email_reminder")]
    public bool EmailReminder { get; init; }

    [JsonPropertyName("email_reminder_in_advance")]
    public int? EmailReminderInAdvance { get; init; }

    [JsonPropertyName("next_repeat")]
    public string NextRepeat { get; init; }

    [JsonPropertyName("details")]
    public string Details { get; init; }

    [JsonPropertyName("comments_count")]
    public int CommentsCount { get; init; }

    [JsonPropertyName("payment")]
    public bool Payment { get; init; }

    [JsonPropertyName("creation_method")]
    public string CreationMethod { get; init; }

    [JsonPropertyName("transaction_method")]
    public string TransactionMethod { get; init; }

    [JsonPropertyName("transaction_confirmed")]
    public bool TransactionConfirmed { get; init; }

    [JsonPropertyName("transaction_id")]
    public long? TransactionId { get; init; }

    [JsonPropertyName("transaction_status")]
    public string TransactionStatus { get; init; }

    [JsonPropertyName("cost")]
    public string Cost { get; init; }

    [JsonPropertyName("currency_code")]
    public string CurrencyCode { get; init; }

    [JsonPropertyName("repayments")]
    public List<Repayment> Repayments { get; init; }

    [JsonPropertyName("date")]
    public DateTime Date { get; init; }

    [JsonPropertyName("created_at")]
    public DateTime CreatedAt { get; init; }

    [JsonPropertyName("created_by")]
    public User? CreatedBy { get; init; }

    [JsonPropertyName("updated_at")]
    public DateTime UpdatedAt { get; init; }

    [JsonPropertyName("updated_by")]
    public User UpdatedBy { get; init; }

    [JsonPropertyName("deleted_at")]
    public DateTime? DeletedAt { get; init; }

    [JsonPropertyName("deleted_by")]
    public User? DeletedBy { get; init; }

    [JsonPropertyName("category")]
    public Category Category { get; init; }

    [JsonPropertyName("receipt")]
    public Receipt Receipt { get; init; }

    [JsonPropertyName("users")]
    public List<ExpenseUser> Users { get; init; }
}

public class Receipt
{
    [JsonPropertyName("large")]
    public string Large { get; init; }

    [JsonPropertyName("original")]
    public string Original { get; init; }
}

public class Repayment
{
    [JsonPropertyName("from")]
    public int From { get; init; }

    [JsonPropertyName("to")]
    public int To { get; init; }

    [JsonPropertyName("amount")]
    public string Amount { get; init; }
}

internal class ExpensesRoot
{
    [JsonPropertyName("expenses")]
    public List<Expense> Expenses { get; init; }
}

internal class CreatedExpense
{
    [JsonPropertyName("expenses")]
    public List<Expense> Expenses { get; init; }

    [JsonPropertyName("errors")]
    public object? Errors { get; init; }
}

internal class DeletedExpense
{
    [JsonPropertyName("success")]
    public bool Success { get; init; }

    [JsonPropertyName("errors")]
    public object? Errors { get; init; }
}

public class ExpenseUser
{
    [JsonPropertyName("user")]
    public User User { get; init; }

    [JsonPropertyName("user_id")]
    public int UserId { get; init; }

    [JsonPropertyName("paid_share")]
    public string PaidShare { get; init; }

    [JsonPropertyName("owed_share")]
    public string OwedShare { get; init; }

    [JsonPropertyName("net_balance")]
    public string NetBalance { get; init; }
}