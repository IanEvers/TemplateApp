using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;
using Blackbird.Applications.Sdk.Common.Invocation;
using RestSharp;
using TemplateApp.Invocables;
using TemplateApp.Models.Request;
using TemplateApp.RestSharp;

namespace TemplateApp.DataSourceHandlers;

/// <summary>
/// Data source handler that can take parameters from user inputs
/// </summary>
public class DataSourceHandlerWithParameters : AppInvocable, IAsyncDataSourceHandler
{
    // Saving input model to use it while fetching data
    private readonly DataSourceWithParametersRequest _request;

    protected DataSourceHandlerWithParameters(InvocationContext invocationContext,
        // Specifying the same model where DataSourceHandlerWithParameters was added
        [ActionParameter] DataSourceWithParametersRequest request) : base(invocationContext)
    {
        _request = request;
    }

    public async Task<Dictionary<string, string>> GetDataAsync(DataSourceContext context,
        CancellationToken cancellationToken)
    {
        // Throwing error if parameters are not specified
        if (string.IsNullOrWhiteSpace(_request.Url))
            throw new("You should input URL first");

        if (string.IsNullOrWhiteSpace(_request.EntityId))
            throw new("You should input Entity ID first");

        // Fetching data based on provided parameters
        var request = new AppRestRequest($"{_request.Url}/{_request.EntityId}", Method.Get, Creds);
        return await Client.ExecuteWithHandling<Dictionary<string, string>>(request);
    }
}