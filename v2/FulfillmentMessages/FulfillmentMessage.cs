using System.Collections.Generic;

namespace DialogFlowModels.v2
{
    public class FulfillmentMessage
    {
        public FulfillmentTextMessage Text { get; set; }

        public FulfillmentMessage(string text)
        {
            Text = new FulfillmentTextMessage {Text = new List<string> {text}};
        }


        public FulfillmentMessage()
        {
            Text = new FulfillmentTextMessage();
        }


        public FulfillmentMessage(List<string> textList)
        {
            Text = new FulfillmentTextMessage { Text = textList };
        }
    }
}