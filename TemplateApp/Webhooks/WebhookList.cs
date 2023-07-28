using Blackbird.Applications.Sdk.Common.Webhooks;
using Newtonsoft.Json;
using TemplateApp.Webhooks.Handlers;
using TemplateApp.Webhooks.Models.Payload;

namespace TemplateApp.Webhooks;

/// <summary>
/// Contains list of webhooks
/// </summary>
[WebhookList]
public class WebhookList
{
    #region Webhooks

    /// <summary>
    /// Receives and processes data when item is created
    /// </summary>
    [Webhook("On item created", typeof(ItemCreatedHandler), Description = "On item created")]
    public Task<WebhookResponse<ItemPayload>> OnItemCreated(WebhookRequest webhookRequest)
        => HandlerWebhook<ItemPayload>(webhookRequest);    
    
    /// <summary>
    /// Receives and processes data when item is created
    /// </summary>
    [Webhook("On project item created", typeof(ProjectItemCreatedHandler), Description = "On project item created")]
    public Task<WebhookResponse<ItemPayload>> OnProjectItemCreated(WebhookRequest webhookRequest)
        => HandlerWebhook<ItemPayload>(webhookRequest);

    /// <summary>
    /// Receives and processes a callback
    /// </summary>
    [Webhook("On callback received", Description = "On callback received")]
    public Task<WebhookResponse<CallbackPayload>> OnCallbackReceived(WebhookRequest webhookRequest)
        => HandlerWebhook<CallbackPayload>(webhookRequest);

    #endregion

    #region Utils

    private Task<WebhookResponse<T>> HandlerWebhook<T>(WebhookRequest webhookRequest) where T : class
    {
        var data = JsonConvert.DeserializeObject<T>(webhookRequest.Body.ToString());

        if (data is null)
            throw new InvalidCastException(nameof(webhookRequest.Body));

        return Task.FromResult(new WebhookResponse<T>
        {
            Result = data
        });
    }

    #endregion
}