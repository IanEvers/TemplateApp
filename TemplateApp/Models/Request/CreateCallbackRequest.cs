using Blackbird.Applications.Sdk.Common;

namespace TemplateApp.Models.Request;

public class CreateCallbackRequest
{
    [Display("Action")] public string Action { get; set; }
    [Display("Callback URL")] public string CallbackUrl { get; set; }
}