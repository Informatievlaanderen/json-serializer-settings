namespace Be.Vlaanderen.Basisregisters.AspNetCore.Mvc.Formatters.Json.Tests.Infrastructure
{
    using FluentAssertions;
    using FluentAssertions.Primitives;
    using Types;

    public class JsonPropertyAssertion
    {
        private readonly StringAssertions _assertions;
        private readonly CamelCasedString _property;

        public JsonPropertyAssertion(StringAssertions assertions, CamelCasedString property)
        {
            _assertions = assertions;
            _property = property;
        }

        public AndConstraint<JsonPropertyAssertion> AppearingBeforeProperty(CamelCasedString nextProperty)
        {
            var assertions = _assertions.MatchRegex($"\"{_property}\":.*\"{nextProperty}\":").And;
            return new AndConstraint<JsonPropertyAssertion>(new JsonPropertyAssertion(assertions, _property));
        }

        public AndConstraint<JsonPropertyAssertion> AppearingAfterProperty(CamelCasedString previousProperty)
        {
            var assertions = _assertions.MatchRegex($"\"{previousProperty}\":.*\"{_property}\":").And;
            return new AndConstraint<JsonPropertyAssertion>(new JsonPropertyAssertion(assertions, _property));
        }

        public StringAssertions And => _assertions;
    }
}
