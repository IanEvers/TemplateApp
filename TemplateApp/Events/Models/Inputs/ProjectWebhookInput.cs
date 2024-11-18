using Blackbird.Applications.Sdk.Common;

namespace TemplateApp.Events.Models.Inputs;

public class ProjectWebhookInput
{
    [Display("Project ID")]
    public string ProjectId { get; set; }
}