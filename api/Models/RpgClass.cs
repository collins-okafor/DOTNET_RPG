// using System.Text.Json.Serialization;

using System.Text.Json.Serialization;

namespace api.Models
{
    public enum RpgClass
    {
        [JsonConverter(typeof(JsonStringEnumConverter))]
        Knight,
        Mage,
        Cleric
    }
}