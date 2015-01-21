using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XingAo.Core;
using XingAo.Core.Data;

namespace XingAo.Networks.CMS.Web.Manager.Product.Product
{
    public partial class EditForm :Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int id = Request.QueryString["TempLateID"].ObjToInt();
                if (id > 0)
                {
                    Model.Product_AttributeGroup group = new UnitOfWork().FindSigne<Model.Product_AttributeGroup>(p=>p.ID==id);
                    if (group != null)
                    {
                        foreach (var attr in group.Product_AttributeList.OrderByDescending(p => p.OrderNum).ThenByDescending(p => p.ID))
                        {
                           Response.Write( attr.ControlResendJson.JsonToObject<Model.EditFormControl>().ToString());
                        }
                    }
                }
            }
        }
    }
}