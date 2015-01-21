using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XingAo.Core;
using XingAo.Core.Data;
using System.Text;
using XingAo.NetWorks.VerifyPermissions.Utility;
using System.Collections.Specialized;
using XingAo.NetWorks.VerifyPermissions.Enum;
//using XingAo.Networks.CMS.Controller;

namespace XingAo.Networks.CMS.Web.Manager.SysConfigs.ManagerUser.Groups
{
    public partial class Edit : Common.BaseEditPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
              UnitOfWork uk=  new UnitOfWork();
              IList<Model.SystemMenu> SideBar = uk.FindAll<Model.SystemMenu>().ToList();
                IList<Model.WebNavigation> All=uk.FindAll<Model.WebNavigation>().OrderBy(p=>p.Code).ToList();
              NameValueCollection optenum = Reflection.GetOperatingDescriptionValue();
              string sysmenuoptuserlimit = "", Navoptuserlimit="";

              Model.ManagerUserCookiesModel currentuser = CookiesHelp.GetUsersCookies<Model.ManagerUserCookiesModel>();              
                int id = Request.QueryString["id"].ObjToInt();
                if (id > 0)
                {
                    txtID.Value = id.ToString();
                    Model.ManagerUserGroup model = uk.FindSigne<Model.ManagerUserGroup>(p => p.ID == id);
                    if (model != null && model.ID > 0)
                    {
                        sysmenuoptuserlimit = ","+model.SystemMenu+",";
                        Navoptuserlimit =","+ model.Navigation+",";
                        txtGroupName.Text = model.GroupName;
                    }
                    else
                        JUIJsonResult.Err("数据不存在！", "");
                }

                SystemMenu.Text = BuilderSideBar(SideBar, optenum, "",","+currentuser.MenuIDList+",", sysmenuoptuserlimit, id).ToString();
                Navigation.Text = BuklderWebMenu(All, "", "," + currentuser.NavIDList + ",", Navoptuserlimit, id).ToString();
            }
        }
        /// <summary>
        /// 生成后台操作权限多选框
        /// </summary>
        /// <param name="SideBar">后台栏目全部数据</param>
        /// <param name="optenum">后台操作枚举</param>
        /// <param name="pid">父级id</param>
        /// <param name="CurrentLoginUserLimit">当前登录者所拥有的权限（意义在于：新建或修改用户时，不能大于当前登录者所带有的权限）</param>
        /// <param name="optuserlimit">当前被编辑用户原来所带的权限（新增时为空）</param>
        /// <param name="GroupId">用户组id，如果是1则拥有所有权限</param>
        /// <returns></returns>
        private StringBuilder BuilderSideBar(IList<Model.SystemMenu> SideBar, NameValueCollection optenum, string pid, string CurrentLoginUserLimit, string optuserlimit, int GroupId)
        {
            StringBuilder sb = new StringBuilder("<ul{0}>\n");
            if (pid == "")
                sb = sb.Replace("{0}", " id=\"SideBar\">全选:<input name=\"SideBarCheckAll\" type=\"checkbox\" id=\"SideBarCheckAll\" title=\"全选\"");
            else
                sb = sb.Replace("{0}", "");
            foreach (Model.SystemMenu m in SideBar.Where(p => p.ParentMenuID == pid))
            {
                sb.Append("<li>");
                if (m.Url == "")
                {
                    sb.Append("<input name=\"checkbox1\" type=\"checkbox\" id=\"checkbox_" + m.Id.ToString() + "\"  value=\"" + m.Id.ToString() + "\" title=\"" + m.NavName + "\"" + MakeDisable(CurrentLoginUserLimit, optuserlimit, "," + m.Id.ToString() + ",", GroupId) + " />" + m.NavName + "\n");

                }
                else
                {
                    sb.Append("<input name=\"checkbox1\" type=\"checkbox\" id=\"checkbox_" + m.Id.ToString() + "\"  value=\"" + m.Id.ToString() + "\" title=\"" + m.NavName + "\"" + MakeDisable(CurrentLoginUserLimit, optuserlimit, "," + m.Id.ToString() + ",", GroupId) + " />" + m.NavName + "\n<ul>\n<li>");
                    foreach (string s in (string.IsNullOrEmpty(m.Operation)?"":m.Operation).Split(','))
                    {
                        if (s != "")
                        {
                            Operating opt= XingAo.NetWorks.VerifyPermissions.Utility.IntToEnum.GetOperatingEnumFromInt(s.ObjToInt());
                            sb.Append("<input name=\"checkbox1\" type=\"checkbox\" id=\"checkbox_" + m.Id.ToString() + "_" + s + "\"  value=\"" + m.Id.ToString() + "_" + s + "\" title=\"" + optenum[s] + "\"" + MakeDisable(CurrentLoginUserLimit, optuserlimit, "," + m.Id.ToString() + "_" + s + ",", GroupId) + " />" + optenum[s]);
                        }
                    }                    
                    sb.Append("</li>\n</ul>\n");
                }
                sb.Append(BuilderSideBar(SideBar, optenum, m.MenuID, CurrentLoginUserLimit, optuserlimit, GroupId));
                sb.Append("</li>\n");
            }
            sb.Append("</ul>\n");
            return sb;
        }
        /// <summary>
        /// 创建是否可用且是否默认选中
        /// </summary>
        /// <param name="current"></param>
        /// <param name="opt"></param>
        /// <param name="v"></param>
        ///  <param name="GroupId">1为不限制权限</param>
        /// <returns></returns>
        private string MakeDisable(string current, string opt, string v, int GroupId)
        {
            if (current.IndexOf(v) > -1)
            {
                if (opt.IndexOf(v) > -1)
                    return " checked=\"checked\"";
                return "";
            }
            else
            {
                if (GroupId == 1)
                    return "";
                // return "";
                return "  disabled=\"disabled\"";
            }
        }
        /// <summary>
        /// 创建用户可操作的网站栏目
        /// </summary>
        /// <param name="All">网站栏目数据，除首页之外</param>
        /// <param name="code">栏目编码，顶级为空</param>
        /// <param name="CurrentLoginUserLimit">当前登录用户所拥有的  网站栏目   操作权限</param>
        /// <param name="optuserlimit">当前被修改的组   所拥有的权限</param>
        /// <param name="GroupId">用户组id，如果是1则拥有所有权限</param>
        /// <returns></returns>
        private StringBuilder BuklderWebMenu(IList<Model.WebNavigation> All, string code, string CurrentLoginUserLimit, string optuserlimit, int GroupId)
        {
            IEnumerable<Model.WebNavigation> li;
            if (code == "")
                li = All.Where(p => p.Code.Length == 4);
            else
                li = All.Where(p => p.Code.Length == code.Length + 4 && p.Code.StartsWith(code));
            StringBuilder sb = new StringBuilder();
            if (li.Count() > 0)
            {
                sb.Append("\n<ul>\n");
                if (code == "")
                    sb.Append("全选：<input name=\"WebMenuCheckAll\" type=\"checkbox\" id=\"WebMenuCheckAll\" title=\"全选\" />\n");
                foreach (Model.WebNavigation m in li)
                {
                    sb.Append("<li>");
                    sb.Append("<input name=\"checkbox2\" type=\"checkbox\" id=\"checkbox_" + m.ID.ToString() + "\" value=\"" + m.ID.ToString() + "\" title=\"" + m.Name + "\"" + MakeDisable(CurrentLoginUserLimit, optuserlimit, "," + m.ID.ToString() + ",", GroupId) + " />" + m.Name);
                    sb.Append(BuklderWebMenu(All, m.Code, CurrentLoginUserLimit, optuserlimit, GroupId));
                    sb.Append("</li>\n");
                }
                sb.Append("</ul>\n");
            }
            return sb;
        }
    }
}