using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Authentication;
using Blackbird.Applications.Sdk.Common.Dynamic;
using Blackbird.Applications.Sdk.Common.Invocation;
using Blackbird.Applications.Sdk.Utils.Extensions.String;
using RestSharp;
using TemplateApp.Constants;
using TemplateApp.Models.Dto;
using TemplateApp.Models.Response;
using TemplateApp.RestSharp;

namespace TemplateApp.DataSourceHandlers;

/// <summary>
/// Data source handler for asynchronous dynamic inputs.
/// Extends BaseInvocable class that contains all of the context data
/// </summary>
public class AsyncDataSourceHandler : BaseInvocable, IAsyncDataSourceHandler
{
    private IEnumerable<AuthenticationCredentialsProvider> Creds =>
        InvocationContext.AuthenticationCredentialsProviders;

    private AppRestClient Client { get; }
    public AsyncDataSourceHandler(InvocationContext invocationContext) : base(invocationContext)
    {
        Client = new();
    }

    /// <summary>
    /// Fetches data for the dynamic inputs and returns it as a dictionary.
    /// Key of the dictionary represents data needed in the app itself, e.g. ID.
    /// Values is displayed to user in the UI, so that it should be a user-friendly name of the item
    /// </summary>
    public async Task<Dictionary<string, string>> GetDataAsync(DataSourceContext context,
        CancellationToken cancellationToken)
    {
        var request = new AppRestRequest(ApiEndpoints.Berry, Method.Get, Creds);
        var response = await Client.ExecuteWithHandling<ListResponse<Berry>>(request);

        return response.Results
                // We need to pay attention to SearchString in the context
                // So that we return only values that match user search request
            .Where(x => context.SearchString == null ||
                        x.Name.Contains(context.SearchString, StringComparison.OrdinalIgnoreCase))
            .ToDictionary(x => x.Name, x => x.Name.ToPascalCase());

    }
}