using System;
using System.Linq;
using Punch.Core;
using Newtonsoft.Json;

namespace Punch.Serialization
{
    public class JsFunctionConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType.Equals(typeof(string)) && objectType.CustomAttributes.Any(t=> t.GetType().IsAssignableFrom(typeof(KnockoutBaseAttribute)));
        }

        public override object ReadJson(JsonReader reader, System.Type objectType, object existingValue, Newtonsoft.Json.JsonSerializer serializer)
        {
            return existingValue;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var str = (string)value;
            writer.WriteRawValue(str);
        }
    }
}
