using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XingAo.Core;
using XingAo.Core.Data;

namespace XingAo.Networks.CMS.Web.Manager.Members.Groups
{
    public partial class Edit : Common.BaseEditPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               int id = Request.QueryString["id"].ObjToInt();
                if (id > 0)
                {
                    txtID.Value = id.ToString();
                    Model.MemberGroups model = new UnitOfWork().FindSigne<Model.MemberGroups>(p => p.Id == id);
                    if (model != null && model.Id > 0)
                    {
                        txtTGroupName.Text = model.GroupName;
                        txtDescription.Text = model.GroupDescribe;
                        txtOrder.Text = model.OrderNum.ToString();
                    }
                    else
                        JUIJsonResult.Err("数据不存在！", "");
                }
                
            }
        }
    }
}