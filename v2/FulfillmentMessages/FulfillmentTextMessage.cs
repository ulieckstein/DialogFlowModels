using System.Collections.Generic;

namespace DialogFlowModels.v2.FulfillmentMessages
{
    public class FulfillmentTextMessage {
        public List<string> Text { get; set; }

        public FulfillmentTextMessage()
        {
            Text = new List<string>();
        }
    }
}