using TemplateApp.Webhooks.Handlers.Base;

namespace TemplateApp.Webhooks.Handlers;

/// <summary>
/// Handler for item.created webhook
/// </summary>
public class ItemCreatedHandler : ParameterlessWebhookHandler
{
    protected override string SubscriptionEvent => "item.created";
}