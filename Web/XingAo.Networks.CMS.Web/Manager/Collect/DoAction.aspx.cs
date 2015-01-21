using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XingAo.Core.Data;
using XingAo.Core;
using System.Text.RegularExpressions;
using System.Text;

namespace XingAo.Networks.CMS.Web.Manager.Collect
{
    public partial class DoAction : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
            }
        }

        private void Collect()
        {
            LIInfo.Text = "采集中";
            UnitOfWork uk = new UnitOfWork();
            int id = Request.QueryString["id"].ObjToInt();
            if (id > 0)
            {
                Model.Collect model = new UnitOfWork().FindSigne<Model.Collect>(p => p.Id == id);
                if (model != null && model.Id > 0)
                {
                    #region
                    WebClient webclient = new WebClient();
                    webclient.Encoding = Encoding.UTF8;
                    Uri uri = new Uri(model.Url);
                    string Html = webclient.GetHtml(model.Url);
                    List<string> urls = new List<string>();
                    //关键就是这个里面的这则表达式  
                    Regex reg = new Regex(@model.Expression);
                    MatchCollection match = reg.Matches(Html);

                    foreach (Match var in match)
                    {
                        if (var.Groups["content"].Value.IndexOf("http") == -1)
                        {
                            urls.Add("http://" + uri.Host + var.Groups["content"].Value);
                        }
                        else
                            urls.Add(var.Groups["content"].Value);
                    }
                    #endregion
                    if (!string.IsNullOrEmpty(model.InsertTable))
                    {
                        #region
                        Model.Collect_Pattern[] Patterns = model.Collect_Patterns.ToArray();
                        if (Patterns.Length > 0)
                        {
                            StringBuilder InsertField = new StringBuilder();
                            StringBuilder FieldParam = new StringBuilder();

                            foreach (Model.Collect_Pattern Pattern in Patterns)
                            {
                                InsertField.Append(Pattern.InsertField + ",");
                                FieldParam.Append("@" + Pattern.InsertField + ",");
                            }
                            int tbID = model.InsertTable.ObjToInt();
                            Model.CustomTable table = uk.FindSigne<Model.CustomTable>(c => c.ID == tbID);
                            if (table != null)
                            {
                                string sql = "insert into " + table.TabName + "(" + InsertField.ToString().Trim(',') + ") values(" + FieldParam.ToString().Trim(',') + ")";

                                #region
                                Dictionary<string, object> param = null;
                                foreach (string url in urls.Take(TextNum.Text.ObjToInt(10)))
                                {
                                    Html = webclient.GetHtml(url);
                                    string cms = new Regex(model.ContentExpression).Match(Html).Groups["content"].Value;
                                    if (!string.IsNullOrEmpty(cms))
                                    {
                                        param = new Dictionary<string, object>();
                                        Regex rg;
                                        foreach (Model.Collect_Pattern Pattern in Patterns)
                                        {
                                            if (!string.IsNullOrEmpty(Pattern.Expression))
                                            {
                                                rg = new Regex(Pattern.Expression);
                                                param.Add("@" + Pattern.InsertField, rg.Match(cms).Groups[Pattern.ParamName].Value);
                                            }
                                            else
                                            {
                                                param.Add("@" + Pattern.InsertField, Pattern.DefaultValue);
                                            }
                                        }
                                        uk.ExecuteNonQuery(sql, param);
                                    }
                                }
                                #endregion
                            }

                        }
                        #endregion
                    }
                    LIInfo.Text = "采集完成";
                }
                else
                    JUIJsonResult.Err("数据不存在！", "");
            }
        }

        protected void CollectBtn_Click(object sender, EventArgs e)
        {
            Collect();
        }
    }
}