using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XingAo.Core;
using XingAo.Core.Data;
using XingAo.Networks.CMS.Model.DatabaseModel;

namespace XingAo.Networks.CMS.Web.Manager.Wechat.TextMaterial
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
                    Model.TextMaterial model = new UnitOfWork().FindSigne<Model.TextMaterial>(p => p.ID == id && p.WGuid == "");
                    if (model != null && model.ID > 0)
                    {
                        KeyValue.Text = model.Keys;
                        KeyType.Text = model.KeyType.ToString();
                        txtReplyContent.Text = model.ReplyContent;
                        txtTGuid.Value = model.TGuid;
                    }
                    else
                        JUIJsonResult.Err("数据不存在！", "");
                }
            }
        }
    }
}