using Blackbird.Applications.Sdk.Common.Dynamic;

namespace TemplateApp.DataSourceHandlers;

/// <summary>
/// Data source handler for dynamic input values
/// Fetches data synchronously, can be used e.g. for enums
/// </summary>
public class SyncDataSourceHandler : IDataSourceHandler
{
    private Dictionary<string, string> EnumValues => new()
    {
        {"water_electric", "Water/Electric"},
        {"fighting_psychic", "Fighting/Psychic"},
        {"grass_flying", "Grass/Flying"}
    };
    
    public Dictionary<string, string> GetData(DataSourceContext context)
    {
        return EnumValues
                // Applying user search query to the response
            .Where(x => context.SearchString == null ||
                        x.Value.Contains(context.SearchString, StringComparison.OrdinalIgnoreCase))
            .ToDictionary(x => x.Key, x => x.Value);
    }
}