﻿using Blackbird.Applications.Sdk.Common;

namespace FileConverter.Events.Models.Inputs;

public class ProjectWebhookInput
{
    [Display("Project ID")]
    public string ProjectId { get; set; }
}