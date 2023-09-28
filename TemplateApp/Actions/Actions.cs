using System.Net.Mime;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Invocation;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using TemplateApp.Constants;
using TemplateApp.Invocables;
using TemplateApp.Models.Dto;
using TemplateApp.Models.Request;
using TemplateApp.Models.Response;
using TemplateApp.RestSharp;

namespace TemplateApp.Actions;

/// <summary>
/// Contains list of actions
/// </summary>
[ActionList]
public class Actions : AppInvocable
{
    #region Constructors

    public Actions(InvocationContext invocationContext) : base(invocationContext)
    {
    }

    #endregion

    #region Actions

    /// <summary>
    /// Retrieves list of items, takes no action parameters
    /// </summary>
    /// <returns>List of created items</returns>
    [Action("List berries", Description = "List berries")]
    public async Task<ListBerriesResponse> ListItems()
    {
        var request = new AppRestRequest(ApiEndpoints.Berry, Method.Get, Creds);
        var response = await Client.ExecuteWithHandling<ListResponse<Berry>>(request);

        return new(response.Results);
    }

    [Action("Convert Objects", Description = "Convert Objects")]
    public string ConvertObject([ActionParameter] object objToConvert, [ActionParameter] string jsonPath)
    {
        var json = JsonConvert.SerializeObject(objToConvert);
        var jObj = JObject.Parse(json);
        var value = jObj.SelectToken(jsonPath);
        return value.ToString();
    }

    /// <summary>
    /// Creates a new item
    /// </summary>
    /// <param name="input">Action parameter with the data for creation a new item</param>
    /// <returns>Newly created item</returns>
    [Action("Get berry", Description = "Get speicifc berry by ID")]
    public Task<Berry> GetBerry([ActionParameter] GetBerryRequest input)
    {
        var request = new AppRestRequest($"{ApiEndpoints.Berry}/{input.BerryName}", Method.Get, Creds);

        return Client.ExecuteWithHandling<Berry>(request);
    }

    /// <summary>
    /// Demonstration of working with files in BlackBird
    /// </summary>
    /// <param name="input">Action parameter with the data for downloading the file</param>
    /// <returns>File data</returns>
    [Action("Download file", Description = "Download specific file")]
    public async Task<FileResponse> DownloadFile([ActionParameter] DownloadFileRequest input)
    {
        var request = new RestRequest(input.FileUrl);
        var response = await Client.ExecuteAsync(request);

        // Throwing error if status code is not successful
        if (!response.IsSuccessStatusCode)
            throw new($"Could not download your file; Code: {response.StatusCode}");

        // Passing file bytes to BlackBird's file type
        return new(new(response.RawBytes)
        {
            Name = input.FileName,
            // Taking file's content type from the request headers
            ContentType = response.ContentType ?? MediaTypeNames.Application.Octet
        });
    }

    /// <summary>
    /// Creates action callback that can be received later in a BlackBird webhook
    /// </summary>
    /// <param name="input">Callback creation data</param>
    [Action("Create callback", Description = "Create action callback")]
    public Task CreateCallback([ActionParameter] CreateCallbackRequest input)
    {
        var request = new AppRestRequest(ApiEndpoints.Callbacks, Method.Post, Creds);
        request.AddJsonBody(input);

        return Client.ExecuteWithHandling(request);
    }

    #endregion
}