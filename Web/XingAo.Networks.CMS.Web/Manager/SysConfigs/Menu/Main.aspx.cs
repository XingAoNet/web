using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XingAo.Core;
using System.Linq.Expressions;
using XingAo.Core.Data;

namespace XingAo.Networks.CMS.Web.Manager.SysConfigs.Menu
{
    public partial class Main : Common.BaseListPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var mywhere = QueryBuilder.Create<Model.SystemMenu>()
                 .Like(c => c.NavName, keyString);
                if (!string.IsNullOrEmpty(keyString))
                    Rep_List.DataSource = new UnitOfWork().FindBySpecification<Model.SystemMenu>(mywhere.Expression).ToList();
                else
                    Rep_List.DataSource = DbMenu.GetDb(new UnitOfWork().FindBySpecification<Model.SystemMenu>(mywhere.Expression).ToList());
                Rep_List.DataBind();
            }
        }

    }

    public class DbMenu
    {

        public static List<Model.SystemMenu> GetDb()
        {
            UnitOfWork uk = new UnitOfWork();
            return GetDb(uk.FindAll<Model.SystemMenu>().ToList());
        }

        public static List<Model.SystemMenu> GetDb(List<Model.SystemMenu> souce)
        {
            List<Model.SystemMenu> list = new List<Model.SystemMenu>();
            OrderRecursion(souce, list, "", 0);
            return list;
        }


        private static void OrderRecursion(List<Model.SystemMenu> list, List<Model.SystemMenu> containlist, string pMenuID, int deep)
        {
            var l = list.Where(c => c.ParentMenuID == pMenuID);
            if (l.Count() == 0) return;
            foreach (var menu in l.OrderBy(c => c.OrderNum))
            {
                menu.Deep = deep;
                containlist.Add(menu);
                OrderRecursion(list, containlist, menu.MenuID, ++deep);
                deep--;
            }
        }
    }
   
}