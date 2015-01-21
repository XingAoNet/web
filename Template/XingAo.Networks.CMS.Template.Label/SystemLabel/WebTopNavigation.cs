using System.Collections.Generic;
using System.Linq;
using System.Text;
using XingAo.Core;
using XingAo.Core.Data;

namespace XingAo.Networks.CMS.Template.Label.SystemLabel
{
    /// <summary>
    /// 网站顶部导航标签
    /// </summary>
    public class WebTopNavigationLabel
    {
        /// <summary>
        /// 取网站顶部栏目导航html
        /// </summary>
        /// <returns></returns>
        public static string GetHtml()
        {
            GetRouteData rd = new GetRouteData();
            string ClassName = rd.GetClassName();

            string TopMenu=DataCache.GetCache("WebTopMenu", DataCache.DataCacheType.Menu).ObjToStr();
            if (TopMenu == "")
            {
                UnitOfWork uk = new UnitOfWork();
                int r = 0;
                List<Model.WebNavigation> data = uk.LoadWhereLambda<Model.WebNavigation>(p => p.ShowInTopNavigation == 1, p => p.OrderBy(c => c.Code), 1, 99999, out r).ToList();
                StringBuilder _TopMenu = EachAll("", data, ClassName).AppendLine("<script type=\"text/javascript\" src=\"/Scripts/WebTopMenu.min.js\"></script>");
                DataCache.SetCache("WebTopMenu", _TopMenu, 99999, DataCache.DataCacheType.Menu);
                TopMenu = _TopMenu.ToString();
            }
            return TopMenu;
        }
        /// <summary>
        /// 递归取所有栏目
        /// </summary>
        /// <param name="code">当前层级的编码，第一层为空</param>
        /// <param name="AllData">所有栏目及所有子级的数据</param>
        /// <returns></returns>
        private static StringBuilder EachAll(string code, List<Model.WebNavigation> AllData, string ClassName)
        {
            StringBuilder item = new StringBuilder("\n<ul");
            List<Model.WebNavigation> data;
            if (code == "")
            {
                item.Append(" id=\"menu\"");
                data = AllData.Where(p => p.Code.Length == 4).ToList();
            }
            else
            {
                data = AllData.Where(p=>p.Code.StartsWith(code)&&p.Code.Length==code.Length+4).ToList();
            }
            item.AppendLine(">");
            foreach (Model.WebNavigation model in data)
            {
                item.Append("<li><a id='" + model.EName + "' href=\"" + (string.IsNullOrEmpty(model.OutLink.Trim()) ? "/" + model.EName : model.OutLink) + "\"" + model.Target + ">" +

                    (
                    model.Pic.Trim()==""? 
                    model.Name://使用文本方式
                    "<img src=\""+model.Pic+"\" onmouseover=\"this.src='"+model.PicHover+"'\" onmouseout=\"this.src='"+model.Pic+"'\" />"//使用图片方式
                    )+

                    "</a>");
                item.AppendLine(EachAll(model.Code, AllData, ClassName).ToString());
                item.AppendLine("</li>");
            }
            item.AppendLine("</ul>");
            if (data.Count == 0)
                return new StringBuilder();
            return item;
        }

    }
}
