using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using RestSharp;
using splitwise_csharp.Models;

namespace splitwise_csharp;

internal sealed class ExpensesWrapper : SplitWiseApiWrapperBase
{
    public ExpensesWrapper()
        : base(string.Empty)
    {
    }

    public ExpensesWrapper(string bearerToken)
        : base(bearerToken)
    {
    }

    /// <summary>
    /// Gets the logged in user's friend list.
    /// </summary>
    /// <returns>The list of friends of the logged in user; otherwise <c>null</c>.</returns>
    public async Task<Result<List<Expense>>> GetCurrentUserExpensesAsync(
        CancellationToken cancellationToken = default)
    {
        CheckIfLoggedIn();

        var request = new RestRequest($"https://secure.splitwise.com/api/v3.0/get_expenses", Method.Get);
        request.AddHeader("authorization", $"Bearer {_bearerToken}");
        request.AddHeader("cache-control", "no-cache");
        request.AddQueryParameter("limit", 50);

        var client = new RestClient();
        var expensesListRequest = await client.ExecuteAsync<ExpensesRoot>(request, cancellationToken);

        return expensesListRequest.IsSuccessful
            ? Result<List<Expense>>.Success(expensesListRequest.Data?.Expenses)
            : Result<List<Expense>>.Failure(expensesListRequest.ErrorMessage);
    }

    public async Task<Result<Expense>> CreateExpense(
        decimal cost,
        string description,
        DateTime dateTime,
        int groupId,
        CancellationToken cancellationToken = default)
    {
        CheckIfLoggedIn();

        var requestBody = new Dictionary<string, object>
        {
            { "cost", cost.ToString("F2") },
            { "description", description },
            { "date", dateTime.ToString("o") },
            { "currency_code", "CAD" },
            { "group_id", groupId },
            { "split_equally", true }
        };

        var requestBodyParameter = JsonSerializer.Serialize(requestBody);

        var request = new RestRequest($"https://secure.splitwise.com/api/v3.0/create_expense", Method.Post);
        request.AddHeader("authorization", $"Bearer {_bearerToken}");
        request.AddHeader("cache-control", "no-cache");
        request.AddBody(requestBodyParameter, ContentType.Json);

        var client = new RestClient();
        var expensesListRequest = await client.ExecuteAsync<CreatedExpense>(request, cancellationToken);

        if (!expensesListRequest.IsSuccessful)
        {
            return Result<Expense>.Failure(expensesListRequest.ErrorMessage);
        }

        var errorMessage = GetErrorMessages((JsonElement)expensesListRequest.Data?.Errors);
        return string.IsNullOrWhiteSpace(errorMessage)
            ? Result<Expense>.Success(expensesListRequest.Data?.Expenses.First())
            : Result<Expense>.Failure(errorMessage);
    }

    public async Task<Result<bool>> DeleteExpense(
        long expenseId,
        CancellationToken cancellationToken = default)
    {
        var deleteExpenseRequest = await ExecuteRequest<DeletedExpense>(
            $"https://secure.splitwise.com/api/v3.0/delete_expense/{expenseId}",
            Method.Post,
            cancellationToken);

        if (!deleteExpenseRequest.IsSuccessful)
        {
            return Result<bool>.Failure(deleteExpenseRequest.ErrorMessage);
        }

        var errorMessage = GetErrorMessages((JsonElement)deleteExpenseRequest.Data?.Errors);
        return deleteExpenseRequest.IsSuccessful
            ? Result<bool>.Success(true)
            : Result<bool>.Failure(deleteExpenseRequest.ErrorMessage);
    }

    private static string GetErrorMessages(JsonElement errorsElement)
    {
        var errorsObject = errorsElement.Deserialize<JsonObject>();
        if (!errorsObject.Any())
        {
            return null;
        }

        var errorsArray = errorsObject.FirstOrDefault().Value.AsArray();
        var builder = new StringBuilder();
        foreach (var error in errorsArray)
        {
            builder.AppendLine(error.ToString());
        }

        return builder.ToString();
    }
}