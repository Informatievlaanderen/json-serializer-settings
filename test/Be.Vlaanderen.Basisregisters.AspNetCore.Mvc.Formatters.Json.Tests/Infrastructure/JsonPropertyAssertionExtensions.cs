namespace Be.Vlaanderen.Basisregisters.AspNetCore.Mvc.Formatters.Json.Tests.Infrastructure
{
    using FluentAssertions.Primitives;
    using Types;

    public static class JsonPropertyAssertionExtensions
    {
        public static JsonPropertyAssertion HaveProperty(this StringAssertions assertions, CamelCasedString property)
        {
            return new JsonPropertyAssertion(assertions.MatchRegex($"\"{property}\":").And, property);
        }

        public static JsonPropertyAssertion NotHaveProperty(this StringAssertions assertions, CamelCasedString property)
        {
            return new JsonPropertyAssertion(assertions.NotMatchRegex($"\"{property}\":").And, property);
        }
    }
}
