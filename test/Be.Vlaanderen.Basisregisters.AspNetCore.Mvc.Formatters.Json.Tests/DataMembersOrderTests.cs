namespace Be.Vlaanderen.Basisregisters.AspNetCore.Mvc.Formatters.Json.Tests
{
    using System.Runtime.Serialization;
    using FluentAssertions;
    using Infrastructure;
    using Newtonsoft.Json;
    using Xunit;

    public class WhenSerializingAModelWithDefinedPropertyOrder
    {
        private readonly string _jsonResult;
        
        public WhenSerializingAModelWithDefinedPropertyOrder()
        {
            var serializerSettings = new JsonSerializerSettings { ContractResolver = DefaultApiJsonContractResolver.UsingDefaultNamingStrategy() };

            _jsonResult = JsonConvert.SerializeObject(new OrderTestModel(), serializerSettings);
        }

        [Fact]
        public void ThenDataMemberOrderIsRespected()
        {
            _jsonResult
                .Should()
                .HaveProperty(nameof(OrderTestModel.PropertyOne))
                .AppearingBeforeProperty(nameof(OrderTestModel.PropertyTwo));
        }

        [Fact]
        public void ThenDataMemberOrderIsRespectedInCaseOfAJsonPropertyWithoutOrder()
        {
            _jsonResult
                .Should()
                .HaveProperty(nameof(OrderTestModel.PropertyFour))
                .AppearingAfterProperty(nameof(OrderTestModel.PropertyOne))
                .And
                .AppearingAfterProperty(nameof(OrderTestModel.PropertyTwo));
        }

        [Fact]
        public void ThenDataMemberOrderIsOverruledInCaseOfAJsonPropertyWithOrder()
        {
            _jsonResult
                .Should()
                .HaveProperty(nameof(OrderTestModel.PropertyThree))
                .AppearingAfterProperty(nameof(OrderTestModel.PropertyOne))
                .And
                .AppearingAfterProperty(nameof(OrderTestModel.PropertyTwo))
                .And
                .AppearingBeforeProperty(nameof(OrderTestModel.PropertyFour));
        }

        private class OrderTestModel
        {
            [DataMember(Order = 4)]
            [JsonProperty]
            public object? PropertyFour { get; set; }

            [DataMember(Order = 0)]
            [JsonProperty(Order = 3)]
            public object? PropertyThree { get; set; }

            [DataMember(Order = 2)]
            public object? PropertyTwo { get; set; }

            [DataMember(Order = 1)]
            public object? PropertyOne { get; set; }
        }
    }
}
