using Newtonsoft.Json;

namespace DialogFlowModels.v1.ResponseTypes
{
    public class OpenUrlAction
    {
        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }
    }
}