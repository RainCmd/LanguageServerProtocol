using LanguageServer.Parameters;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace LanguageServer.Infrastructure.JsonDotNet
{
    internal class DocumentUriConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(DocumentUri);
        }

        public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
        {
            var token = JToken.Load(reader);
            return token.Type switch
            {
                JTokenType.Null => null,
                JTokenType.String => new DocumentUri(new UnifiedPath(token.ToObject<string>()!)),
                _ => throw new JsonSerializationException(),
            };
        }

        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, (value as DocumentUri)?.uri);
        }
    }
}
