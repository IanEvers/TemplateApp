using Blackbird.Applications.Sdk.Common.Authentication;
using Blackbird.Applications.Sdk.Common.Connections;
using TemplateApp.Constants;

namespace TemplateApp.Connections;

/// <summary>
/// Describes BlackBird's app connection settings
/// </summary>
public class ConnectionDefinition : IConnectionDefinition
{
    
    /// <summary>
    /// Defines app's connection types
    /// </summary>
    public IEnumerable<ConnectionPropertyGroup> ConnectionPropertyGroups => new List<ConnectionPropertyGroup>
    {
        // OAuth example
        // new()
        // {
        //     Name = "OAuth2",
        //     AuthenticationType = ConnectionAuthenticationType.OAuth2,
        //     ConnectionUsage = ConnectionUsage.Actions,
        //     ConnectionProperties = new List<ConnectionProperty>()
        // },
        
        // API token auth example
        new()
        {
            Name = "Developer API token",
            AuthenticationType = ConnectionAuthenticationType.Undefined,
            ConnectionUsage = ConnectionUsage.Actions,
            
            // Specifying properties that we will need for authorization of the app
            ConnectionProperties = new List<ConnectionProperty>
            {
                new(CredsNames.ApiToken)
                {
                    // Property user-friendly name that will be displayed on the UI
                    DisplayName = "API token"
                }
            }
        },
    };

    
    /// <summary>
    /// Processes credentials after the authorization is done 
    /// </summary>
    /// <param name="values"></param>
    /// <returns></returns>
    public IEnumerable<AuthenticationCredentialsProvider> CreateAuthorizationCredentialsProviders(
        Dictionary<string, string> values)
    {
        // Processing OAuth credentials
        // var accessToken = values.First(v => v.Key == CredsNames.AccessToken);
        // yield return new AuthenticationCredentialsProvider(
        //     AuthenticationCredentialsRequestLocation.Header,
        //     "Authorization",
        //     $"Bearer {accessToken.Value}"
        // );
        
        // Processing API key credentials
        var apiKey = values.First(v => v.Key == CredsNames.ApiToken);
        yield return new AuthenticationCredentialsProvider(
            AuthenticationCredentialsRequestLocation.Header,
            "x-api-key",
            apiKey.Value
        );
    }
}