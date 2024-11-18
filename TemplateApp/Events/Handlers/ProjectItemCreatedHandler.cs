using Blackbird.Applications.Sdk.Common.Webhooks;
using TemplateApp.Events.Handlers.Base;
using TemplateApp.Events.Models.Inputs;

namespace TemplateApp.Events.Handlers;

public class ProjectItemCreatedHandler : ProjectWebhookHandler
{
    protected override string SubscriptionEvent => "project.item.created";

    public ProjectItemCreatedHandler([WebhookParameter] ProjectWebhookInput input) : base(input)
    {
    }
}