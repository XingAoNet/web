using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XingAo.Core;
using XingAo.Core.Data;
using XingAo.Networks.CMS.Model.DatabaseModel;
using XingAo.Networks.CMS.Web.Common;

namespace XingAo.Networks.CMS.Web.Manager.Wechat.ImageMaterial
{
    public partial class Edit : Common.BaseEditPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MaterialFamily.Edit.mflists(txtParentID, "");
                int id = Request.QueryString["id"].ObjToInt();
                if (id > 0)
                {
                    txtID.Value = id.ToString();
                    Model.ImageMaterial model = new UnitOfWork().FindSigne<Model.ImageMaterial>(p => p.ID == id && p.WGuid == "");
                    if (model != null && model.ID > 0)
                    {
                        txtKeys.Text = model.Keys;
                        txtKeyType.Text = model.KeyType.ToString();
                        txtOrderID.Text = model.OrderID.ToString();
                        txtTitle.Text = model.Title;
                        txtHeader.Text = model.PictuerAdress;
                        txtAbstract.Text = model.Abstract;
                        txtUrl.Text = model.Url;
                        txtParentID.SelectedValue = model.ParentID.ToString();
                        IsShow.Text = model.IsShow.ToString();
                        txtDetailedContent.Text = model.DetailedContent;
                        txtThumbnailHeader.Text = model.Thumbnail;
                        txtWWGuid.Value = model.IMGuid;
                        IsShowTime.Text = model.IsShowTime.ToString();
                        CurrentUrl.Text = new Model.SiteConfig().SiteUrl + "/Mobile/Website/Info_Img.aspx?wxid=" + model.WGuid + "&id=" + id + "&title=" + model.Title;
                    }
                    else
                        JUIJsonResult.Err("数据不存在！", "");
                }
            }
        }

    }  
}