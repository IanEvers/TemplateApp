using Blackbird.Applications.Sdk.Common.Webhooks;
using FileConverter.Events.Handlers.Base;
using FileConverter.Events.Models.Inputs;

namespace FileConverter.Events.Handlers;

public class ProjectItemCreatedHandler : ProjectWebhookHandler
{
    protected override string SubscriptionEvent => "project.item.created";

    public ProjectItemCreatedHandler([WebhookParameter] ProjectWebhookInput input) : base(input)
    {
    }
}