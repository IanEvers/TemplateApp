using Blackbird.Applications.Sdk.Common;

namespace FileConverter.Events.Models.Payload;

public class ItemPayload
{
    [Display("ID")]
    public string Id { get; set; }
    
    [Display("Title")]
    public string Title { get; set; }
}