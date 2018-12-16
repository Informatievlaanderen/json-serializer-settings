# Be.Vlaanderen.Basisregisters.AspNetCore.Mvc.Formatters.Json

Default Json.NET serializer settings.

## Usage

```csharp
public IServiceProvider ConfigureServices(IServiceCollection services)
{
    services
        ...
        .AddJsonOptions(options => options.SerializerSettings.ConfigureDefaultForApi())
        ...
    ...
}
```

```csharp
var jsonSettings = JsonSerializerSettingsProvider.CreateSerializerSettings().ConfigureDefaultForApi();
JsonConvert.DefaultSettings = () => jsonSettings;
```
