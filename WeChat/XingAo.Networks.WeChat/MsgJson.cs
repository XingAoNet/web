using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XingAo.Networks.WeChat
{
    public class MsgJson
    {
        public MsgJson(string _title,string _des,string pic,string url)
        {
            Title = _title;
            Description = _des;
            PicUrl = pic;
            Url = url;
        }
        public string Title { get; set; }
        public string Description { get; set; }
        public string PicUrl { get; set; }
        public string Url { get; set; }
    }
}
