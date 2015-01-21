using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Linq.Expressions;
using XingAo.Core.Data;

namespace XingAo.Networks.CMS.Web.Manager.Wechat.CustomMenu
{
    public partial class Main : Common.BaseListPage
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Expression<Func<Model.CustomMenu, bool>> mywhere = a => a.WGuid == "1";
                var data = DbMenu.GetDb(new UnitOfWork().FindAll<Model.CustomMenu>().ToList());
                var datas = data.Select(c => new {c.Deep, CanUse=c.CanUse==1?"是":"否",c.IDateTime, c.Keys, c.OrderID, c.ID, c.Name }).ToList();
                Rep_List.DataSource = datas;
                Rep_List.DataBind();
            }
        }
    }

    public class DbMenu
    {
        public static List<Model.CustomMenu> GetDb(string wxid)
        {
            UnitOfWork uk = new UnitOfWork();
            return GetDb(uk.FindAll<Model.CustomMenu>().Where(c => c.WGuid == wxid).ToList());
        }

        public static List<Model.CustomMenu> GetDb(List<Model.CustomMenu> souce)
        {
            List<Model.CustomMenu> list = new List<Model.CustomMenu>();
            OrderRecursion(souce, list, 0, 0);
            return list;
        }

        private static void OrderRecursion(List<Model.CustomMenu> list, List<Model.CustomMenu> containlist, int pMenuID, int deep)
        {
            var l = list.Where(c => c.ParentID == pMenuID);
            if (l.Count() == 0) return;
            foreach (var menu in l.OrderBy(c => c.OrderID))
            {
                menu.Deep = deep;
                containlist.Add(menu);
                OrderRecursion(list, containlist, menu.ID, ++deep);
                deep--;
            }
        }

    }
}
