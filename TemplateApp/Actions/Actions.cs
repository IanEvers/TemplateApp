using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Authentication;
using RestSharp;
using TemplateApp.Constants;
using TemplateApp.Models.Dto;
using TemplateApp.Models.Request;
using TemplateApp.Models.Response;
using TemplateApp.RestSharp;

namespace TemplateApp.Actions;

/// <summary>
/// Contains list of actions
/// </summary>
[ActionList]
public class Actions
{
    #region Fields

    private AppRestClient Client { get; }

    #endregion

    #region Constructors

    public Actions()
    {
        Client = new();
    }

    #endregion

    #region Actions

    /// <summary>
    /// Retrieves list of items, takes no action parameters
    /// </summary>
    /// <param name="creds">User auth credentials</param>
    /// <returns>List of created items</returns>
    [Action("List berries", Description = "List berries")]
    public async Task<ListBerriesResponse> ListItems(
        IEnumerable<AuthenticationCredentialsProvider> creds)
    {
        var request = new AppRestRequest(ApiEndpoints.Berry, Method.Get, creds);
        var response = await Client.ExecuteWithHandling<ListResponse<Berry>>(request);

        return new(response.Results);
    }

    /// <summary>
    /// Creates a new item
    /// </summary>
    /// <param name="creds">User auth credentials</param>
    /// <param name="input">Action parameter with the data for creation a new item</param>
    /// <returns>Newly created item</returns>
    [Action("Get berry", Description = "Get speicifc berry by ID")]
    public Task<Berry> AddItem(
        IEnumerable<AuthenticationCredentialsProvider> creds,
        [ActionParameter] GetBerryRequest input)
    {
        var request = new AppRestRequest($"{ApiEndpoints.Berry}/{input.BerryName}", Method.Get, creds);

        return Client.ExecuteWithHandling<Berry>(request);
    }
    
    /// <summary>
    /// Creates action callback that can be received later in a BlackBird webhook
    /// </summary>
    /// <param name="creds">User auth credentials</param>
    /// <param name="input">Callback creation data</param>
    [Action("Create callback", Description = "Create action callback")]
    public Task CreateCallback(
        IEnumerable<AuthenticationCredentialsProvider> creds,
        [ActionParameter] CreateCallbackRequest input)
    {
        var request = new AppRestRequest(ApiEndpoints.Callbacks, Method.Post, creds);
        request.AddJsonBody(input);

        return Client.ExecuteWithHandling(request);
    }

    #endregion
}