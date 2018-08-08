using Newtonsoft.Json;

namespace DialogFlowModels.v1.ResponseTypes
{
    public class Text : AbstractRichResponse
    {
        public Text(string speech, string displayText)
        {
            DisplayText = displayText;
            TextToSpeech = speech;

        }
        public override string Type => "simple_response";

        [JsonProperty(PropertyName = "textToSpeech")]
        public string TextToSpeech { get; set; }
        [JsonProperty(PropertyName = "displayText")]
        public string DisplayText { get; set; }
    }
}
