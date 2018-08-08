using System.Collections.Generic;
using Newtonsoft.Json;

namespace DialogFlowModels.v1.ResponseTypes.ResponseParts
{
    public class CarouselCardItem
    {
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "image")]
        public CardImage Image { get; set; }

        [JsonProperty(PropertyName = "optionInfo")]
        public OptionInfo OptionInfo { get; set; }

        public CarouselCardItem(string title, string description, string imageUrl)
        {
            Title = title;
            Description = description;
            Image = new CardImage { Url = imageUrl, AccessibilityText = title };
        }

        public CarouselCardItem(string title, string description)
        {
            Title = title;
            Description = description;
        }

        public CarouselCardItem WithImage(string imageUrl, string accessibilityText)
        {
            Image = new CardImage { Url = imageUrl, AccessibilityText = accessibilityText };
            return this;
        }

        public CarouselCardItem WithOption(string key, List<string> synonyms)
        {
            OptionInfo = new OptionInfo
            {
                Key = key,
                Synonyms = synonyms
            };
            return this;
        }
    }
}