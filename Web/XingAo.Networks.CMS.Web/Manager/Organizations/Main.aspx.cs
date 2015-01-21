using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XingAo.Core;
using System.Linq.Expressions;
using XingAo.Core.Data;
//using XingAo.Networks.CMS.Controller;

namespace XingAo.Networks.CMS.Web.Manager.Organizations
{
    public partial class Main : Common.BaseListPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string ElectId = Request.QueryString["ElectId"];
                if (!string.IsNullOrEmpty(ElectId))
                {
                    List<Model.Organization> ors = new UnitOfWork().FindAll<Model.Organization>().Where(c => c.ElectId == ElectId).OrderBy(c => c.OrgCode).ToList();
                    if (ors.Count ==0)
                    {
                        Model.ManagerUserCookiesModel LogonUser = CookiesHelp.GetUsersCookies<Model.ManagerUserCookiesModel>();
                        int Year=DateTime.Now.Year-1;
                        UnitOfWork uk = new UnitOfWork();
                        ors = uk.FindAll<Model.Organization>().Where(c => c.IDateTime.Year == Year).OrderBy(c => c.OrgCode).ToList();
                        Model.Organization mode;
                        foreach (Model.Organization or in ors)
                        {
                            mode = new Model.Organization();
                            mode.ElectId = ElectId;
                            mode.IDateTime = DateTime.Now;
                            mode.Creater = LogonUser.RealName;
                            mode.OrgDescribe = or.OrgDescribe;
                            mode.OrgCode = or.OrgCode;
                            mode.OrgName = or.OrgName;
                            mode.EditTime = DateTime.Now;
                            mode.Editer = LogonUser.RealName;
                            uk.Insert(mode);
                        }
                        uk.Commit();
                    }
                    Rep_List.DataSource = ors;
                    Rep_List.DataBind();
                }
                else
                    JUIJsonResult.Err("参数错误！", "");
               
            }
        }
    }
}