using System.Text;
using System.Web;
using XingAo.Core;
using XingAo.Core.Data;

namespace XingAo.Networks.CMS.TestDataShare.Method
{
    /// <summary>
    /// 取某方法的所有参数配置信息
    /// </summary>
    public class GetMethodPars : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            int id = context.Request.QueryString["id"].ObjToInt();
            if (id > 0)
            {
                var conf = new UnitOfWork().LoadWhereLambda<Model.DataShare_ParameterConfig>(p => p.DataShareID == id);
                StringBuilder sb = new StringBuilder();
                foreach (var c in conf)
                {
                    sb.AppendLine(c.ParameterName + "(" + (c.AllowEmpty == 1 ? "必备条件" : "可选条件【值为空时忽略此条件】") + "):" + c.Operators.Replace("{0}", "") + "<input type='text' id='" + c.ParameterName + "' name='" + c.ParameterName + "' />数据类型：" + c.DataType+"<hr />");
                }
                context.Response.Write(sb.ToString());
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