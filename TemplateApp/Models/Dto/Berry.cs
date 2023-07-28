using Blackbird.Applications.Sdk.Common;

namespace TemplateApp.Models.Dto;

/// <summary>
/// Dto class for item entity
/// </summary>
public class Berry
{
    // Properties must have display attributes which contain user-friendly name of variable
    [Display("Name")] public string Name { get; set; }

    [Display("URL")] public string Url { get; set; }
}