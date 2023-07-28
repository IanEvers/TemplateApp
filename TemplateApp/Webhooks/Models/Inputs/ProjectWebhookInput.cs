using Blackbird.Applications.Sdk.Common;

namespace TemplateApp.Webhooks.Models.Inputs;

public class ProjectWebhookInput
{
    [Display("Project ID")]
    public string ProjectId { get; set; }
}