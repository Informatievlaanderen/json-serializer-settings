namespace Be.Vlaanderen.Basisregisters.AspNetCore.Mvc.Formatters.Json
{
    using Converters.TrimString;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Newtonsoft.Json.Serialization;
    using NodaTime;
    using NodaTime.Serialization.JsonNet;

    public static class FormatterExtensions
    {
        /// <summary>
        /// Sets up and adds additional converters for an API to the JsonSerializerSettings
        /// </summary>
        /// <param name="source"></param>
        /// <returns>the updated JsonSerializerSettings</returns>
        public static JsonSerializerSettings ConfigureDefaultForApi(this JsonSerializerSettings source)
        {
            if (source.ContractResolver is DefaultContractResolver resolver)
            {
                resolver.NamingStrategy.OverrideSpecifiedNames = true;
                resolver.NamingStrategy.ProcessDictionaryKeys = true;
            }

            source.DateFormatHandling = DateFormatHandling.IsoDateFormat;
            source.DateTimeZoneHandling = DateTimeZoneHandling.RoundtripKind;

            source.Converters.Add(new StringEnumConverter { CamelCaseText = true });
            source.Converters.Add(new TrimStringConverter());

            return source
                .ConfigureForNodaTime(DateTimeZoneProviders.Tzdb)
                .WithIsoIntervalConverter();
        }
    }
}
