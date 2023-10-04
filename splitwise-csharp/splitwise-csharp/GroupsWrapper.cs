using RestSharp;
using splitwise_csharp.Models;

namespace splitwise_csharp;

internal sealed class GroupsWrapper : SplitWiseApiWrapperBase
{
    public GroupsWrapper()
        : base(string.Empty)
    {
    }

    public GroupsWrapper(string bearerToken)
        : base(bearerToken)
    {
    }

    /// <summary>
    /// Gets the logged in user's group list.
    /// </summary>
    /// <returns>The list of groups of the logged in user.</returns>
    public async Task<Result<IEnumerable<Group>>> GetCurrentUserGroupsAsync(
        CancellationToken cancellationToken = default)
    {
        var friendsListRequest = await ExecuteRequest<GroupsRoot>(
            "https://secure.splitwise.com/api/v3.0/get_groups",
            Method.Get,
            cancellationToken);

        return friendsListRequest.IsSuccessful
            ? Result<IEnumerable<Group>>.Success(friendsListRequest.Data?.Groups)
            : Result<IEnumerable<Group>>.Failure(friendsListRequest.ErrorMessage);
    }

    /// <summary>
    /// Gets the specified group.
    /// </summary>
    /// <returns>The specified group.</returns>
    public async Task<Result<Group>> GetGroupAsync(
        int groupId,
        CancellationToken cancellationToken = default)
    {
        var friendsListRequest = await ExecuteRequest<GroupRoot>(
            $"https://secure.splitwise.com/api/v3.0/get_group/{groupId}",
            Method.Get,
            cancellationToken);

        return friendsListRequest.IsSuccessful
            ? Result<Group>.Success(friendsListRequest.Data?.Group)
            : Result<Group>.Failure(friendsListRequest.ErrorMessage);
    }
}