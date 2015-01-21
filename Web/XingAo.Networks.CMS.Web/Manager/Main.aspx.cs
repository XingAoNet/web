using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using XingAo.Core;
using XingAo.Core.Data;
using XingAo.Networks.CMS.Web.Manager.SysConfigs.Menu;
//using XingAo.Networks.CMS.Controller;
using System.Data.Objects.SqlClient;

namespace XingAo.Networks.CMS.Web.Manager
{
    public partial class Main : System.Web.UI.Page
    {
        List<Model.SystemMenu> M = new List<Model.SystemMenu>();
        protected void Page_Load(object sender, EventArgs e)
        {
            Model.ManagerUserCookiesModel loginUser = CookiesHelp.GetUsersCookies<Model.ManagerUserCookiesModel>();
            string UserInfo = "";
            if (loginUser == null || loginUser.UserID <= 0)
            {
                UserInfo += "<a href=\"javascript:;\"> <a href=\"login_dialog.aspx?r=1\" target=\"dialog\" max=false mask=true maxable=false minable=false resizable=false drawable=true width=\"370\" height=\"190\">登录</a></a>";
                UserName.Text = UserInfo.ToString();
                return;
            }
            else
            {
                UserInfo += "<a href=\"javascript:;\">" + loginUser.RealName + "</a>";
                UserInfo += "<ul><li>权限组：" + loginUser.UserType + "</li>";
                UserInfo += "<li>真实姓名：" + loginUser.RealName + "</li>";
                UserInfo += "<li>登录时间：" + loginUser.LoginTime + "</li>";
                UserInfo += "<li>登录次数：" + loginUser.LoginNum + " 次</li></ul>";
                UserName.Text = UserInfo;
            }
            if (!IsPostBack)
            {
                UnitOfWork uk = new UnitOfWork();

                Literal1.Text = "";//左侧子菜单
                string[] menuIds = loginUser.MenuIDList.ObjToStr().Split(',');// ManagerMenu.Select(c => c.MenuID).Distinct().ToArray();
               // var mywhere = QueryBuilder.Create<Model.SystemMenu>().In(c => c.Id, menuIds);                
                M = uk.FindByFunc<Model.SystemMenu>(p=>menuIds.Contains(p.Id.ToString())).ToList();
                StringBuilder menus = new StringBuilder();
                StringBuilder menus2 = new StringBuilder();//顶部主菜单
                string menuid = Request.QueryString["menuid"];//顶部菜单id
                int i = 0;
                string navname = "";//菜单名
                if (M.Where(c => c.MenuID == menuid).Count() > 0)
                    navname = M.Where(c => c.MenuID == menuid).FirstOrDefault().NavName;
                else
                {
                    if (M.Where(c => c.ParentMenuID == "").OrderBy(c => c.OrderNum).Count() > 0)//默认子菜单id，菜单名
                    {
                        navname = M.Where(c => c.ParentMenuID == "").OrderBy(c => c.OrderNum).FirstOrDefault().NavName;
                        menuid = M.Where(c => c.ParentMenuID == "").OrderBy(c => c.OrderNum).FirstOrDefault().MenuID;
                    }
                }
                foreach (var m in M.Where(c => c.ParentMenuID == "").OrderBy(c => c.OrderNum))//顶部主菜单组合
                {
                    if (m.MenuID == menuid)
                        menus2.AppendLine("<li class=\"menu selected\"");
                    else
                        menus2.AppendLine("<li class=\"menu\" ");
                    menus2.AppendLine("att=\"" + Request.Url.ToString().Split('?')[0] + "?menuid=" + m.MenuID + "\"><span>");
                    menus2.AppendLine(m.NavName + "</span></li>");
                    //if (i == 0)
                    //    menus.AppendLine("<div class=\"accordionHeader " + m.MenuID + "\">");
                    //else
                    //    menus.AppendLine("<div class=\" accordionHeader  " + m.MenuID + "\">");
                    //menus.AppendLine("	 <h2><span>Folder</span>" + m.NavName + "</h2>");
                    //menus.AppendLine("</div>");
                    //if (i == 0)
                    //    menus.AppendLine("<div class=\"accordionContent " + m.MenuID + "\">");                   
                    //else
                    //    menus.AppendLine("<div class=\" accordionContent " + m.MenuID + "\">");
                    //menus.AppendLine(OrderRecursion(M, m.MenuID, 1));
                    //menus.AppendLine("</div>"); 
                    i++;
                }
                //左侧显示子菜单
                menus.AppendLine("<div class=\"accordionHeader\">");
                menus.AppendLine("	 <h2><span>Folder</span>" + navname + "</h2>");
                menus.AppendLine("</div>");
                menus.AppendLine("<div class=\"accordionContent\">");
                menus.AppendLine(OrderRecursion(M, menuid, 1));
                menus.AppendLine("</div>");
                Literal1.Text = menus.ToString();
                Literal2.Text = menus2.ToString();
            }
        }

        private string GetMenu(string pMenuID, int deep, string navname)
        {
            UnitOfWork uk = new UnitOfWork();
            StringBuilder Lis = new StringBuilder();
            Lis.AppendLine("<div class=\"accordionHeader\">");
            Lis.AppendLine("	 <h2><span>Folder</span>" + navname + "</h2>");
            Lis.AppendLine("</div>");
            Lis.AppendLine("<div class=\"accordionContent\">");
            var l = M.Where(c => c.ParentMenuID == pMenuID && c.IsViewMenu == 1);
            if (l.Count() == 0) return Lis.ToString();
            Lis.AppendLine("<ul " + (deep == 1 ? "class=\"tree treeFolder expand\"" : "") + ">");
            foreach (var menu in l.OrderBy(c => c.OrderNum))
            {
                if (menu.Url == "#")
                    Lis.AppendLine("<li><a href=\"javascript:;\">" + menu.NavName + "</a>");
                else
                    Lis.AppendLine("<li><a href=\"" + (menu.Url.IndexOf("?") > 0 ? menu.Url.Replace("?", "?MenuID=" + menu.Id.ToString() + "&") : menu.Url + "?MenuID=" + menu.Id.ToString()) + "\" target=\"" + menu.Target + "\" rel=\"" + menu.Rel + "\">" + menu.NavName + "</a>");
                Lis.AppendLine(OrderRecursion(M, menu.MenuID, ++deep));
                Lis.AppendLine("</li>");
                deep--;
            }
            Lis.AppendLine("</ul>");
            Lis.AppendLine("</div>");
            return Lis.ToString();
        }

        private string  OrderRecursion(List<Model.SystemMenu> list, string pMenuID,int deep)
        {
            
            StringBuilder Lis = new StringBuilder();
            var l = list.Where(c => c.ParentMenuID == pMenuID && c.IsViewMenu==1);
            if (l.Count() == 0) return Lis.ToString();
            Lis.AppendLine("<ul " + (deep == 1 ? "class=\"tree treeFolder expand\"" : "") + ">");
            foreach (var menu in l.OrderBy(c => c.OrderNum))
            {
                if (menu.Url == "#")
                    Lis.AppendLine("<li><a href=\"javascript:;\">" + menu.NavName + "</a>");
                else
                {
                    if (menu.Url.Contains("http://") || menu.Url.Contains("https://"))
                        Lis.AppendLine("<li><a href=\"" + (menu.Url.IndexOf("?") > 0 ? menu.Url.Replace("?", "?MenuID=" + menu.Id.ToString() + "&") : menu.Url) + "\" target=\"" + menu.Target + "\" rel=\"" + menu.Rel + "\">" + menu.NavName + "</a>");
                    else
                        Lis.AppendLine("<li><a href=\"" + (menu.Url.IndexOf("?") > 0 ? menu.Url.Replace("?", "?MenuID=" + menu.Id.ToString() + "&") : menu.Url + "?MenuID=" + menu.Id.ToString()) + "\" target=\"" + menu.Target + "\" rel=\"" + menu.Rel + "\">" + menu.NavName + "</a>");
                }
                Lis.AppendLine(OrderRecursion(list, menu.MenuID, ++deep));
                Lis.AppendLine("</li>");
                deep--;
            }
            Lis.AppendLine("</ul>");
            return Lis.ToString();
        }
    }
}