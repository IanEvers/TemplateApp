using Blackbird.Applications.Sdk.Common;

namespace TemplateApp.Webhooks.Models.Payload;

public class CallbackPayload
{
    [Display("Data")]
    public string Data { get; set; }
}