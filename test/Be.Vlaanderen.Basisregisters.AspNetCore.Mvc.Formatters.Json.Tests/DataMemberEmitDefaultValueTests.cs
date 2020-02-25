namespace Be.Vlaanderen.Basisregisters.AspNetCore.Mvc.Formatters.Json.Tests
{
    using System.Runtime.Serialization;
    using FluentAssertions;
    using Infrastructure;
    using Newtonsoft.Json;
    using Xunit;

    public class WhenSerializingAModelWithDefaultValuesBehaviourDefinedByDataMember
    {
        private readonly string _jsonResult;

        public WhenSerializingAModelWithDefaultValuesBehaviourDefinedByDataMember()
        {
            var settings = new JsonSerializerSettings { ContractResolver = DefaultApiJsonContractResolver.UsingDefaultNamingStrategy() };

            _jsonResult = JsonConvert.SerializeObject(new TestModel(), settings);
        }

        [Fact]
        public void ThenPropertiesWithEmitDefaultValueShouldBeShown()
        {
            _jsonResult
                .Should()
                .HaveProperty(nameof(TestModel.AlwaysShownBool))
                .And
                .HaveProperty(nameof(TestModel.AlwaysShownInt))
                .And
                .HaveProperty(nameof(TestModel.AlwaysShownString));

        }

        [Fact]
        public void ThenPropertiesWithEmitDefaultValueDisabledShouldNotBeShown()
        {
            _jsonResult
                .Should()
                .NotHaveProperty(nameof(TestModel.HideOnDefaultBool))
                .And
                .NotHaveProperty(nameof(TestModel.HideOnDefaultInt))
                .And
                .NotHaveProperty(nameof(TestModel.HideOnDefaultString));
        }

        private class TestModel
        {
            [DataMember(EmitDefaultValue = true)]
            public int AlwaysShownInt { get; set; }

            [DataMember(EmitDefaultValue = false)]
            public int HideOnDefaultInt { get; set; }

            [DataMember(EmitDefaultValue = true)]
            public string? AlwaysShownString { get; set; }

            [DataMember(EmitDefaultValue = false)]
            public string? HideOnDefaultString { get; set; }

            [DataMember(EmitDefaultValue = true)]
            [JsonProperty]
            public bool? AlwaysShownBool { get; set; }

            [DataMember(EmitDefaultValue = false)]
            [JsonProperty]
            public bool? HideOnDefaultBool { get; set; }
        }
    }
    public class WhenSerializingAModelWithDefaultValuesBehaviourDefinedByJsonProperty
    {
        private readonly string _jsonResult;

        public WhenSerializingAModelWithDefaultValuesBehaviourDefinedByJsonProperty()
        {
            var settings = new JsonSerializerSettings { ContractResolver = DefaultApiJsonContractResolver.UsingDefaultNamingStrategy() };

            _jsonResult = JsonConvert.SerializeObject(new TestModel(), settings);
        }

        [Fact]
        public void ThenPropertiesWithJsonDefaultHandlingIncludeShouldBeShown()
        {
            _jsonResult
                .Should()
                .HaveProperty(nameof(TestModel.Emit_JsonInclude))
                .And
                .HaveProperty(nameof(TestModel.NoEmit_JsonInclude));
        }

        [Fact]
        public void ThenPropertiesWithJsonDefaultHandlingIgnoreShouldNotBeShown()
        {
            _jsonResult
                .Should()
                .NotHaveProperty(nameof(TestModel.Emit_JsonIgnore))
                .And
                .NotHaveProperty(nameof(TestModel.NoEmit_JsonIgnore));
        }

        [Fact]
        public void ThenPropertiesWithJsonDefaultHandlingPopulateShouldBeShown()
        {
            _jsonResult
                .Should()
                .HaveProperty(nameof(TestModel.Emit_JsonIncludeAndPopulate))
                .And
                .HaveProperty(nameof(TestModel.NoEmit_JsonIncludeAndPopulate));
        }

        [Fact]
        public void ThenPropertiesWithJsonDefaultHandlingIgnoreAndPopulateShouldNotBeShown()
        {
            _jsonResult
                .Should()
                .NotHaveProperty(nameof(TestModel.Emit_JsonIgnoreAndPopulate))
                .And
                .NotHaveProperty(nameof(TestModel.NoEmit_JsonIgnoreAndPopulate));
        }

        private class TestModel
        {
            [DataMember(EmitDefaultValue = true)]
            [JsonProperty(DefaultValueHandling = DefaultValueHandling.Include)]
            public string? Emit_JsonInclude { get; set; }

            [DataMember(EmitDefaultValue = true)]
            [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
            public string? Emit_JsonIgnore { get; set; }

            [DataMember(EmitDefaultValue = true)]
            [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
            public string? Emit_JsonIncludeAndPopulate { get; set; }

            [DataMember(EmitDefaultValue = true)]
            [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
            public string? Emit_JsonIgnoreAndPopulate { get; set; }

            [DataMember(EmitDefaultValue = false)]
            [JsonProperty(DefaultValueHandling = DefaultValueHandling.Include)]
            public string? NoEmit_JsonInclude { get; set; }

            [DataMember(EmitDefaultValue = false)]
            [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
            public string? NoEmit_JsonIgnore { get; set; }

            [DataMember(EmitDefaultValue = false)]
            [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
            public string? NoEmit_JsonIncludeAndPopulate { get; set; }

            [DataMember(EmitDefaultValue = false)]
            [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
            public string? NoEmit_JsonIgnoreAndPopulate { get; set; }
        }
    }
}
