using System.Collections.Generic;
using DialogFlowModels.v1.ResponseTypes.ResponseParts;
using Newtonsoft.Json;

namespace DialogFlowModels.v1.ResponseTypes
{
    public class BasicCardResponse : Response
    {

        [JsonIgnore]
        private BasicCard Card { get; set; }

        public BasicCardResponse(Response baseResponse)
        {
            Text = baseResponse.Text;
        }

        protected override void GenerateMessageList()
        {
            base.GenerateMessageList();
            if (Card != null) Messages.Add(Card);
        }

        public void SetCard(BasicCard card)
        {
            Card = card;
        }
    }

    public class BasicCard : AbstractRichResponse
    {
        public override string Type => "simple_card";

        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "subtitle")]
        public string Subtitle { get; set; }

        [JsonProperty(PropertyName = "formattedText")]
        public string FormattedText { get; set; }

        [JsonProperty(PropertyName = "image")]
        public CardImage CardImage { get; set; }

        [JsonProperty(PropertyName = "buttons")]
        public IList<CardButton> Buttons { get; set; }

        public BasicCard(string title, string subtitle, string formattedText, string imageUrl)
        {
            Title = title;
            Subtitle = subtitle;
            FormattedText = formattedText;
            CardImage = new CardImage
            {
                Url = imageUrl
            };
            Buttons = new List<CardButton>();
        }

        public BasicCard AddButton(string title, string url)
        {
            Buttons.Add(new CardButton
            {
                Title = title,
                OpenUrlAction = new OpenUrlAction { Url = url }
            });
            return this;
        }
    }
}
