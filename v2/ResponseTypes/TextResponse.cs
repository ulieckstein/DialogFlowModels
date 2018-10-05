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

        public TextResponse(string textToSpeech, string displayText)
        {
            SimpleResponse = new SimpleResponse
            {
                TextToSpeech = textToSpeech,
                DisplayText = displayText
            };
        }

        public void AddSsml(string ssml)
        {
            SimpleResponse.Ssml = ssml;
        }

    }

    public class SimpleResponse
    {
        public string TextToSpeech { get; set; }
        public string Ssml { get; set; }
        public string DisplayText { get; set; }
    }
}
