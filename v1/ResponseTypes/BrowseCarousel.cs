using System.Collections.Generic;
using DialogFlowModels.v1.ResponseTypes.ResponseParts;
using Newtonsoft.Json;

namespace DialogFlowModels.v1.ResponseTypes
{

    public class BrowseCarouselCardResponse : Response
    {
        public BrowseCarouselCardResponse(Response baseResponse)
        {
            Text = baseResponse.Text;
            Carousel = new BrowseCarousel();
        }

        [JsonIgnore]
        private BrowseCarousel Carousel { get; set; }

        protected override void GenerateMessageList()
        {
            base.GenerateMessageList();
            Messages.Add(Carousel);
        }

        public BrowseCarouselCardResponse AddCard(BrowseCarouselCardItem item)
        {
            if (Carousel == null) Carousel = new BrowseCarousel();
            Carousel.Items.Add(item);
            return this;
        }
    }

    public class BrowseCarousel : AbstractRichResponse
    {
        public override string Type => "browse_carousel_card";

        [JsonProperty(PropertyName = "items")]
        public List<BrowseCarouselCardItem> Items { get; set; }

        public BrowseCarousel()
        {
            Items = new List<BrowseCarouselCardItem>();
        }

        public BrowseCarouselCardItem AddCard(string title, string description, string imageUrl, string openUrlAction)
        {
            var item = new BrowseCarouselCardItem(title, description, imageUrl, openUrlAction);
            Items.Add(item);
            return item;
        }

        public BrowseCarouselCardItem AddCard(string title, string description)
        {
            var item = new BrowseCarouselCardItem(title, description);
            Items.Add(item);
            return item;
        }
    }
}