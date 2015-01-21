using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XingAo.Core.Data;
using XingAo.Core;

namespace XingAo.Networks.CMS.Web.Mobile.Registration
{
    public partial class EnrollList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string AGuid = Request.Params["aguid"];
                List<Model.Registration> regisList = new UnitOfWork().FindAll<Model.Registration>().Where(c => c.AGuid == AGuid).ToList();

                string isLogin = "adminLogin";
                if (Session[isLogin] != null && Session[isLogin].ToString() == "success")
                {
                    var regisLists = regisList.Select(c => new { Telphone = c.Telphone, c.Name, IDateTime = c.IDateTime.ToShortDateString() });
                    RegList.DataSource = regisLists;
                    RegList.DataBind();
                }
                else
                {
                    var regisLists = regisList.Select(c => new { Telphone = StringOption.HiddenPhone(c.Telphone), c.Name, IDateTime = c.IDateTime.ToShortDateString() });
                    RegList.DataSource = regisLists;
                    RegList.DataBind();
                }
            }
        }
    }
}