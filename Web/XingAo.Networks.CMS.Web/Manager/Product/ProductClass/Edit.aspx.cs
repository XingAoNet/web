using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XingAo.Core;
using XingAo.Core.Data;

namespace XingAo.Networks.CMS.Web.Manager.Product.ProductClass
{
    public partial class Edit : Common.BaseEditPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UnitOfWork uk = new UnitOfWork();
                #region 绑定所属栏目

                txtPID.Items.Add(new ListItem("--请选择--", ""));
                txtPID.Items.Add(new ListItem("顶级栏目", "0"));
                foreach (Model.Product_Class item in uk.LoadWhereLambda<Model.Product_Class>(p => true, p => p.OrderBy(c => c.ClassCode), 1, 9999))
                {
                    txtPID.Items.Add(new ListItem("|".PadRight(item.ClassCode.Length / 4 * 3, '-') + item.ClassName, item.ID.ToString()));
                }
                #endregion

                int id = Request.QueryString["id"].ObjToInt();
                if (id > 0)
                {
                    txtID.Value = id.ToString();
                    Model.Product_Class model =uk.FindSigne<Model.Product_Class>(p => p.ID == id);
                    if (model != null && model.ID > 0)
                    {
                        txtClassName.Text = model.ClassName;
                        txtDefaultPrice.Text = model.DefaultPrice.ToString();
                       // txtxxxx.Text = model.xxxx;
                        txtPID.SelectedValue = model.ClassCode.Length == 4 ? "0" : uk.FindByFunc<Model.Product_Class>(p => p.ClassCode == model.ClassCode.Substring(0, model.ClassCode.Length - 4)).FirstOrDefault().ID.ToString();
                    }
                    else
                        JUIJsonResult.Err("数据不存在！", "");
                }
            }
        }
    }
}