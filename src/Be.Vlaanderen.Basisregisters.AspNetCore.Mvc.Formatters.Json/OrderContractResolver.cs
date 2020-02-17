namespace Be.Vlaanderen.Basisregisters.AspNetCore.Mvc.Formatters.Json
{
    using System.Linq;
    using System.Reflection;
    using System.Runtime.Serialization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;

    public class OrderContractResolver : CamelCasePropertyNamesContractResolver
    {
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            var property = base.CreateProperty(member, memberSerialization);
            var dataMemberAttribute = member.GetCustomAttributes<DataMemberAttribute>().SingleOrDefault();

            if (dataMemberAttribute != null)
                property.Order = dataMemberAttribute.Order;

            return property;
        }
    }
}
