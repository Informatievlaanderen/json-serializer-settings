# Be.Vlaanderen.Basisregisters.AspNetCore.Mvc.Formatters.Json [![Build Status](https://github.com/Informatievlaanderen/json-serializer-settings/workflows/CI/badge.svg)](https://github.com/Informatievlaanderen/json-serializer-settings/actions)

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
