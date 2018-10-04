using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace DialogFlowModels.v2.ResponseTypes
{
    public class BasicCardResponse : AbstractRichResponse
    {
        public BasicCard BasicCard { get; set; }

        public BasicCardResponse(string title, string subtitle)
        {
            BasicCard = new BasicCard {Title = title, Subtitle = subtitle};
        }

        public BasicCardResponse(string title, string subtitle, string formattedText)
        {
            BasicCard = new BasicCard { Title = title, Subtitle = subtitle, FormattedText = formattedText};
        }

        public BasicCardResponse(string title, string subtitle, string imageUrl, string accessibilityText)
        {
            BasicCard = new BasicCard
            {
                Title = title,
                Subtitle = subtitle,
                Image = new Image {AccessibilityText = accessibilityText, Url = imageUrl}
            };
        }

        public BasicCardResponse AddImage(string imageUrl, string accessibilityText)
        {
            BasicCard.Image = new Image {AccessibilityText = accessibilityText, Url = imageUrl};
            return this;
        }

        public BasicCardResponse AddImage(string imageUrl, string accessibilityText, int width, int height)
        {
            BasicCard.Image = new Image { AccessibilityText = accessibilityText, Url = imageUrl, Width = width, Height = height};
            return this;
        }

        public BasicCardResponse SetImageDisplayOptions(ImageDisplayOptions options)
        {
            BasicCard.ImageDisplayOptions = options;
            return this;
        }

        public BasicCardResponse SetImageDimensions(int width, int height)
        {
            BasicCard.Image.Width = width;
            BasicCard.Image.Height = height;
            return this;
        }

        public BasicCardResponse SetButton(string title, string url)
        {
            BasicCard.Buttons = new List<Button>
            {
                new Button {Title = title, OpenUrlAction = new OpenUrlAction {Url = url}}
            };
            return this;
        }

        public BasicCardResponse SetButton(string title, string url, string androidPackageName)
        {
            BasicCard.Buttons = new List<Button>
            {
                new Button
                {
                    Title = title,
                    OpenUrlAction = new OpenUrlAction
                    {
                        Url = url,
                        AndroidApp = new AndroidApp
                        {
                            PackageName = androidPackageName
                        }
                    },
                }
            };
            return this;
        }
    }

    public class BasicCard
    {
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string FormattedText { get; set; }
        public Image Image { get; set; }
        public List<Button> Buttons { get; set; }
        public ImageDisplayOptions ImageDisplayOptions { get; set; }
    }

    public class Image
    {
        public string Url { get; set; }
        public string AccessibilityText { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
    }

    public class Button
    {
        public string Title { get; set; }
        public OpenUrlAction OpenUrlAction { get; set; }
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum ImageDisplayOptions
    {
        DEFAULT,
        WHITE,
        CROPPED
    }

    public class OpenUrlAction
    {
        public string Url { get; set; }
        public AndroidApp AndroidApp { get; set; }
        public UrlTypeHint UrlTypeHint { get; set; }
    }

    public class AndroidApp
    {
        public string PackageName { get; set; }
        public List<VersionFilter> Versions { get; set; }
    }

    public class VersionFilter
    {
        public int MinVersion { get; set; }
        public int MaxVersion { get; set; }
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum UrlTypeHint
    {
        URL_TYPE_HINT_UNSPECIFIED,
        AMP_CONTENT
    }
}
