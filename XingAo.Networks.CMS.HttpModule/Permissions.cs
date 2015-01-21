/*=================================
//  模块：HttpModule类，实现权限验证
//  创建者：Lu
//  创建时间：2013年11月5日 13:40:21
=================================*/
using System;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.SessionState;
using XingAo.Core;
//using XingAo.Networks.CMS.Controller;

namespace XingAo.Networks.CMS.HttpModule
{
    /// <summary>
    /// 权限验证HttpModule
    /// </summary>
    public class Permissions : IHttpModule, IRequiresSessionState 
    {
        public void Dispose()
        {

        }

        public void Init(HttpApplication context)
        {
            //context.BeginRequest += new EventHandler(context_BeginRequest);
            context.AcquireRequestState += new EventHandler(context_BeginRequest);
            //context.PreSendRequestContent += new EventHandler(context_BeginRequest);
        }
        void context_BeginRequest(object sender, EventArgs e)
        {          
            HttpApplication application = (HttpApplication)sender;//得到当前应用程序对象
            HttpContext context = application.Context; //得到当前请求的上下文
            string url = context.Request.Url.ToString(); //得到当前请求的假URL
            Regex reg = new Regex(@"(?<ManagerPath>\/manage(\w)+)(?<DirAndFile>(\/\w+)+(\.as)\w*)(?<Params>((\?|&)\w+=\w+)*)", RegexOptions.IgnoreCase); //创建正则对象，用来验证文件名是否满足条件
            if (reg.IsMatch(url))
            {
                Match match = reg.Match(url);
                string FileUrl = match.Groups["DirAndFile"].ToString().ToLower();//取目录名与文件名（不带参数） 
                #region 屏蔽验证(跳过验证)后台登录、登出页面
                if (FileUrl == "/main.aspx" || FileUrl.StartsWith("/login") || FileUrl.StartsWith("/logout"))
                {
                    return;
                }
                #endregion

                string par = match.Groups["Params"].ToString().Replace("?", "");//取文件后面的url参数
                Model.ManagerUserCookiesModel loginUser = CookiesHelp.GetUsersCookies<Model.ManagerUserCookiesModel>();
                if (loginUser == null || loginUser.UserID<=0)//验证用户登录状态
                {
                    context.Response.Clear();
                    context.Response.Write("{\"statusCode\":\"301\",\"message\":\"未登录或登录超时！\",\"navTabId\":\"\",	\"callbackType\":\"\",	\"forwardUrl\":\"\"}");
                }
                else
                {                    
                    int MenuID = context.Request.QueryString["MenuID"].ObjToInt();
                    if (MenuID == -1)//如果取不到MenuID则只验证其是否登录即可
                        return;
                    if (FileUrl.IndexOf("main.aspx") > 0)//列表页操作
                    {
                        string opt = "," + MenuID.ToString() + "_" + ((int)(XingAo.NetWorks.VerifyPermissions.Enum.Operating.List)).ToString() + ",";
                        if (loginUser.MenuIDList.IndexOf(opt) < 0)
                        {
                            context.Response.Clear();
                            context.Response.Write("{\"statusCode\":\"300\",\"message\":\"没有权限！\",\"navTabId\":\"\",	\"callbackType\":\"\",	\"forwardUrl\":\"\"}");
                            context.Response.End();
                        }
                    }
                    else if (FileUrl.IndexOf("edit.aspx") > 0)//新增或修改页
                    {
                        string opt = "," + MenuID.ToString() + "_" + ((int)(XingAo.NetWorks.VerifyPermissions.Enum.Operating.Add)).ToString() + ",";
                        if (!string.IsNullOrEmpty(context.Request.QueryString["ID"]))
                            opt = "," + MenuID.ToString() + "_" + ((int)(XingAo.NetWorks.VerifyPermissions.Enum.Operating.Edit)).ToString() + ",";
                        if (loginUser.MenuIDList.IndexOf(opt) < 0)
                        {
                            context.Response.Clear();
                            context.Response.Write("{\"statusCode\":\"300\",\"message\":\"没有权限！\",\"navTabId\":\"\",	\"callbackType\":\"\",	\"forwardUrl\":\"\"}");
                            context.Response.End();
                        }
                    }
                    else if (FileUrl.IndexOf("savedel.ashx") > 0)//新增或修改提交处理页
                    {
                        string opt = "," + MenuID.ToString() + "_" + ((int)(XingAo.NetWorks.VerifyPermissions.Enum.Operating.Add)).ToString() + ",";
                        if (string.IsNullOrEmpty(context.Request.QueryString["action"]))
                            opt = "," + MenuID.ToString() + "_" + ((int)(XingAo.NetWorks.VerifyPermissions.Enum.Operating.Del)).ToString() + ",";
                        else if (!string.IsNullOrEmpty(context.Request.Form["txtID"]))
                            opt = "," + MenuID.ToString() + "_" + ((int)(XingAo.NetWorks.VerifyPermissions.Enum.Operating.Edit)).ToString() + ",";
                        if (loginUser.MenuIDList.IndexOf(opt) < 0)
                        {
                            context.Response.Clear();
                            context.Response.Write("{\"statusCode\":\"300\",\"message\":\"没有权限！\",\"navTabId\":\"\",	\"callbackType\":\"\",	\"forwardUrl\":\"\"}");
                        }
                    }
                }
            }
        }
    }
}
