using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XingAo.Core;
using XingAo.Core.Data;

namespace XingAo.Networks.CMS.Web.Manager.LableDesign.SysLable
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
                    Model.SysLabels model = new UnitOfWork().FindSigne<Model.SysLabels>(p => p.ID == id);
                    if (model != null && model.ID > 0)
                    {
                        txtLabelName.Text = model.LabelName;
                        txtMethod.Text = model.Method;
                        txtNameSpace.Text = model.NameSpace;
                        txtNameSpaceClass.Text = model.NameSpaceClass;
                        txtParameters.Text = model.Parameters;
                    }
                    else
                        JUIJsonResult.Err("数据不存在！", "");
                }
            }
        }
    }
}