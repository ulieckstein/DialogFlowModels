using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using DialogFlowModels.v2.FulfillmentMessages;
using DialogFlowModels.v2.ResponseTypes;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace DialogFlowModels.v2
{
    public class DialogFlowResponse
    {
        public string FulfillmentText { get; set; }
        public List<FulfillmentMessage> FulfillmentMessages { get; set; }
        public string Source { get; set; }
        public Dictionary<string, ResponsePayload> Payload { get; set; }

        public DialogFlowResponse()
        {
            Payload = new Dictionary<string, ResponsePayload>{{"google", new ResponsePayload()}};
            FulfillmentMessages = new List<FulfillmentMessage>();
        }

        public void AddTextResponse(string text)
        {
            FulfillmentText = text;
            FulfillmentMessages.Clear();
            FulfillmentMessages.Add(new FulfillmentMessage(text));

            var payload = new ResponsePayload
            {
                ExpectUserResponse = false,
                RichResponse = new RichResponsePayload { 
                    Items = new List<AbstractRichResponse>
                    {
                        new TextResponse(text)
                    }
                }
            };
            Payload["google"] = payload;
        }

        public HttpResponseMessage GenerateResponseMessage()
        {
            var serializerSettings = new JsonSerializerSettings();
            serializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            
            var resp = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(JsonConvert.SerializeObject(this, serializerSettings), System.Text.Encoding.UTF8, "text/plain")
            };
            return resp;
        }
    }

    public class ResponsePayload
    {
        public bool ExpectUserResponse { get; set; }
        public RichResponsePayload RichResponse { get; set; }

        public ResponsePayload()
        {
            RichResponse = new RichResponsePayload();
        }
    }

    public class RichResponsePayload
    {
        public List<AbstractRichResponse> Items { get; set; }

        public RichResponsePayload()
        {
            Items = new List<AbstractRichResponse>();
        }
    }
}
