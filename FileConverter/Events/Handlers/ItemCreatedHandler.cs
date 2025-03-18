using FileConverter.Events.Handlers.Base;

namespace FileConverter.Events.Handlers;

/// <summary>
/// Handler for item.created webhook
/// </summary>
public class ItemCreatedHandler : ParameterlessWebhookHandler
{
    protected override string SubscriptionEvent => "item.created";
}