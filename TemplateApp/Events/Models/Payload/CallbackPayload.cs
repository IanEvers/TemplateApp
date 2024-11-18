using Blackbird.Applications.Sdk.Common;

namespace TemplateApp.Events.Models.Payload;

public class CallbackPayload
{
    [Display("Data")]
    public string Data { get; set; }
}