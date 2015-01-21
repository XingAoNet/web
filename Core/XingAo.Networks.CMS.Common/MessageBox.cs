/******************************************************************
* Create By:卢小阳
* Create Time:2013/8/21 12:18:57
* Update By:
* Last Update Time:
* Update Description:
******************************************************************/
using System;
using System.Text;
namespace XingAo.Networks.CMS.Common
{
	/// <summary>
	/// 显示消息提示对话框。
	/// </summary>
	public class MessageBox
	{		
		private  MessageBox()
		{			
		}

		/// <summary>
		/// 显示消息提示对话框(alert,确定后不执行任何操作)
		/// </summary>
		/// <param name="page">当前页面指针，一般为this</param>
		/// <param name="msg">提示信息</param>
		public static void  Show(System.Web.UI.Page page,string msg)
		{            
            ShowAndRedirect(page, msg,null);
		}

		/// <summary>
		/// 控件点击 消息确认提示框
		/// </summary>
		/// <param name="page">当前页面指针，一般为this</param>
		/// <param name="msg">提示信息</param>
		public static void  ShowConfirm(System.Web.UI.WebControls.WebControl Control,string msg)
		{
			Control.Attributes.Add("onclick", "return confirm('" + msg + "');") ;
		}        
        /// <summary>
        /// 显示消息提示对话框，点击确定后退
        /// </summary>
        /// <param name="page">当前页面指针，一般为this</param>
        /// <param name="msg">提示信息</param>
        public static void ShowAndRedirect(System.Web.UI.Page page, string msg)
        {
            ShowAndRedirect(page, msg, "");
        }
		/// <summary>
		/// 显示消息提示对话框，并进行当前页面跳转
		/// </summary>
		/// <param name="page">当前页面指针，一般为this</param>
		/// <param name="msg">提示信息</param>
		/// <param name="url">跳转的目标URL，如果为空则后退,为null则不执行任何操作</param>
		public static void ShowAndRedirect(System.Web.UI.Page page,string msg,string url)
		{
            ShowAndRedirect(page, msg, url, RedirectTargetEnum.Self, "");

		}
        /// <summary>
        /// 显示消息提示对话框，并进行页面跳转
        /// </summary>
        /// <param name="page">当前页面指针，一般为this</param>
        /// <param name="msg">提示信息</param>
        /// <param name="url">跳转的目标URL,如果为空则后退,如果为null点击确定按钮后不执行任何js操作</param>
        /// <param name="target">跳转方式，详细参见RedirectTargetEnum此枚举</param>
        /// <param name="Framename">只有当target=RedirectTargetEnum.ParentFrameByName时有用，而且必须指定此名称</param>
        public static void ShowAndRedirect(System.Web.UI.Page page, string msg, string url,RedirectTargetEnum target,string Framename)
        {
            msg = msg.Replace("'", "＇").Replace("\"", "＂").Replace("\r\n", "").Replace("\r", "").Replace("\n", "");
            StringBuilder Builder = new StringBuilder();
            Builder.Append("<script language=\"javascript\">");
            Builder.AppendFormat("alert('{0}');", msg);
            if (url != null)
            {
                if (!string.IsNullOrEmpty(url))
                {
                    string WindowTarget = "";
                    switch (target)
                    {
                        case RedirectTargetEnum.ParentFrameByName:
                            WindowTarget = "self.parent.frames[\"" + Framename + "\"].src=\"" + url + "\"; ";
                            break;
                        case RedirectTargetEnum.Parent:
                            WindowTarget = "window.parent.location=\"" + url + "\"; ";
                            break;
                        case RedirectTargetEnum.ParentParent:
                            WindowTarget = "window.parent.parent.location=\"" + url + "\"; ";
                            break;
                        case RedirectTargetEnum.Self:
                            WindowTarget = "window.location=\"" + url + "\"; ";
                            break;
                        case RedirectTargetEnum.Top:
                            WindowTarget = "top.location=\"" + url + "\"; ";
                            break;
                    }
                    Builder.Append(WindowTarget);
                }
                else
                    Builder.Append("history.back();");
            }
            Builder.Append("</script>");
            page.ClientScript.RegisterStartupScript(page.GetType(),"message", Builder.ToString());

        }

		/// <summary>
		/// 输出自定义脚本信息
		/// </summary>
		/// <param name="page">当前页面指针，一般为this</param>
		/// <param name="script">输出脚本</param>
		public static void ResponseScript(System.Web.UI.Page page,string script)
		{
            page.ClientScript.RegisterStartupScript(page.GetType(), "message", "<script language=\"javascript\">" + script + "</script>");
             
		}
        /// <summary>
        /// js 对话框url重定向时，在哪个窗口上刷新  枚举
        /// </summary>
        public enum RedirectTargetEnum
        {
            /// <summary>
            /// 自身窗口
            /// </summary>
            Self,
            /// <summary>
            /// 父窗口
            /// </summary>
            Parent,
            /// <summary>
            /// Top
            /// </summary>
            Top,
            /// <summary>
            /// 某框架(只能从当前框架调用父级内的某一框架。即自身的兄弟框架)
            /// </summary>
            ParentFrameByName,
            /// <summary>
            /// 父窗口的父窗口
            /// </summary>
            ParentParent
        }

	}
}
