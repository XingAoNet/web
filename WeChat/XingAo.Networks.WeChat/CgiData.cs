using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XingAo.Networks.WeChat
{
    public class CgiData
    {
        public int pageIdx { get; set; }
        public int pageCount { get; set; }
        public int pageSize { get; set; }
        public List<Groups> groupsList { get; set; }
        public string currentGroupId { get; set; }
        public string type { get; set; }
        public string userRole { get; set; }
        public string verifyMsgCount { get; set; }
        public List<Contacts> friendsList { get; set; }
    }
}
