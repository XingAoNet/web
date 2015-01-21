using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XingAo.Core;
using XingAo.Core.Data;

namespace XingAo.Networks.CMS.Web.Manager.Common
{
    public class SessionHelper
    {
        private readonly static string ManagerMemberSession = "ManagerMember";
        private readonly static string ManagerMemberCookie = "Members";
        /// <summary>
        /// 会员信息
        /// </summary>
        public static Model.ManagerUserCookiesModel ManagerMember
        {
            get
            {
                if (HttpContext.Current.Session[ManagerMemberSession] == null)
                {
                    Model.ManagerUserCookiesModel loginUser = CookiesHelp.GetUsersCookies<Model.ManagerUserCookiesModel>(ManagerMemberCookie);
                    HttpContext.Current.Session[ManagerMemberSession] = loginUser;
                }
                return HttpContext.Current.Session[ManagerMemberSession] as Model.ManagerUserCookiesModel;
            }
        }

        public static void Logout()
        {
            DataCache.RemoveAllCache();
            HttpContext.Current.Session.RemoveAll();
            HttpContext.Current.Response.Cookies.Remove(ManagerMemberCookie);
            HttpContext.Current.Response.Cookies[ManagerMemberCookie].Expires = DateTime.Now.AddDays(-1);
        }

        /// <summary>
        /// 取菜单缓存
        /// </summary>
        /// <param name="WGuid"></param>
        /// <returns></returns>
        public static List<Model.MaterialFamily> GetMaterialFamilyByWGuid(string WGuid)
        {
            object cache = DataCache.GetCache(WGuid, DataCache.DataCacheType.WeChatMenu);
            if (cache == null)
            {
                UnitOfWork uk = new UnitOfWork();
                List<Model.MaterialFamily> MaterialFamilyList = new List<Model.MaterialFamily>();
                mflists(uk.FindAll<Model.MaterialFamily>().Where(c => c.WGuid == WGuid).ToList(), MaterialFamilyList, 0, 0);

                MaterialFamilyList.SetCache(WGuid, DataCache.DataCacheType.WeChatMenu);
                return MaterialFamilyList;
            }
            else
            {
                return (List<Model.MaterialFamily>)cache;
            }
        }


        private static void mflists(List<Model.MaterialFamily> dbList, List<Model.MaterialFamily> mfList, int pid, int deep)
        {
            foreach (Model.MaterialFamily mf in dbList.Where(c => c.ParentID == pid))
            {
                mf.Deep = deep;
                mfList.Add(mf);
                mflists(dbList,mfList, mf.ID, ++deep);
                deep--;
            }
        }

        /// <summary>
        /// 清空菜单缓存
        /// </summary>
        /// <param name="WGuid"></param>
        public static void RemoveMaterialFamilyByWGuid(string WGuid)
        {
            DataCache.RemoveCache(DataCache.DataCacheType.WeChatMenu);
        }

        /// <summary>
        /// 当前用户所属于微信账号
        /// </summary>
        /// <returns></returns>
        public static bool CheckCurUserWaChatAccount(string AccountGuid)
        {
            //string key = "CurUserWaChatAccount";
            //object WaChatAccount = DataCache.GetCache(key);
            //List<string> Accountids = null;
            //if (WaChatAccount == null)
            //{
            //    Accountids = new UnitOfWork().FindByFunc<Model.WeiXin_Account>(c => c.Id == 1).Select(c => c.WGuid).ToList();
            //    DataCache.SetCache(key, Accountids);
            //}
            //else
            //    Accountids = WaChatAccount as List<string>;
            //return Accountids.Contains(AccountGuid);
            return true;
        }


        public static string WxGuid()
        {
            //string _wxid = HttpContext.Current.Request.Params["wxid"];
            //if (string.IsNullOrEmpty(_wxid))
            //{
            //    HttpContext.Current.Response.Clear();
            //    HttpContext.Current.Response.Write("{\"statusCode\":\"300\",\"message\":\"参数错误\",\"navTabId\":\"\",\"rel\":\"\",\"callbackType\":\"closeCurrent\",\"forwardUrl\":\"\",\"confirmMsg\":\"\"}");
            //    HttpContext.Current.Response.End();
            //}
            //if (!SessionHelper.CheckCurUserWaChatAccount(_wxid))
            //{
            //    HttpContext.Current.Response.Clear();
            //    HttpContext.Current.Response.Write("{\"statusCode\":\"300\",\"message\":\"登录超时，请重新登录\",\"navTabId\":\"\",\"rel\":\"\",\"callbackType\":\"closeCurrent\",\"forwardUrl\":\"\",\"confirmMsg\":\"\"}");
            //    HttpContext.Current.Response.End();
            //}
            //return _wxid;
            return "";
        }
    }
}
