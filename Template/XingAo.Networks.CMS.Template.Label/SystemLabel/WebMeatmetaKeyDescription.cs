using System.Text;
using XingAo.Networks.CMS.Template.Label.LabelFunctions;
using XingAo.Core;
using XingAo.Core.Data;

namespace XingAo.Networks.CMS.Template.Label.SystemLabel
{
    /// <summary>
    /// 网站关键字与描述 标签
    /// </summary>
    public class WebMeatmetaKeyDescription
    {
        /// <summary>
        /// 生成《meta name=\"keywords\" content=\"{0}\" /》《meta name=\"description\" content=\"{1}\" /》
        /// </summary>
        /// <returns></returns>
        public static string GetHtml()
        {
            StringBuilder html = new StringBuilder("<meta name=\"keywords\" content=\"{0}\" />\n");
            html.AppendLine("<meta name=\"description\" content=\"{1}\" />");
            GetRouteData rd = new GetRouteData();
            int ClassID = WebNavigationConvert.GetIDByEName(rd.GetClassName());
            if (ClassID<= 0)
                ClassID=1;
            UnitOfWork uk = new UnitOfWork();
            Model.WebNavigation model = uk.FindSigne<Model.WebNavigation>(p => p.ID == ClassID);
            Model.SiteConfig siteConfigModel = new Model.SiteConfig();
             if(model!=null&&model.ID>0)
             {
                 return string.Format(html.ToString(), siteConfigModel.SiteName + "," + model.SearchEngineKeyWords, siteConfigModel.SiteName + "," + model.SearchEngineDescription + ",Powered by www.Xing-ao.net");
             }
             else

                 return "";
        }
    }
}
