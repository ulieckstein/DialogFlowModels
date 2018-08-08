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

        public BrowseCarouselCardItem(string title, string description) : base(title, description)
        {
            Title = title;
            Description = description;
        }

        public new BrowseCarouselCardItem WithImage(string url, string accessibilityText)
        {
            base.WithImage(url, Title);
            return this;
        }

        public BrowseCarouselCardItem WithUrlAction(string url)
        {
            OpenUrlAction = new OpenUrlAction { Url = url };
            return this;
        }
    }
}