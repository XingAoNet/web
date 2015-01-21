using System.Collections.Generic;
using System.Linq;
using System.Text;
using XingAo.Networks.CMS.Template.Label.LabelFunctions;
using XingAo.Core;
using XingAo.Core.Data;

namespace XingAo.Networks.CMS.Template.Label.SystemLabel
{
    /// <summary>
    /// 网站位置导航（即：首页 > xxxx > ssss）
    /// </summary>
    public class LocationNavigation
    {
        public static string GetHtml()
        {
            GetRouteData rd = new GetRouteData();
            string ClassCode = WebNavigationConvert.GetCodeByEName(rd.GetClassName());
            if (ClassCode == "")
                return "";
            string FirstCode = ClassCode.Length > 4 ? ClassCode.Substring(0, 4) : ClassCode;
            StringBuilder html = new StringBuilder("<div class=\"SiteMap\">{0}</div>");
            if (DataCache.GetCache("WebLocationNavigation_" + ClassCode, DataCache.DataCacheType.Menu).ObjToStr() == "")
            {
                UnitOfWork uk = new UnitOfWork();
                int r = 0;
                List<Model.WebNavigation> data = uk.LoadWhereLambda<Model.WebNavigation>(p => p.Code.StartsWith(FirstCode), p => p.OrderBy(c => c.Code), 1, 99999, out r).ToList();
                html = new StringBuilder().AppendFormat(html.ToString(), EachAll(ClassCode, data));
                DataCache.SetCache("WebLocationNavigation_" + ClassCode, html, 99999, DataCache.DataCacheType.Menu);
            }
            else
                html = (StringBuilder)DataCache.GetCache("WebLocationNavigation_" + ClassCode, DataCache.DataCacheType.Menu);
            return html.ToString();
        }
        /// <summary>
        /// 递归所有父级，直到首页
        /// </summary>
        /// <param name="code"></param>
        /// <param name="AllData"></param>
        /// <returns></returns>
        private static StringBuilder EachAll(string code, List<Model.WebNavigation> AllData)
        {
            StringBuilder item = new StringBuilder("");
            if (code.Length >= 4)
            {
                Model.WebNavigation model = AllData.Single<Model.WebNavigation>(p => p.Code == code);
                if (model != null)
                {
                    item.Append("<a href=\"" + (string.IsNullOrEmpty(model.OutLink.Trim()) ? "/" + model.EName : model.OutLink) + "\"" + model.Target + ">" + model.Name + "</a>");
                    if (code.Length > 4)
                        item = EachAll(model.Code.Substring(0, model.Code.Length - 4), AllData).Append(" &gt; " + item);
                    else
                        item = new StringBuilder("<a href=\"/\">首页</a> &gt; ").Append(item);
                }
            }
            //else
            //    item.Append("<a href=\"/\">首页</a>");
            return item;
        }
    }
}
