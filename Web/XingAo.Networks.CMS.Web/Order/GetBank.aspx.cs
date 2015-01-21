using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace XingAo.Networks.CMS.Web.Order
{
    public partial class GetBank : System.Web.UI.Page
    {
        /// <summary>
        /// 支付方式处理页面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //假设支付成功，转向处理结果页面
            Response.Redirect("PayCallBack.aspx?OrderID=" + Request.QueryString["OrderID"] + "&UsePoint=" + Request.QueryString["UsePoint"]);

        }
    }
}