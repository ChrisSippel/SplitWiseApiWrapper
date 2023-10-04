using RestSharp;
using splitwise_csharp.Models;

namespace splitwise_csharp;

/// <summary>
/// A class that contains the methods related to the logged in user's friends.
/// </summary>
internal sealed class FriendsWrapper : SplitWiseApiWrapperBase
{
    public FriendsWrapper()
        : this(string.Empty)
    {
    }

    public FriendsWrapper(string bearerToken)
        : base(bearerToken)
    {
    }

    /// <summary>
    /// Gets the logged in user's friend list.
    /// </summary>
    /// <returns>The list of friends of the logged in user.</returns>
    public async Task<Result<IEnumerable<Friend>>> GetCurrentUserFriendsAsync(
        CancellationToken cancellationToken = default)
    {
        var friendsListRequest = await ExecuteRequest<FriendsRoot>(
            "https://secure.splitwise.com/api/v3.0/get_friends",
            Method.Get,
            cancellationToken);

        return friendsListRequest.IsSuccessful
            ? Result<IEnumerable<Friend>>.Success(friendsListRequest.Data?.Friends)
            : Result<IEnumerable<Friend>>.Failure(friendsListRequest.ErrorMessage);
    }

    public async Task<Result<Friend>> GetFriend(
        int friendId,
        CancellationToken cancellationToken = default)
    {
        var getFriendRequest = await ExecuteRequest<FriendRoot>(
            $"https://secure.splitwise.com/api/v3.0/get_friend/{friendId}",
            Method.Get,
            cancellationToken);

        return getFriendRequest.IsSuccessful
            ? Result<Friend>.Success(getFriendRequest.Data?.Friend)
            : Result<Friend>.Failure(getFriendRequest.ErrorMessage);
    }
}