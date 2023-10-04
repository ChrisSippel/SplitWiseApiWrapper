using RestSharp;
using splitwise_csharp.Models;

namespace splitwise_csharp;

public sealed class Splitwise
{
    private string _bearerToken = string.Empty;
    private FriendsWrapper _friendsWrapper = new();
    private CurrentUserWrapper _currentUserWrapper = new();
    private ExpensesWrapper _expensesWrapper = new();
    private GroupsWrapper _groupsWrapper = new();

    /// <summary>
    /// Attempts to log into SplitWise
    /// </summary>
    /// <param name="consumerKey">
    /// The OAuth2 consumer key required for logging in. This is referred to as the <c>ConsumerKey</c> on the
    /// Splitwise oauth_clients webpage.
    /// </param>
    /// <param name="consumerSecret">
    /// The OAuth2 consumer secret required for logging in. This is referred to as the <c>ConsumerSecret</c> on the
    /// Splitwise oauth_clients webpage.
    /// </param>
    /// <returns><c>true</c> if the login was successful, or you're already logged in; otherwise <c>false</c>.</returns>
    public async Task<Result<bool>> TryLoginAsync(
        string consumerKey,
        string consumerSecret,
        CancellationToken cancellationToken = default)
    {
        if (!string.IsNullOrWhiteSpace(_bearerToken))
        {
            return Result<bool>.Success(true);
        }

        var request = new RestRequest("https://secure.splitwise.com/oauth/token", Method.Post);
        request.AddHeader("cache-control", "no-cache");
        request.AddHeader("content-type", "application/x-www-form-urlencoded");
        request.AddParameter(
            "application/x-www-form-urlencoded",
            $"grant_type=client_credentials&client_id={consumerKey}&client_secret={consumerSecret}",
            ParameterType.RequestBody);

        var client = new RestClient();
        var requestResult = await client.ExecuteAsync<Dictionary<string, string>>(
            request,
            cancellationToken);

        if (!requestResult.IsSuccessful)
        {
            return Result<bool>.Failure(requestResult.ErrorMessage);
        }

        var requestData = requestResult.Data;
        if (requestData == null ||
            !requestData.ContainsKey("access_token") ||
            !requestData.ContainsKey("token_type"))
        {
            return Result<bool>.Failure("Request result did not contain access_token and/or token_type");
        }

        _bearerToken = requestData["access_token"];
        _friendsWrapper = new FriendsWrapper(_bearerToken);
        _currentUserWrapper = new CurrentUserWrapper(_bearerToken);
        _expensesWrapper = new ExpensesWrapper(_bearerToken);
        _groupsWrapper = new GroupsWrapper(_bearerToken);

        return Result<bool>.Success(true);
    }

    /// <summary>
    /// Gets the information about the logged in user.
    /// </summary>
    /// <returns>The user who is logged into Splitwise.</returns>
    public Task<Result<User>> GetCurrentUserAsync(CancellationToken cancellationToken = default) =>
            _currentUserWrapper.GetCurrentUserAsync(cancellationToken);

    /// <summary>
    /// Gets the logged in user's friend list.
    /// </summary>
    /// <returns>The list of friends of the logged in user.</returns>
    public Task<Result<IEnumerable<Friend>>> GetCurrentUserFriendsAsync(
        CancellationToken cancellationToken = default) =>
            _friendsWrapper.GetCurrentUserFriendsAsync(cancellationToken);

    /// <summary>
    /// Gets a specific friend of the current user.
    /// </summary>
    /// <param name="friendId">The id of the friend to retrieve.</param>
    /// <returns>The specified friend.</returns>
    public Task<Result<Friend>> GetFriend(int friendId, CancellationToken cancellationToken = default) =>
            _friendsWrapper.GetFriend(friendId, cancellationToken);

    /// <summary>
    /// Gets the latest 20 expenses of the current user.
    /// </summary>
    /// <returns>The latest 20 expenses of the current user.</returns>
    public Task<Result<List<Expense>>> GetCurrentUserExpensesAsync(CancellationToken cancellationToken = default) =>
        _expensesWrapper.GetCurrentUserExpensesAsync(cancellationToken);

    /// <summary>
    /// Gets the current user's groups.
    /// </summary>
    /// <returns>The list of groups the current user is in.</returns>
    public Task<Result<IEnumerable<Group>>> GetCurrentUserGroupsAsync(CancellationToken cancellationToken = default) =>
        _groupsWrapper.GetCurrentUserGroupsAsync(cancellationToken);

    /// <summary>
    /// Gets the specified group.
    /// </summary>
    /// <returns>The specified group.</returns>
    public Task<Result<Group>> GetGroupAsync(
        int groupId,
        CancellationToken cancellationToken = default) =>
            _groupsWrapper.GetGroupAsync(groupId, cancellationToken);

    public Task<Result<Expense>> CreateExpense(
        decimal cost,
        string description,
        DateTime dateTime,
        int groupId,
        CancellationToken cancellationToken = default) =>
            _expensesWrapper.CreateExpense(
                cost,
                description,
                dateTime,
                groupId,
                cancellationToken);

    public Task<Result<bool>> DeleteExpense(
        long expenseId,
        CancellationToken cancellationToken = default) =>
        _expensesWrapper.DeleteExpense(
            expenseId,
            cancellationToken);
}