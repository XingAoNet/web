using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Xml.Xsl;
using XingAo.Core.Data;
using XingAo.Core;
using XingAo.Networks.CMS.Template.Label.CustomLable;

namespace XingAo.Networks.CMS.Web.Manager.LableDesign
{
    /// <summary>
    /// Rendering 的摘要说明
    /// </summary>
    public class Rendering : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext hc)
        {
            hc.Response.ContentType = "text/plain";
            string sql = hc.Request.Params["sql"].ToLower();
            string Template = hc.Request.Params["Template"];
            string param = hc.Request.Params["param"];
            int isPage = hc.Request.Params["IsPage"].ObjToInt(0);
            int PageSize = hc.Request.Params["PageSize"].ObjToInt(15);
            string Analyze = hc.Request.Params["Analyze"];
            if (!string.IsNullOrEmpty(param))
            {
                foreach (string pn in param.Split(','))
                {
                    string[] _p = pn.Trim('|').Split('|');
                    if (_p.Length == 4)
                    {
                        sql = sql.Replace(_p[1].ToLower(), _p[2]);
                        Template = Template.Replace(_p[1], _p[2]);
                    }
                }
            }
            hc.Response.Write(LabelRending.DbToHtm(sql, Template, isPage, PageSize, Analyze));
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
