using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;
using TemplateApp.DataSourceHandlers;

namespace TemplateApp.Models.Request;

public class DataSourceWithParametersRequest
{
    [Display("Entity ID")]
    public string EntityId { get; set; }
    
    [Display("URL")]
    public string Url { get; set; }
    
    [Display("Dynamic input")]
    // Applying data source handler with parameters
    [DataSource(typeof(DataSourceHandlerWithParameters))]
    public string DynamicInput { get; set; }
}