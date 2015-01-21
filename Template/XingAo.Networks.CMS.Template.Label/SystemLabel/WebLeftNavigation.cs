using System.Collections.Generic;
using System.Linq;
using System.Text;
using XingAo.Networks.CMS.Template.Label.LabelFunctions;
using XingAo.Core;
using XingAo.Core.Data;

namespace XingAo.Networks.CMS.Template.Label.SystemLabel
{
    /// <summary>
    /// 网站左侧导航标签
    /// </summary>
    public class WebLeftNavigation
    {
        /// <summary>
        /// 取网站左侧栏目导航html
        /// </summary>
        /// <returns></returns>
        public static string GetHtml()
        {
           GetRouteData rd = new GetRouteData();
           string ClassCode=WebNavigationConvert.GetCodeByEName(rd.GetClassName());
           if (ClassCode == "")
               return "";
           if (ClassCode.Length > 4)
               ClassCode = ClassCode.Substring(0, 4);
           StringBuilder html;
           if (DataCache.GetCache("WebLeftMenu_" + ClassCode, DataCache.DataCacheType.Menu).ObjToStr() == "")
           {
               UnitOfWork uk = new UnitOfWork();
               int r = 0;
               List<Model.WebNavigation> data = uk.LoadWhereLambda<Model.WebNavigation>(p => p.ShowInLeftNavigation == 1 && p.Code.StartsWith(ClassCode), p => p.OrderBy(c => c.Code), 1, 99999, out r).ToList();// && p.Code.Length > ClassCode.Length
               html = EachAll(ClassCode, data,0);
               DataCache.SetCache("WebLeftMenu_" + ClassCode, html, 99999, DataCache.DataCacheType.Menu);
           }
           else
               html=(StringBuilder)DataCache.GetCache("WebLeftMenu_" + ClassCode, DataCache.DataCacheType.Menu);
           return html.ToString();
        }
        
        private static StringBuilder EachAll(string P,  List<Model.WebNavigation> Data, int deep)
        {
            string FirstUlCssClass = " class=\"LeftMenuUl{0}\"";
            string FirstLiCssClass = " class=\"LeftMenuLi{0}\"";
            StringBuilder sb = new StringBuilder("<ul" + string.Format(FirstUlCssClass, deep == 0 ? "" : deep.ToString()) + ">\n");
            if (P.Length == 4) sb.AppendLine("<li class='first'>" + Data.FirstOrDefault(p=>p.Code==P).Name + "</li>");
            foreach (Model.WebNavigation lmm in Data.Where(p => p.Code.StartsWith(P) && p.Code.Length == P.Length + 4))
            {
                sb.Append("<li" + string.Format(FirstLiCssClass, deep == 0 ? "" : deep.ToString()) + "><a href=\"" + (string.IsNullOrEmpty(lmm.OutLink.Trim()) ? "/" + lmm.EName : lmm.OutLink) + "\"" + lmm.Target + ">" + lmm.Name + "</a>");
                sb.Append(EachAll(lmm.Code, Data, ++deep));
                deep--;
                sb.Append("</li>\n");
            }
            sb.Append("</ul>\n");
            if (sb.ToString() == "<ul" + string.Format(FirstUlCssClass, deep == 0 ? "" : deep.ToString()) + ">\n</ul>\n")
                return new StringBuilder();
            return sb;
            //throw new NotImplementedException();
        }

    }
}
