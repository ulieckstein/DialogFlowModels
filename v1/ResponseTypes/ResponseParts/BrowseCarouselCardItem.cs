using Newtonsoft.Json;

namespace DialogFlowModels.v1.ResponseTypes.ResponseParts
{
    public class BrowseCarouselCardItem : CarouselCardItem
    {
        [JsonProperty(PropertyName = "openUrlAction")]
        public OpenUrlAction OpenUrlAction { get; set; }

        public BrowseCarouselCardItem(string title, string description, string imageUrl, string openUrlAction) : base(title, description, imageUrl)
        {
            OpenUrlAction = new OpenUrlAction { Url = openUrlAction };
        }

        public BrowseCarouselCardItem(string title, string description) : base(title, description){}

        public CarouselCardItem WithUrlAction(string url)
        {
            OpenUrlAction = new OpenUrlAction { Url = url };
            return this;
        }
    }
}