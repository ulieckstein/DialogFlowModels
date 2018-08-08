using System.Collections.Generic;
using Newtonsoft.Json;

namespace DialogFlowModels.v1.ResponseTypes.ResponseParts
{
    public class OptionInfo
    {
        [JsonProperty(PropertyName = "key")]
        public string Key { get; set; }

        [JsonProperty(PropertyName = "synonyms")]
        public List<string> Synonyms { get; set; }
    }
}