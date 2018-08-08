using Newtonsoft.Json;

namespace DialogFlowModels.v1.ResponseTypes.ResponseParts
{
    public class CardImage
    {
        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }

        [JsonProperty(PropertyName = "accessibilityText")]
        public string AccessibilityText { get; set; }
    }
}