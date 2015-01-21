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

namespace XingAo.Networks.CMS.Web.Manager.Wechat.Attention
{
    public partial class ImageEdit : Common.BaseEditPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MaterialFamily.Edit.mflists(txtParentID,"");
                Model.Attention model = new UnitOfWork().FindAll<Model.Attention>().Where(c => c.Type == 1 && c.WGuid == "").FirstOrDefault();
                if (model != null && model.ID > 0)
                {
                    txtID.Value = model.ID.ToString();
                    txtOrderID.Text = model.OrderID.ToString();
                    txtTitle.Text = model.Title;
                    txtHeader.Text = model.PictuerAdress;
                    txtAbstract.Text = model.Abstract;
                    txtParentID.Text = model.ParentID.ToString();
                    IsShow.Text = model.IsShow.ToString();
                    txtDetailedContent.Text = model.DetailedContent;
                    txtOtherURL.Text = model.OtherURL;
                }
            }
        }
    }
}