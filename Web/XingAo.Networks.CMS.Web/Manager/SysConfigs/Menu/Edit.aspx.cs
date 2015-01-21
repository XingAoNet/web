using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XingAo.Core.Data;
using XingAo.Core;
using System.Collections.Specialized;
using XingAo.NetWorks.VerifyPermissions.Utility;

namespace XingAo.Networks.CMS.Web.Manager.SysConfigs.Menu
{
    /// <summary>
    /// 菜单编辑页
    /// </summary>
    public partial class Edit : Common.BaseEditPage
    {
        protected NameValueCollection keyvalue;

        protected string[] ModelOptions;
        /// <summary>
        /// load事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UnitOfWork uk = new UnitOfWork();
                var M =DbMenu.GetDb();
                foreach (var m in M)
                {
                    drParentMenu.Items.Add(new ListItem("".PadRight(m .Deep* 4, (char)0xA0) + "|--" + m.NavName, m.MenuID));
                }
                int id = Request.QueryString["id"].ObjToInt();
                if (id > 0)
                {
                    txtID.Value = id.ToString();
                    Model.SystemMenu model = uk.FindSigne<Model.SystemMenu>(p => p.Id == id);
                    if (model != null)
                    {
                        drParentMenu.SelectedValue = model.ParentMenuID;
                        PageType.SelectedValue = model.PageType.GetValueOrDefault().ToString();
                        IsViewMenu.Checked = model.IsViewMenu == 1;
                        txtName.Text = model.NavName;
                        txtEnglishName.Text = model.MenuID;
                        txtUrl.Text = model.Url;
                        txtRel.Text = model.Rel;
                        txtRel.ReadOnly = true;
                        txtOrder.Text = model.OrderNum.ToString();
                        txtTarget.SelectedValue = model.Target;
                        if (!string.IsNullOrEmpty(model.Operation))
                            ModelOptions = model.Operation.Split(',');
                    }
                    else
                        JUIJsonResult.Err("数据不存在！", "");
                }
                //绑定菜单权限
                ListOption.DataSource = keyvalue = Reflection.GetOperatingDescriptionValue();
                ListOption.DataBind();

            }
        }

        /// <summary>
        /// 返回操作项目
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string Option(string key)
        {
            return keyvalue[key];
        }

        public string CheckOption(string key)
        {
            if (ModelOptions == null) return "";
            return (ModelOptions.Where(c => c == key).Count() > 0) ? "checked" : "";
        }
    }
}