using Blackbird.Applications.Sdk.Common.Webhooks;
using TemplateApp.Webhooks.Handlers.Base;
using TemplateApp.Webhooks.Models.Inputs;

namespace TemplateApp.Webhooks.Handlers;

public class ProjectItemCreatedHandler : ProjectWebhookHandler
{
    protected override string SubscriptionEvent => "project.item.created";

    public ProjectItemCreatedHandler([WebhookParameter] ProjectWebhookInput input) : base(input)
    {
    }
}