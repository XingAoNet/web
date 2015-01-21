using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XingAo.Core;
using XingAo.Core.Data;

namespace XingAo.Networks.CMS.Web.Manager.Templates
{
    public partial class TemplateBakList : Common.BaseListPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();                       
            }
        }

        private void BindData()
        {
            Rep_List.DataSource = new UnitOfWork().FindAll<Model.TemplatesBak>().ToList();//new Impl.TemplatesBakRepository().GetList().ToList();
            Rep_List.DataBind();       
        }

        protected void Rep_List_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "LinkbtnDelete")
            {
               int delid= e.CommandArgument.ObjToInt();
               UnitOfWork db = new UnitOfWork();
                db.Remove<Model.TemplatesBak>(p=>p.ID==delid);
                db.Commit();
                //new Impl.TemplatesBakRepository().Delete(p => p.ID == delid);
               BindData();
            }
        }
    }
}