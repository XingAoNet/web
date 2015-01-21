using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XingAo.Core;
using System.Linq.Expressions;
using XingAo.Core.Data;

namespace XingAo.Networks.CMS.Web.Manager.Members.Groups
{
    public partial class LookForMemberGroup : Common.BaseListPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.Form["JsonOnly"].ObjToInt() == 1)
                {
                    p1.Visible = false;
                    string GroupId = Request.Form["ID"];
                    if (!string.IsNullOrEmpty(GroupId))
                    {

                        try
                        {
                            Response.Write(new UnitOfWork().FindSigne<Model.MemberGroups>(p => p.GroupId == GroupId).GroupName);
                        }
                        catch { }
                    }
                    else
                        Response.Write("");
                }
                else
                {
                    Rep_List.DataSource = new UnitOfWork().FindAll<Model.MemberGroups>().OrderBy(c => c.Id).ToList();
                    Rep_List.DataBind();
                }
            }
        }
    }
}