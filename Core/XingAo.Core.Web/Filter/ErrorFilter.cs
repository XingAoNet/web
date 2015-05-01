using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web;

namespace XingAo.Core.Web.Filter
{
    /// <summary>
    /// 错误日志（Controller发生异常时会执行这里）
    /// </summary>
    public class ErrorFilter : ActionFilterAttribute, IExceptionFilter 
    {
        public void OnException(ExceptionContext filterContext)
        {
            //获取异常信息，入库保存 
            Exception Error = filterContext.Exception;
            string Message = Error.Message;//错误信息 
            string Url = HttpContext.Current.Request.RawUrl;//错误发生地址 
            filterContext.ExceptionHandled = true;
            filterContext.Result = new RedirectResult("/Error/Show/");//跳转至错误提示页面 
        } 
    }
}
