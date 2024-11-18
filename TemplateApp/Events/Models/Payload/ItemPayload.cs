using Blackbird.Applications.Sdk.Common;

namespace TemplateApp.Events.Models.Payload;

public class ItemPayload
{
    [Display("ID")]
    public string Id { get; set; }
    
    [Display("Title")]
    public string Title { get; set; }
}