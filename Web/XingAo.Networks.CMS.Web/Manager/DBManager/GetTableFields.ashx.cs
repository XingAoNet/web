using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XingAo.Core.Data;
using XingAo.Core;
using System.Text;

namespace XingAo.Networks.CMS.Web.Manager.DBManager
{
    /// <summary>
    /// GetTableFields 的摘要说明
    /// </summary>
    public class GetTableFields : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext hc)
        {
            hc.Response.ContentType = "text/plain";
            int Tid = hc.Request.QueryString["TID"].ObjToInt(0);
            if (Tid>0)
            {
                UnitOfWork uk = new UnitOfWork();
                Model.CustomTableField[] models=uk.FindBySpecification<Model.CustomTableField>(c => c.TID == Tid).ToArray();
                StringBuilder data = new StringBuilder();
                
                foreach (Model.CustomTableField model in models)
                {
                    data.Append("{\"FiledName\":\"" + model.FieldName + "\"},");
                }
                hc.Response.Write("[" + data.ToString().Trim(',') + "]");
            }
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
