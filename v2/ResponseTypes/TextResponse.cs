using System;
using System.Collections.Generic;
using System.Text;

namespace DialogFlowModels.v2.ResponseTypes
{
    public abstract class AbstractRichResponse
    {
    }

    public class TextResponse : AbstractRichResponse
    {
        public SimpleResponse SimpleResponse { get; set; }
        
        public TextResponse(string text)
        {
            SimpleResponse = new SimpleResponse
            {
                TextToSpeech = text
            };
        }

        
    }

    public class SimpleResponse
    {
        public string TextToSpeech { get; set; }
    }
}
