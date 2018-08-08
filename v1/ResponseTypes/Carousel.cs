using System.Collections.Generic;
using DialogFlowModels.v1.ResponseTypes.ResponseParts;
using Newtonsoft.Json;

namespace DialogFlowModels.v1.ResponseTypes
{
    public class CarouselCardResponse : Response
    {
        public CarouselCardResponse(Response baseResponse)
        {
            Text = baseResponse.Text;
            Carousel = new Carousel();
        }

        [JsonIgnore]
        private Carousel Carousel { get; set; }

        protected override void GenerateMessageList()
        {
            base.GenerateMessageList();
            Messages.Add(Carousel);
        }

        public CarouselCardResponse AddCard(CarouselCardItem item)
        {
            if (Carousel == null) Carousel = new Carousel();
            Carousel.Items.Add(item);
            return this;
        }
    }

    public class Carousel : AbstractRichResponse
    {
        public override string Type => "carousel_card";

        [JsonProperty(PropertyName = "items")]
        public List<CarouselCardItem> Items { get; set; }

        public Carousel()
        {
            Items = new List<CarouselCardItem>();
        }

        public CarouselCardItem AddCard(string title, string description, string imageUrl)
        {
            var item = new CarouselCardItem(title, description, imageUrl);
            Items.Add(item);
            return item;
        }

        public CarouselCardItem AddCard(string title, string description)
        {
            var item = new CarouselCardItem(title, description);
            Items.Add(item);
            return item;
        }
    }
}
