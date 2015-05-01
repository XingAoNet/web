using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace XingAo.Core.Web.WebRouteEx
{
    /// <summary>
    /// 扩展UrlHelper,以实现获取不同站点的资源信息
    /// </summary>
    public static class DomainUrlHelper
    {
        public static MvcHtmlString DomainContent(this UrlHelper urlHelper, string contentPath, string domain)
        {
            string _domain = domain.ToLower();
            string _contentPath = contentPath.ToLower();

            if (String.IsNullOrEmpty(contentPath))
                throw new ArgumentException("contentPath is Null");

            if (_contentPath.StartsWith("~/"))
                _contentPath = _contentPath.Replace("~", "");

            if (string.IsNullOrEmpty(_domain) || _domain == "")
                return MvcHtmlString.Create(_contentPath);
            if (!_domain.EndsWith("/"))
                _domain = string.Format("{0}/",_domain) ;
            if (_domain.StartsWith("http://") || _domain.StartsWith("https://"))
                return MvcHtmlString.Create(string.Format("{0}{1}", _domain, _contentPath));
            else
                return MvcHtmlString.Create(string.Format("http://{0}{1}", _domain, _contentPath));
            
        }
    }
}
