using Newtonsoft.Json;

namespace DialogFlowModels.v1.ResponseTypes.ResponseParts
{
    public class CardButton
    {
        [JsonProperty(PropertyName = "openUrlAction")]
        public OpenUrlAction OpenUrlAction { get; set; }

        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }
    }
}