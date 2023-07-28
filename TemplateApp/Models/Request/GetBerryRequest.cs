using Blackbird.Applications.Sdk.Common;

namespace TemplateApp.Models.Request;

/// <summary>
/// Request model for adding new item payload
/// </summary>
public class GetBerryRequest
{
    // Properties must have display attributes which contain user-friendly name of variable
    [Display("Berry name")]
    public string BerryName { get; set; }
}