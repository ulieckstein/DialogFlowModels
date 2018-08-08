using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using DialogFlowModels.v1.ResponseTypes;
using Newtonsoft.Json;

namespace DialogFlowModels.v1
{
    public class Response
    {
        [JsonProperty(PropertyName = "messages")]
        protected List<AbstractRichResponse> Messages { get; set; }
        //check if this is still serialized

        [JsonIgnore]
        public Text Text { get; set; }

        public Response() { }

        public Response(string textToSpeech, string displayText)
        {
            SetResponseText(textToSpeech, displayText);
        }

        public Response(string text)
        {
            SetResponseText(text);
        }

        public Response SetResponseText(string texttoSpeech, string displayText)
        {
            Text = new Text(texttoSpeech, displayText);
            return this;
        }

        public Response SetResponseText(string text)
        {
            return SetResponseText(text, text);
        }

        protected virtual void GenerateMessageList()
        {
            Messages = new List<AbstractRichResponse> { Text };
        }

        public HttpResponseMessage GenerateResponseMessage()
        {
            GenerateMessageList();

            var resp = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(JsonConvert.SerializeObject(this), System.Text.Encoding.UTF8, "text/plain")
            };
            return resp;
        }

        public CarouselCardResponse AsCarouselCardResponse()
        {
            return new CarouselCardResponse(this);
        }

        public BasicCardResponse AsBasicCardResponse()
        {
            return new BasicCardResponse(this);
        }
    }
}
