namespace Be.Vlaanderen.Basisregisters.AspNetCore.Mvc.Formatters.Json.Tests.Infrastructure.Types
{
    public class CamelCasedString
    {
        private readonly string _camelCasedValue;

        public CamelCasedString(string value)
            => _camelCasedValue = char.ToLowerInvariant(value[0]) + value.Substring(1);

        public override string ToString()
        {
            return _camelCasedValue;
        }

        public static implicit operator CamelCasedString(string value) => new CamelCasedString(value);
    }
}
