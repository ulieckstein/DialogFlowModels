using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using DialogFlowModels.ExtensionMethods;

namespace DialogFlowModels.v1
{
    public class DialogFlowRequest<T>
    {
        public string Id { get; set; }
        public string SessionId { get; set; }
        public DateTime Timestamp { get; set; }
        public string Lang { get; set; }
        public DialogFlowResult<T> Result { get; set; }

        public static async Task<DialogFlowRequest<T>> Parse(HttpRequestMessage req)
        {
            return await req.Content.ReadAsJsonAsync<DialogFlowRequest<T>>();
        }
    }

    public class DialogFlowRequest : DialogFlowRequest<Dictionary<string, Object>> { }

    public class DialogFlowResult<T>
    {
        public string Source { get; set; }
        public string ResolvedQuery { get; set; }
        public string Speech { get; set; }
        public string Action { get; set; }
        public bool ActionIncomplete { get; set; }
        public T Parameters { get; set; }
        public DialogFlowMetadata Metadata { get; set; }
        public decimal Score { get; set; }
    }

    public class DialogFlowMetadata
    {
        public string IntentId { get; set; }
        public bool WebhookUsed { get; set; }
        public bool WebhookForSlotFillingUsed { get; set; }
        public string IntentName { get; set; }
    }

}
