using RestSharp;

namespace splitwise_csharp;

public abstract class SplitWiseApiWrapperBase
{
    protected readonly string _bearerToken;

    protected SplitWiseApiWrapperBase(string bearerToken)
    {
        _bearerToken = bearerToken;
    }

    protected async Task<RestResponse<T>> ExecuteRequest<T>(
        string url,
        Method requestType,
        CancellationToken cancellationToken = default)
    {
        CheckIfLoggedIn();

        var request = new RestRequest(url, requestType);
        request.AddHeader("authorization", $"Bearer {_bearerToken}");
        request.AddHeader("cache-control", "no-cache");

        var client = new RestClient();
        return await client.ExecuteAsync<T>(request, cancellationToken);
    }

    protected void CheckIfLoggedIn()
    {
        if (string.IsNullOrWhiteSpace(_bearerToken))
        {
            throw new InvalidOperationException(
                "You are not logged into Splitwise. Please call TryLoginAsync before attempting to interact with Splitwise.");
        }
    }
}