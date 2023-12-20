using Newtonsoft.Json;

namespace N90_HT1.Application.Common.Serializers;

public interface IJsonSerializationSettingsProvider
{
    JsonSerializerSettings Get(bool clone = false);
}