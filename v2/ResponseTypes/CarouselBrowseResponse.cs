using System;
using System.Collections.Generic;
using System.Text;

namespace DialogFlowModels.v2.ResponseTypes
{
    public class CarouselBrowseResponse
    {
        public CarouselBrowse CarouselBrowse { get; set; }

        public CarouselBrowseResponse()
        {
            CarouselBrowse = new CarouselBrowse();
        }

        public CarouselBrowseResponse AddItem(string title, string targetUrl)
        {
            CarouselBrowse.Items.Add(new CarouselBrowseItem{Title = title, OpenUrlAction = new OpenUrlAction{Url = targetUrl}});
            return this;
        }

        public CarouselBrowseResponse AddItem(string title, string description, string footer, string targetUrl)
        {
            CarouselBrowse.Items.Add(
                new CarouselBrowseItem
                {
                    Title = title,
                    Description = description,
                    Footer = footer,
                    OpenUrlAction = new OpenUrlAction { Url = targetUrl }
                });
            return this;
        }

        public CarouselBrowseResponse AddItem(string title, string description, string footer, string imageUrl, string accessibilityText, string targetUrl)
        {
            CarouselBrowse.Items.Add(
                new CarouselBrowseItem
                {
                    Title = title,
                    Description = description,
                    Footer = footer,
                    Image = new Image { Url = imageUrl, AccessibilityText = accessibilityText},
                    OpenUrlAction = new OpenUrlAction { Url = targetUrl }
                });
            return this;
        }

        public CarouselBrowseResponse AddItem(CarouselBrowseItem item)
        {
            CarouselBrowse.Items.Add(item);
            return this;
        }
    }

    public class CarouselBrowse
    {
        public List<CarouselBrowseItem> Items { get; set; }
        public ImageDisplayOptions ImageDisplayOptions { get; set; }

        public CarouselBrowse()
        {
            Items = new List<CarouselBrowseItem>();
        }
    }

    public class CarouselBrowseItem
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Footer { get; set; }
        public Image Image { get; set; }
        public OpenUrlAction OpenUrlAction { get; set; }
    }
}
