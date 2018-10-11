using System;
using System.Collections.Generic;
using System.Text;

namespace DialogFlowModels.v2.ResponseTypes
{
    public class CarouselBrowseResponse
    {
        public CarouselBrowse CarouselBrowse { get; set; }

    }

    public class CarouselBrowse
    {
        public List<CarouselBrowseItem> Items { get; set; }
        public ImageDisplayOptions ImageDisplayOptions { get; set; }
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
