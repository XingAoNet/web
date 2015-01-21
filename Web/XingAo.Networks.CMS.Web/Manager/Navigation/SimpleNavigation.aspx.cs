using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XingAo.Core;
using System.Text;
using XingAo.Core.Data;

namespace XingAo.Networks.CMS.Web.Manager.Navigation
{
    public partial class SimpleNavigation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UnitOfWork uk = new UnitOfWork();
            if (Request.Form["JsonOnly"].ObjToInt() == 1)
            {
                p1.Visible = false;
                int ID = Request.Form["ID"].ObjToInt();
                if (ID > 0)
                {
                   
                    try
                    {
                        Response.Write(uk.FindSigne<Model.WebNavigation>(p => p.ID == ID).Name);
                    }
                    catch { }
                }
                else
                    Response.Write("");
            }
            else
            {
                Model.ManagerUserCookiesModel loginuser=CookiesHelp.GetUsersCookies<Model.ManagerUserCookiesModel>();
                List<Model.WebNavigation> data = uk.LoadWhereLambda<Model.WebNavigation>(p => true, p => p.OrderBy(c => c.Code), 1, 9999).ToList();
                data = data.Where(p => loginuser.NavIDList.Split(',').Contains(p.ID.ToString())).ToList();
                    List.Text = DrawHtml(data, "").ToString();

               


            }
        }

        private StringBuilder DrawHtml(List<Model.WebNavigation> list, string Code)
        {
            IEnumerable<Model.WebNavigation> eachData;
            StringBuilder html = new StringBuilder();
            if (Code == "")
            {
                html.AppendLine("<ul class=\"tree expand\">");
                eachData = list.Where(p => p.Code.Length == 4).OrderBy(p => p.Code);
            }
            else
            {
                html.AppendLine("<ul>");
                eachData = list.Where(p => p.Code.StartsWith(Code) && p.Code.Length == Code.Length + 4).OrderBy(p => p.Code);
            }
            if(eachData.Count()==0)
                return new StringBuilder("");
            foreach (Model.WebNavigation Navigation in eachData)
            {
                StringBuilder Child = DrawHtml(list, Navigation.Code);
                if (Child.Length > 10)
                {
                    html.AppendLine("<li><a href=\"javascript:\">" + Navigation.Name + "</a>");
                    html.AppendLine(Child.ToString());
                    html.AppendLine("</li>");
                }
                else
                {
                    html.AppendLine("<li><a href=\"javascript:\" onclick=\"$.CallBackSetFormValue(['" + Navigation.ID.ToString() + "','" + Navigation.Name + "'])\">" + Navigation.Name + "</a></li>");
                }

                
            }
            html.AppendLine("</ul>");
            return html;
        }
    }
}
