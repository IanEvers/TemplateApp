using Blackbird.Applications.Sdk.Common;

namespace FileConverter.Events.Models.Payload;

public class CallbackPayload
{
    [Display("Data")]
    public string Data { get; set; }
}