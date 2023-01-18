using Application.Models.Abstractions;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Application.Common
{
    public class ContentModelConverter : JsonConverter<IContentModel>
    {
        [return: MaybeNull]
        public override IContentModel Read(
            ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) => null;

        public override void Write(
          Utf8JsonWriter writer, IContentModel value, JsonSerializerOptions options) =>
            JsonSerializer.Serialize(writer, value as object, options);
    }
}
