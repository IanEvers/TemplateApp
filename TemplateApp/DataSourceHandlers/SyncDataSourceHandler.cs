using Blackbird.Applications.Sdk.Utils.Sdk.DataSourceHandlers;

namespace TemplateApp.DataSourceHandlers;

/// <summary>
/// Data source handler for dynamic input values
/// Fetches data synchronously, can be used e.g. for enums
/// Extends EnumDataHandler class that already has implemented logic for configuring response from enum values
/// </summary>
public class SyncDataSourceHandler : EnumDataHandler
{
    protected override Dictionary<string, string> EnumValues => new()
    {
        { "water_electric", "Water/Electric" },
        { "fighting_psychic", "Fighting/Psychic" },
        { "grass_flying", "Grass/Flying" }
    };
}