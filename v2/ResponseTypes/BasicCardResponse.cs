using System;
using System.Collections.Generic;
using System.Text;

namespace DialogFlowModels.v2.ResponseTypes
{
    public class BasicCardResponse
    {
        public BasicCard BasicCard { get; set; }
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

    public enum UrlTypeHint
    {
        URL_TYPE_HINT_UNSPECIFIED,
        AMP_CONTENT
    }
}
