using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace DialogFlowModels.v2.ResponseTypes
{
    public class TableCardResponse : AbstractRichResponse
    {
        public TableCard TableCard { get; set; }

        public TableCardResponse(string title)
        {
            TableCard = new TableCard{ Title = title};
        }

        public TableCardResponse(string title, string subtitle)
        {
            TableCard = new TableCard { Title = title, Subtitle = subtitle};
        }

        public TableCardResponse SetColumns(IEnumerable<string> headers, HorizontalAlignment alignment)
        {
            TableCard.ColumnProperties = headers.Select(h => new Column { Header= h, HorizontalAlignment = alignment}).ToList();
            return this;
        }

        public TableCardResponse AddRow(IEnumerable<string> cells)
        {
            TableCard.Rows.Add(new Row{Cells = cells.Select(c => new Cell{Text = c}).ToList()});
            return this;
        }

        public TableCardResponse AddImage(string imageUrl, string accessibilityText)
        {
            TableCard.Image = new Image { AccessibilityText = accessibilityText, Url = imageUrl };
            return this;
        }

        public TableCardResponse AddImage(string imageUrl, string accessibilityText, int width, int height)
        {
            TableCard.Image = new Image { AccessibilityText = accessibilityText, Url = imageUrl, Width = width, Height = height };
            return this;
        }

        public TableCardResponse SetImageDimensions(int width, int height)
        {
            TableCard.Image.Width = width;
            TableCard.Image.Height = height;
            return this;
        }

        public TableCardResponse SetButton(string title, string url)
        {
            TableCard.Buttons = new List<Button>
            {
                new Button {Title = title, OpenUrlAction = new OpenUrlAction {Url = url}}
            };
            return this;
        }

        public TableCardResponse SetButton(string title, string url, string androidPackageName)
        {
            TableCard.Buttons = new List<Button>
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

    public class TableCard
    {
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public Image Image { get; set; }
        public List<Column> ColumnProperties { get; set; }
        public List<Row> Rows { get; set; }
        public List<Button> Buttons { get; set; }

        public TableCard()
        {
            Rows = new List<Row>();
            ColumnProperties = new List<Column>();
        }
    }

    public class Column
    {
        public string Header { get; set; }
        public HorizontalAlignment HorizontalAlignment { get; set; }
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum HorizontalAlignment
    {
        LEADING,
        CENTER,
        TRAILING
    }

    public class Row
    {
        public List<Cell> Cells { get; set; }
        public bool DividerAfter { get; set; }
    }

    public class Cell
    {
        public string Text { get; set; }
    }
}
