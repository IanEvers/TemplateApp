using Blackbird.Applications.Sdk.Common;

namespace FileConverter.Models.Request;

public class CreateCallbackRequest
{
    // This input is now optional
    [Display("Action")] public string? Action { get; set; }
    [Display("Callback URL")] public string CallbackUrl { get; set; }
}