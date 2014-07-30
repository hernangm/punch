using System.Linq;
using System.Reflection;
using Punch.Core;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Punch.Serialization
{
    public class IgnoreKnockoutDecoratedPropertiesContractResolver : DefaultContractResolver
    {

        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            JsonProperty property = base.CreateProperty(member, memberSerialization);
            property.Ignored = property.Ignored || HasKnockoutAttribute((PropertyInfo)member);
            return property;
        }

        public static bool HasKnockoutAttribute(PropertyInfo prop)
        {
            if (prop == null)
            {
                return false;
            }
            return prop.CustomAttributes.Any(at => at.AttributeType.IsSubclassOf(typeof(KnockoutBaseAttribute)));
        }
    }
}
