using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XingAo.Networks.CMS.Model.OtherModel
{
    public class NavConfig
    {
        public string ID { get; set; }
        public int InsortDragDivIndex { get; set; }
        public Config config { get; set; }
    }

    public class Config
    {
        public string Title { get; set; }
        public string ShowType { get; set; }
        public string txtUrl { get; set; }
        public string txtKeys_text { get; set; }
        public string Url { get; set; }
        public string BackColor { get; set; }
        public string BackPic { get; set; }
        public string InfoID { get; set; }
        public string Source { get; set; }
        public string CustomInfo { get; set; }

        public string ShowRecordCount { get; set; }
        public string DateFormat { get; set; }
        public string ShowDate { get; set; }
    }
}
