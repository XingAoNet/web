using System.Text;
using XingAo.Core;

namespace XingAo.Networks.CMS.Template.Label.SystemLabel
{
    /// <summary>
    /// 分页信息类
    /// </summary>
    public static class PageInfo
    {
        #region-----------分页信息（URL重写）---------------------------------------------
        
        /// <summary>
        /// 返回URL重写过的分页信息
        /// </summary>
        /// <param name="RecordNum">总记录总</param>
        /// <param name="PageSize">每页记录数</param>
         /// <returns>分页信息</returns>
        public static string GetPageInfo(int RecordNum, int PageSize)
        {
            return GetPageInfo(RecordNum, PageSize, new GetRouteData().GetPage());
        }
        /// <summary>
        /// 返回URL重写过的分页信息
        /// </summary>
        /// <param name="RecordNum">总记录总</param>
        /// <param name="PageSize">每页记录数</param>
        /// <param name="NowPage">当前页码</param>
        /// <returns>分页信息</returns>
        public static string GetPageInfo(int RecordNum, int PageSize, int NowPage)
        {
            int P_Page = NowPage - 1, N_Page = NowPage + 1, L_Page = (RecordNum + PageSize - 1) / PageSize;
            if (N_Page > L_Page)
            {
                N_Page = L_Page;
            }
            if (P_Page < 1)
            {
                P_Page = 1;
            }
            GetRouteData mr = new GetRouteData();
            StringBuilder PageInfo = new StringBuilder();
            PageInfo.Append("<table width='99%' border='0' cellspacing='0' cellpadding='0' id='pageinfo'>\n");
            PageInfo.Append("<tr>\n");
            PageInfo.Append("<td align='center'>共" + RecordNum + "条记录 分" + L_Page + "页 每页显示" + PageSize + "条数据 当前" + NowPage + "/" + L_Page + "页 ");
            if (NowPage == 1)
            {
                PageInfo.Append("<font color=gray>首页 上一页</font>");
            }
            else
            {
                PageInfo.Append("<a href=\"/" + mr.GetClassName() + "/\">首页</a> <a href=\"/" + mr.GetClassName() + "/" + P_Page.ToString() + "\">上一页</a>");
            }
            if (NowPage == L_Page || RecordNum <= 0)
            {
                PageInfo.Append(" <font color=gray>下一页 尾页</font>");
            }
            else
            {
                PageInfo.Append(" <a href=\"/" + mr.GetClassName() + "/" + N_Page.ToString() + "\">下一页</a> <a href=\"/" + mr.GetClassName() + "/" + L_Page.ToString() + "\">尾页</a>");
            }

            PageInfo.Append("</td>\n");
            PageInfo.Append("</tr>\n");
            PageInfo.Append("</table>\n");
            return PageInfo.ToString();
        }

        /// <summary>
        /// 返回URL重写过的分页信息
        /// </summary>
        /// <param name="RecordNum">总记录数</param>
        /// <param name="PageSize">每页显示记录数</param>
        /// <param name="UrlFormat">链接格式化，如"/{0}/{1}" 或"/{0}/Show_{1}" 或 "/{0}/SearchExp_{1}" /{0}/SearchExp_SearchPar/{1}等等，其中0必须是栏目英文名，1必须是页码，SearchExp是指其它参数，以实际操作值为准</param>
        /// <returns></returns>
        public static string GetPageInfo(int RecordNum, int PageSize, string UrlFormat)
        {
            return GetPageInfo( RecordNum,  PageSize,  new GetRouteData().GetPage(),  UrlFormat);
        }
        /// <summary>
        /// 返回URL重写过的分页信息
        /// </summary>
        /// <param name="RecordNum">总记录数</param>
        /// <param name="PageSize">每页显示记录数</param>
        /// <param name="NowPage">当前页，从1开始</param>
        /// <param name="UrlFormat">链接格式化，如"/{0}/{1}" 或"/{0}/Show_{1}" 或 "/{0}/SearchExp_{1}" /{0}/SearchExp_SearchPar/{1}等等，其中0必须是栏目英文名，1必须是页码，SearchExp是指其它参数，以实际操作值为准</param>
        /// <returns></returns>
        public static string GetPageInfo(int RecordNum, int PageSize, int NowPage, string UrlFormat)
        {
            int P_Page = NowPage - 1, N_Page = NowPage + 1, L_Page = (RecordNum + PageSize - 1) / PageSize;
            if (N_Page > L_Page)
            {
                N_Page = L_Page;
            }
            if (P_Page < 1)
            {
                P_Page = 1;
            }
            GetRouteData mr = new GetRouteData();
            StringBuilder PageInfo = new StringBuilder();
            PageInfo.Append("<table width='100%' border='0' cellspacing='0' cellpadding='0' id='pageinfo'>\n");
            PageInfo.Append("<tr>\n");
            PageInfo.Append("<td align='center'>共" + RecordNum + "条记录 分" + L_Page + "页 每页显示" + PageSize + "条数据 当前" + NowPage + "/" + L_Page + "页 ");
            if (NowPage == 1)
            {
                PageInfo.Append("<font color=gray>首页 上一页</font>");
            }
            else
            {
                PageInfo.Append("<a href=\"" + string.Format(UrlFormat, mr.GetClassName(), 1) + "\">首页</a> <a href=\"" + string.Format(UrlFormat, mr.GetClassName(), P_Page) + "\">上一页</a>");
            }
            if (NowPage == L_Page || RecordNum <= 0)
            {
                PageInfo.Append(" <font color=gray>下一页 尾页</font>");
            }
            else
            {
                PageInfo.Append(" <a href=\"" + string.Format(UrlFormat, mr.GetClassName(), N_Page) + "\">下一页</a> <a href=\"" + string.Format(UrlFormat, mr.GetClassName(), L_Page) + "\">尾页</a>");
            }

            PageInfo.Append("</td>\n");
            PageInfo.Append("</tr>\n");
            PageInfo.Append("</table>\n");
            return PageInfo.ToString();
        }
        #endregion-----------------------------------------------------------------------------------------------


    }
}
