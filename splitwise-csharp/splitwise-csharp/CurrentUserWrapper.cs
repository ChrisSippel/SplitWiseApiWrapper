using RestSharp;
using splitwise_csharp.Models;

namespace splitwise_csharp;

internal sealed class CurrentUserWrapper : SplitWiseApiWrapperBase
{
    public CurrentUserWrapper()
        : base(string.Empty)
    {
    }

    public CurrentUserWrapper(string bearerToken)
        : base(bearerToken)
    {
    }

    public async Task<Result<User>> GetCurrentUserAsync(
        CancellationToken cancellationToken = default)
    {
        var userInformationRequest = await ExecuteRequest<UserRoot>(
            "https://secure.splitwise.com/api/v3.0/get_current_user",
            Method.Get,
            cancellationToken);

        return userInformationRequest.IsSuccessful
            ? Result<User>.Success(userInformationRequest.Data?.User)
            : Result<User>.Failure(userInformationRequest.ErrorMessage);
    }
}