using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XingAo.Core;
using XingAo.Networks.CMS.Model;
using System.Data;
using System.Text;
using System.Text.RegularExpressions;
using XingAo.Core.Data;

namespace XingAo.Networks.CMS.Web.Manager.Custom
{
    public partial class Main : Common.BaseListPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string where = "1=1";
                Model.ManagerUserCookiesModel loginuser = CookiesHelp.GetUsersCookies<Model.ManagerUserCookiesModel>();

                int TID = Request.QueryString["TID"].ObjToInt(0);
                int r = 0;
                UnitOfWork uk = new UnitOfWork();
                List<Model.CustomTableField> dataAll = uk.LoadWhereLambda<Model.CustomTableField>
                    (p => p.TID == TID && (p.ShowList == 1 || p.ShowInSearch == 1), p => p.OrderBy(c => c.ShowListIndex)
                    , 1, 9999, out r).ToList();//取列表与搜索配置信息

                if (dataAll.Where(p => p.FieldName.ToLower() == "classid").Count() > 0)
                {
                    where += " and ClassID in(" + loginuser.NavIDList.TrimStart(',') + "0)";
                }

                #region 搜索表单项
                List<Model.CustomTableField> SearchFormData = dataAll.Where(p => p.ShowInSearch == 1).OrderByDescending(p => p.ShowListIndex).ThenByDescending(p => p.ID).ToList();
                StringBuilder search = new StringBuilder("");
                StringBuilder searchHidden = new StringBuilder("");
                foreach (Model.CustomTableField model in SearchFormData)
                {
                    if (model.ShowInSearch != 2)
                    {
                        Model.SearchFormControl fc = model.ShowInSearchJson.JsonToObject<Model.SearchFormControl>();
                        if (fc != null)
                        {
                            string value = Request["Search_" + fc.FieldName].ObjToStr();
                            if (value != "")
                            {
                                where+=" and "+fc.FieldName+" "+(fc.SeachOpt.IndexOf("{0}")>0?string.Format(fc.SeachOpt,value):fc.SeachOpt+value);
                            }
                            //search.AppendLine("<tr>");
                            search.AppendLine("<td>");
                            search.Append(fc.BeforControlText + "：");
                            if (fc.ControlType == 1)
                            {
                                search.Append("<input type=\"text\" name=\"Search_" + fc.FieldName + "\" value=\"" + Request["Search_" + fc.FieldName].ObjToStr() + "\" />");
                            }
                            else
                            {
                                search.AppendLine("<select type=\"text\" name=\"Search_" + fc.FieldName + "\">");
                                string[] ItemsConfig = fc.DataBindTableTxtFieldValue.Split('^');//表名|绑定值|绑定文本^自定义绑定文本|自定义值
                                string[] tableAndField = (ItemsConfig[0] == "" ? "||||" : ItemsConfig[0]).Split('|');//表名|绑定值|绑定文本
                                string[] CustomItem = ItemsConfig[1].Split('|');//自定义绑定文本|自定义值
                                for (int i = 0; i < CustomItem.Length; i += 2)
                                {
                                    search.AppendLine("<option value=\"" + CustomItem[i+1] + "\"" + (CustomItem[i+1] == value ? " selected" : "") + ">" + CustomItem[i] + "</option>");
                                }
                                if (tableAndField[0] != "" && tableAndField[1] != "" && tableAndField[2] != "")
                                {
                                    DataTable dt = uk.ExecSql("select " + tableAndField[1] + "," + tableAndField[2] + " from " + tableAndField[0] + " where id in(" + loginuser.NavIDList.TrimStart(',') + "0)", null).Tables[0];
                                    foreach (DataRow dr in dt.Rows)
                                    {
                                        search.AppendLine("<option value=\"" + dr[0].ToString() + "\"" + (dr[0].ToString() == value ? " selected" : "") + ">" + dr[1].ToString() + "</option>");
                                    }
                                }
                                search.AppendLine("</select>");
                            }
                            searchHidden.AppendLine("<input type=\"hidden\" name=\"Search_" + fc.FieldName + "\" value=\"" + value + "\" />");
                            search.AppendLine("</td>");
                            //search.AppendLine("</tr>");
                        }
                    }
                }
                SearchPageFormControl.Text = searchHidden.ToString();
                SearchFormControl.Text = search.ToString();
                #endregion


                #region    列表
                List<Model.CustomTableField> data = dataAll.Where(p => p.ShowList == 1).ToList();

                string Fields = "";
                StringBuilder tabHead = new StringBuilder();
                tabHead.AppendLine("<table class=\"table\" width=\"100%\" layoutH=\"138\">");
                tabHead.AppendLine("<thead>");
                tabHead.AppendLine("<tr>");
                tabHead.AppendLine("<th width=\"22\"><input type=\"checkbox\" group=\"ids\" class=\"checkboxCtrl\"></th>");

                StringBuilder tabDataItemTempLate = new StringBuilder();
                foreach (CustomTableField f in data)
                {
                    Model.ListFormControl list = f.ShowListParJson.JsonToObject<Model.ListFormControl>();
                    tabHead.Append("<th");
                    if (!string.IsNullOrEmpty(list.Align))
                        tabHead.Append(" align=\"" + list.Align + "\"");
                    if (!string.IsNullOrEmpty(list.TitleWidth))
                        tabHead.Append(" width=\"" + list.TitleWidth + "\"");
                    tabHead.AppendLine(">" + list.DisplayTitleText + "</th>");
                    Fields += f.FieldName + ",";
                }
                tabHead.AppendLine("</tr>");
                tabHead.AppendLine("</thead>");
                Fields = Fields + "ID";

                Model.CustomTable customTable = uk.FindSigne<Model.CustomTable>(p => p.ID == TID);
                string TableName = string.Empty;
                //if (customTable != null)
                    TableName = uk.FindSigne<Model.CustomTable>(p => p.ID == TID).TabName;

                Dictionary<string, object> par = new Dictionary<string, object>();
                par.Add("TableName", TableName);
                par.Add("Fields", Fields);
                par.Add("Where", where);
                par.Add("OrderBy", "");
                par.Add("PageSize", PageSize);
                par.Add("CurrentPage", PageNum);
                //@TableName nvarchar(99),--表名
                //@Fields nvarchar(1000),--字段集,如果为空则取所有字段,每个字段用,间隔
                //@Where nvarchar(999),--条件,不加where 如果为空则不设置条件
                //@OrderBy nvarchar(99),--排序字符,不要写order by,如果为空则默认以id倒序排序
                //@PageSize int,
                //@CurrentPage int--从1开始
                DataSet ds = uk.ExecDataSetByPro("Pro_GetRecordByPage", par);



                if (ds.Tables[0].Rows.Count == 0)
                {
                    // OptionResultJson.Err("数据不存在！", "");
                    TotalCount = 0;
                    DataTabLe.Text = tabHead.AppendLine("<tbody></tbody>\n</table>").ToString();
                }
                else
                {
                    TotalCount = ds.Tables[1].Rows[0][0].ObjToInt();//绑定前必须给总记录数赋值                    
                    StringBuilder RowItem = new StringBuilder("<tbody>\n");
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        RowItem.AppendLine("<tr target=\"sid\" rel=\"" + row["ID"].ToString() + "\">");
                        RowItem.AppendLine("<td><input name=\"ids\" value=\"" + row["ID"].ToString() + "\" type=\"checkbox\"></td>");
                        #region 循环列
                        foreach (CustomTableField f in data)
                        {
                            Model.ListFormControl list = f.ShowListParJson.JsonToObject<Model.ListFormControl>();
                            RowItem.Append("<td");
                            if (!string.IsNullOrEmpty(list.DataItemAlign))
                                RowItem.Append(" align=\"" + list.DataItemAlign + "\"");
                            RowItem.Append(">");

                            string itemValue = "";

                            if (!string.IsNullOrEmpty(list.DisplayValue))
                            {
                                string[] smExp = (list.DisplayValue + "==??::").Split('=')[2].Replace("\"", "").Split('?');
                                string[] smValue = smExp[1].Split(':');
                                itemValue = (row[list.FieldName].ObjToStr() == smExp[0] ? smValue[0] : smValue[1]);
                            }
                            else
                            {
                                itemValue = row[list.FieldName].ObjToStr();
                            }
                            if (!string.IsNullOrEmpty(list.Format))
                            {
                                itemValue = row[list.FieldName].ObjToStr(list.Format);
                            }
                            if (!string.IsNullOrEmpty(list.HrefLink))
                            {
                                foreach (Match m in Regex.Matches(list.HrefLink, "{(\\w|\\d)+}"))
                                {
                                    if (m.Value.ToLower().IndexOf("req_") > 0)
                                        list.HrefLink = list.HrefLink.Replace(m.Value, Request.QueryString[m.Value.Split('_')[1].Replace("{", "").Replace("}", "")]);
                                    else if (m.Value.ToLower() == "{dir}")
                                    {
                                        list.HrefLink = list.HrefLink.Replace(m.Value, Request.GetPath());
                                    }
                                    else
                                    {
                                        if (m.Value != "{0}")
                                            list.HrefLink = list.HrefLink.Replace(m.Value, row[m.Value.Replace("{", "").Replace("}", "")].ObjToStr());
                                        else
                                            list.HrefLink = list.HrefLink.Replace("{0}", itemValue);
                                    }
                                }
                                itemValue = list.HrefLink;
                            }
                            RowItem.AppendLine(itemValue + "</td>");
                        }
                        #endregion
                        RowItem.AppendLine("</tr>");
                    }
                    DataTabLe.Text = tabHead.AppendLine(RowItem + "</tbody>\n</table>").ToString();
                }
                #endregion

                
            }
        }
    }
}
