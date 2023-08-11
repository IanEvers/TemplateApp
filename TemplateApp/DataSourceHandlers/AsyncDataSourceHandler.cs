using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Authentication;
using Blackbird.Applications.Sdk.Common.Dynamic;
using Blackbird.Applications.Sdk.Common.Invocation;
using Blackbird.Applications.Sdk.Utils.Extensions.String;

namespace TemplateApp.DataSourceHandlers;

/// <summary>
/// Data source handler for asynchronous dynamic inputs.
/// Extends BaseInvocable class that contains all of the context data
/// </summary>
public class AsyncDataSourceHandler : BaseInvocable, IAsyncDataSourceHandler
{
    private IEnumerable<AuthenticationCredentialsProvider> Creds =>
        InvocationContext.AuthenticationCredentialsProviders;

    public AsyncDataSourceHandler(InvocationContext invocationContext) : base(invocationContext)
    {
    }

    /// <summary>
    /// Fetches data for the dynamic inputs and returns it as a dictionary.
    /// Key of the dictionary represents data needed in the app itself, e.g. ID.
    /// Values is displayed to user in the UI, so that it should be a user-friendly name of the item
    /// </summary>
    public async Task<Dictionary<string, string>> GetDataAsync(DataSourceContext context,
        CancellationToken cancellationToken)
    {
        var actions = new Actions.Actions();
        var items = await actions.ListItems(Creds);

        return items.Items
                // We need to pay attention to SearchString in the context
                // So that we return only values that match user search request
            .Where(x => context.SearchString == null ||
                        x.Name.Contains(context.SearchString, StringComparison.OrdinalIgnoreCase))
            .ToDictionary(x => x.Name, x => x.Name.ToPascalCase());

    }
}