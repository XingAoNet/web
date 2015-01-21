using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XingAo.Core;
using XingAo.Core.Data;

namespace XingAo.Networks.CMS.Web.Manager.Wechat.AutoReply
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
                   
                    Model.WeiXin_Reply model = new UnitOfWork().FindSigne<Model.WeiXin_Reply>(p => p.Id == id);
                    if (model != null && model.Id > 0)
                    {
                        txtID.Value = model.Id.ToString();
                        txtTitle.Text = model.Title;
                        txtReplyKey.Text = model.ReplyKey;
                        txtReplyContent.Text = model.ReplyContent;

                        txtDescription.Text = model.Description;
                        txtPicUrl.Text = model.PicUrl;
                        txtUrl.Text = model.Url;
                    }
                    else
                        JUIJsonResult.Err("数据不存在！", "");
                }
            }
        }
    }
}