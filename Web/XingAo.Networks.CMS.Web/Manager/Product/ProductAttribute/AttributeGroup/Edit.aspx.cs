using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XingAo.Core;
using XingAo.Core.Data;

namespace XingAo.Networks.CMS.Web.Manager.Product.ProductAttribute.AttributeGroup
{
    /// <summary>
    /// 属性分组或称之为属性模板操作页 到时商品编辑页需要什么样的动态属性，就从此组的id里取到具体的动态属性
    /// </summary>
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
                    Model.Product_AttributeGroup model = new UnitOfWork().FindSigne<Model.Product_AttributeGroup>(p => p.ID == id);
                    if (model != null && model.ID > 0)
                    {
                        txtDescriptions.Text = model.Descriptions;
                        txtGroupName.Text = model.GroupName;
                    }
                    else
                        JUIJsonResult.Err("数据不存在！", "");
                }
            }
        }
    }
}