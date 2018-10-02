using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using DialogFlowModels.ExtensionMethods;

namespace DialogFlowModels.v2
{
    public class DialogFlowRequest<T>
    {
        public string ResponseId { get; set; }

        public string Session { get; set; }

        public QueryResult<T> QueryResult { get; set; }
        
        public OriginalDetectIntentRequest OriginalDetectIntentRequest { get; set; }

        public static async Task<DialogFlowRequest<T>> Parse(HttpRequestMessage req)
        {
            return await req.Content.ReadAsJsonAsync<DialogFlowRequest<T>>();
        }
    }

    public class DialogFlowRequest : DialogFlowRequest<Dictionary<string, Object>> { }

    public class QueryResult<T>
    {
        public string LanguageCode { get; set; }
        public string QueryText { get; set; }
        public string FulfillmentText { get; set; }
        public string Action { get; set; }
        public bool AllRequiredParamsPresent { get; set; }
        public T Parameters { get; set; }
        public List<OutputContext<T>> OutputContexts { get; set; }
        public Intent Intent { get; set; }

        //"intentDetectionConfidence": 1,
        //"diagnosticInfo": {},
    }

    public class OutputContext<T>
    {
        public string Name { get; set; }
        public int LifespanCount { get; set; }
        public T Parameters { get; set; }
    }

    public class Intent
    {
        public string Name { get; set; }
        public string DisplayName { get; set; }
    }

    public class OriginalDetectIntentRequest
    {
        public string Source { get; set; }
        public string Version { get; set; }

        //"payload": {
        //"isInSandbox": true,
        //"surface": {
        //"capabilities": [...]
        //},
        //"inputs": [...],
        //"user": {...},
        //"conversation": {...},
        //"availableSurfaces": [...]
        //}
    }
}
