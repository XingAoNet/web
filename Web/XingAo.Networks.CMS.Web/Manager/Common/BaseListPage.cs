using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XingAo.Core;
//using XingAo.Networks.CMS.Controller;

namespace XingAo.Networks.CMS.Web.Manager.Common
{
    /// <summary>
    /// 列表页基类
    /// </summary>
    public class BaseListPage : System.Web.UI.Page
    {
        protected override void OnLoadComplete(EventArgs e)
        {
            Model.ManagerUserCookiesModel loginUser = CookiesHelp.GetUsersCookies<Model.ManagerUserCookiesModel>();
            if (loginUser == null || loginUser.UserID<=0)
            {
                Response.Clear();
                Response.Write("{\"statusCode\":\"301\",\"message\":\"\u4f1a\u8bdd\u8d85\u65f6\uff0c\u8bf7\u91cd\u65b0\u767b\u5f55\u3002\",\"navTabId\":\"\",	\"callbackType\":\"\",	\"forwardUrl\":\"\"}");
                Response.End();
            }
        }
        #region 分页变量，与UI绑定
        private int numPerPage;
        /// <summary>
        /// 每页显示的条数
        /// </summary>
        public int PageSize
        {
            get
            {
                int temp =Request["numPerPage"].ObjToInt(20);
                return  temp;
            }
            set { numPerPage = value; }
        }

        private int pageNumShown = 10;
        /// <summary>
        /// 页数导航的个数
        /// </summary>
        public int PageNumShown
        {
            get { return pageNumShown; }
            set { pageNumShown = value; }
        }

        private int pageNum;
        /// <summary>
        /// 当前显示的页码，从1开始
        /// </summary>
        public int PageNum
        {
            get
            {
                int temp = Request["pageNum"].ObjToInt(1);
                if (temp > (TotalCount + PageSize - 1) / PageSize)
                    temp = (TotalCount + PageSize - 1) / PageSize;
                return (temp == 0 ? 1 : temp);
            }
            set
            {
                if (value > (TotalCount + PageSize - 1) / PageSize)
                    pageNum = (TotalCount + PageSize - 1) / PageSize;
                else
                    pageNum = value;
            }
        }

        private int totalCount = 9999999;
        /// <summary>
        /// 总条数
        /// </summary>
        public int TotalCount
        {
            get { return totalCount; }
            set { totalCount = value; }
        }

        //private string keywords;
        ///// <summary>
        ///// where语句，不加where与空格（存储搜索条件的隐藏表单值）
        ///// </summary>
        //public string Keywords
        //{
        //    get
        //    {
        //        string temp = Request["keywords"];                    
        //        return temp;
        //    }
        //    set { keywords = value; }
        //}

        private string orderField;
        /// <summary>
        /// 排序关键字
        /// </summary>
        public string OrderField
        {
            get
            {
                string temp = Request["orderField"];
                return temp;
            }
            set { orderField = value; }
        }

        private string _keyString = "";
        /// <summary>
        /// 快速搜索内的搜索关键字
        /// </summary>
        public string keyString
        {
            get
            {
                string temp = Request["keyString"];
                return temp;
            }
            set { _keyString = value; }
        }
        #endregion
    }
}