using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XingAo.Core;
using XingAo.Core.Data;

namespace XingAo.Networks.CMS.Web.Manager.Common//----------修改命名空间
{
    /// <summary>
    /// DelPic 的摘要说明
    /// </summary>
    public class DelPic : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {        
        public void ProcessRequest(HttpContext context)
        {
          Model.ManagerUserCookiesModel loginUser=  CookiesHelp.GetUsersCookies<Model.ManagerUserCookiesModel>();
          if (loginUser != null && loginUser.UserID > 0)
          {
              string url = context.Request.Form["url"];
              bool _isCompel = false;//判断是否强制删除图片还是只是删除图片引用
              if (url.ToLower().StartsWith("/upload/image"))
              {
                  try
                  {
                      FileOption.DelFile(context.Request.Form["url"]);
                      JUIJsonResult.Success("删除图片成功", "", "#");
                  }
                  catch (Exception ex)
                  {
                      JUIJsonResult.Err(ex.Message, "");
                  }
              }
              else
                  JUIJsonResult.Err("只允许删除上传的图片，请不要尝试删除其它类型的文件！","");
          }
          else
              JUIJsonResult.Err("用户未登录或登录已失败！","");

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