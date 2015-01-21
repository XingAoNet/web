using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XingAo.Core;
using XingAo.Core.Data;

namespace XingAo.Networks.CMS.Web.Manager.Wechat.DefaultSettings
{
    public partial class Edit : Common.BaseEditPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Model.DefaultSettings model = new UnitOfWork().FindSigne<Model.DefaultSettings>(p => p.WGuid == "");
                if (model != null && model.ID > 0)
                {
                    txtTitle.Text = model.Title;
                    txtHeader.Text = model.PictuerAdress;
                    txtAbstract.Text = model.Abstract;
                    IsShow.Text = model.IsShow.ToString();
                    txtUrl.Text = model.Url;
                    txtContent.Text = model.DetailedContent;
                }
            }
        }
    }
}