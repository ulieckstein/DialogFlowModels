using System;
using System.Collections.Generic;
using System.Text;
using DialogFlowModels.v1.ResponseTypes;

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
            FulfillmentMessages.Clear();
            FulfillmentMessages.Add(new FulfillmentMessage(text));

            var payload = new ResponsePayload
            {
                ExpectUserResponse = false,
                Items = new List<AbstractRichResponse>
                {
                    new Text(text, text)
                }
            };
            Payload["google"] = payload;
        }
    }

    public class FulfillmentMessage
    {
        public List<string> Text { get; set; }

        public FulfillmentMessage()
        {
            Text = new List<string>();
        }

        public FulfillmentMessage(string text)
        {
            Text = new List<string>{text};
        }

        public FulfillmentMessage(List<string> textList)
        {
            Text = textList;
        }
    }

    public class ResponsePayload
    {
        public bool ExpectUserResponse { get; set; }
        public List<AbstractRichResponse> Items { get; set; }
    }
}
