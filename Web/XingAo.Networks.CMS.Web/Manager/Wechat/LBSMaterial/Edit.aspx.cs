using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XingAo.Core;
using XingAo.Core.Data;
using XingAo.Networks.CMS.Model.DatabaseModel;

namespace XingAo.Networks.CMS.Web.Manager.Wechat.LBSMaterial
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
                    Model.LbsMaterial model = new UnitOfWork().FindSigne<Model.LbsMaterial>(p => p.ID == id && p.WGuid == "");
                    if (model != null && model.ID > 0)
                    {
                        txtTitle.Text = model.Title;
                        txtPictureAdrress.Text = model.PictureAdrress;
                        txtTelPhone.Text = model.TelPhone;
                        txtAbstract.Text = model.Abstract;

                        txtlat.Text = model.Latitude.ToString();
                        txtlng.Text = model.Longitude.ToString();
                        txtAddress.Text = model.Address;

                        IsShow.Text = model.IsShow.ToString();
                        txtDetailedContent.Text = model.DetailedContent;
                        txtURL.Text = model.URL;
                    }
                    else
                        JUIJsonResult.Err("数据不存在！", "");
                }
            }
        }
    }
}