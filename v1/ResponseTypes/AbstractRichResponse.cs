using Newtonsoft.Json;

namespace DialogFlowModels.v1.ResponseTypes
{
    public abstract class AbstractRichResponse
    {
        [JsonProperty(PropertyName = "type")]
        public virtual string Type { get; }

        //[JsonProperty(PropertyName = "platform")]
        //public string Platform = "google";
    }
}
