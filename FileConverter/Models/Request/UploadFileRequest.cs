using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Files;

namespace FileConverter.Models.Request;

public class UploadFileRequest
{
    public FileReference File { get; set; }
    
    [Display("Upload URL", Description = "URL to upload the file")]
    public string UploadUrl { get; set; }
}