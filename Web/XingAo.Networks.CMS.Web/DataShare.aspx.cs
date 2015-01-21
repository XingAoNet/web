using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XingAo.Core;
using XingAo.Core.Data;
using System.Data;

namespace XingAo.Networks.CMS.Web
{
    /// <summary>
    /// 数据开放接口
    /// </summary>
    public partial class DataShare : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetAllowResponseInBrowserHistory(false);
            string MethodName = RouteData.Values["MethodName"].ObjToStr();
            string Sign = Request["Sign"].ObjToStr();
            string TimeSpan = Request["TimeSpan"].ObjToStr();
            string AccessToken = Request.Form["AccessToken"].ObjToStr();
            string RedirectUrl = Request.Form["RedirectUrl"];//重定向url为空时直接向页面输出执行结果，否则把返回结果输出到url上
            if (!string.IsNullOrEmpty(MethodName.Trim()))
            {
                switch (MethodName.ToLower())
                {
                    case "getservertime":
                        Response.Write(DateTime.UtcNow.Ticks.ToString());
                        break;
                    default:
                        #region 调用其它方法时
                        Dictionary<string, object> par;
                        #region 验证时间与签名
                        double ts = (new TimeSpan(DateTime.UtcNow.Ticks).Subtract(new TimeSpan(long.Parse(TimeSpan)))).TotalMilliseconds;
                        if (ts > 5000 || ts <= 0)
                        {
                            Response.Clear();
                            ReSenderResult("Error:本地时间轴与服务器时间轴相差超过5秒，请求被拒绝！", RedirectUrl);
                            return;
                        }
                        else if (((MethodName.ToLower() + TimeSpan + AccessToken).ToMD5Two() != Sign))
                        {
                            Response.Clear();
                            ReSenderResult("Error:签名错误！", RedirectUrl);
                            return;
                        }
                        #endregion
                        switch (MethodName.ToLower())
                        {
                            case "gettoken"://此方法只允许post提交，不允许get
                                string username = Request.Form["UserName"].ObjToStr();
                                string key = Request.Form["Key"].ObjToStr();
                                par = new Dictionary<string, object>();
                                par.Add("UserName", username);
                                par.Add("Key", key);
                                par.Add("Source", Request.UserHostAddress);
                                Response.Clear();
                                ReSenderResult(new UnitOfWork().ExecuteScalar("Pro_GetDataShareAccessToken", par).ToString(), RedirectUrl);//存储过程直接返回json回来，如果用户名与key错误则返回空令牌并带有ErrMsg
                                break;
                            case "refreshtoken":
                                string RefreshToken = Request.Form["RefreshToken"];
                                string Source = Request.UserHostAddress;
                                par = new Dictionary<string, object>();
                                par.Add("AccessToken", AccessToken);
                                par.Add("RefreshToken", RefreshToken);
                                par.Add("Source", Source);
                                Response.Clear();
                                ReSenderResult(new UnitOfWork().ExecuteScalar("Pro_RefreshToken", par).ToString(), RedirectUrl);//存储过程直接返回json回来，如果用户名与key错误则返回空令牌并带有ErrMsg
                                break;
                            default:
                                #region 调用后台配置方法时
                                string userAccessToken = Request["AccessToken"].ObjToStr();
                                string RequestSource = Request.UserHostAddress;
                                UnitOfWork uk = new UnitOfWork();
                                Dictionary<string, object> par2 = new Dictionary<string, object>();
                                par2.Add("MethodName", MethodName);
                                par2.Add("RequestSource", Request.UserHostAddress);
                                par2.Add("AccessToken", userAccessToken);
                                par2.Add("ClientSendPars", Request.Params.ToJSON());
                                //@MethodName nvarchar(50),
                                //@RequestSource nvarchar(150),--当前请求远程客户端的 IP 主机地址
                                //@AccessToken nvarchar(50),
                                //@ClientSendPars varchar(8000)
                                DataSet ds = uk.ExecDataSetByPro("Pro_DataShareCallMethod", par2);
                                string errmesg = ds.Tables[0].Rows[0][0].ToString();
                                if (string.IsNullOrEmpty(errmesg))
                                {
                                    Model.DataShare model = new Model.DataShare(); //uk.FindSigne<Model.DataShare>(p => p.MethodName.ToLower() == MethodName.ToLower());
                                    DataRow dr = ds.Tables[1].Rows[0];
                                    model.Descriptions = dr["Descriptions"].ToString();
                                    model.Fields = dr["Fields"].ToString();
                                    model.ID = dr["ID"].ObjToInt();
                                    model.MethodName = dr["MethodName"].ToString();
                                    model.MethodType = dr["MethodType"].ObjToInt();
                                    model.OrderBy = dr["OrderBy"].ToString();
                                    model.Tables = dr["Tables"].ToString();
                                    model.WhereStr = dr["WhereStr"].ToString();
                                    if (model != null)
                                    {
                                        par = new Dictionary<string, object>();
                                        par.Add("TableName", model.Tables);//--表名
                                        par.Add("Fields", model.Fields);//--字段集,如果为空则取所有字段,每个字段用,间隔
                                        par.Add("Where", model.WhereStr);//--条件,不加where 如果为空则不设置条件
                                        par.Add("OrderBy", model.OrderBy);//--排序字符,不要写order by,如果为空则默认以id倒序排序
                                        par.Add("PageSize", Request.Form["PageSize"].ObjToInt(1));
                                        par.Add("CurrentPage", Request.Form["Page"].ObjToInt(1));//--从1开始 
                                        List<Model.DataShare_ParameterConfig> configs = new List<Model.DataShare_ParameterConfig>();// model.ParameterConfig.Where(p => Request.Form.AllKeys.Contains(p.ParameterName));
                                        foreach (DataRow dr2 in ds.Tables[2].Rows)
                                        {
                                            Model.DataShare_ParameterConfig m = new Model.DataShare_ParameterConfig();
                                            m.AllowEmpty = dr2["AllowEmpty"].ObjToInt();
                                            m.DataShareID = dr2["DataShareID"].ObjToInt();
                                            m.DataType = dr2["DataType"].ToString();
                                            m.FieldName = dr2["FieldName"].ToString();
                                            m.ID = dr2["ID"].ObjToInt();
                                            m.Operators = dr2["Operators"].ToString();
                                            m.ParameterName = dr2["ParameterName"].ToString();
                                            configs.Add(m);
                                        }
                                        string otherWhere = model.WhereStr.Trim();
                                        string[] AllAlowUpdateFields = model.Fields.Trim().Split(',');
                                        string sql = "";
                                        switch (model.MethodType)
                                        {
                                            case 1://列表
                                            case 2://单条数据
                                                #region
                                                if (configs.Count() > 0)
                                                    otherWhere = otherWhere == "" ? "" : otherWhere + " |AnD| ";
                                                foreach (Model.DataShare_ParameterConfig config in configs)
                                                {
                                                    string QueryValue = Request.Form[config.ParameterName].ObjToStr();
                                                    if (config.AllowEmpty == 1 || QueryValue != "")
                                                    {
                                                        otherWhere = otherWhere.Replace("|AnD|", "and");
                                                        if (config.DataType == "int")
                                                            QueryValue = QueryValue.ObjToInt().ToString();//强制转换以防注入
                                                        else if (config.DataType == "date")
                                                            QueryValue = QueryValue.ObjToStr("yyyy-MM-dd");
                                                        else if (config.DataType == "datetime")
                                                            QueryValue = QueryValue.ObjToStr("yyyy-MM-dd HH:mm:ss");
                                                        otherWhere += "[" + config.FieldName + "]" + string.Format(config.Operators, QueryValue) + " |AnD|";
                                                    }

                                                }
                                                otherWhere = otherWhere.Replace("|AnD|", "");
                                                par["Where"] = otherWhere;
                                                DataSet ds3 = uk.GetProDataSet("Pro_GetRecordByPage", par);
                                                ReSenderResult("{\"Data\":" + ds3.Tables[0].ToList().ToJSON() + ",\"Record\":" + ds.Tables[1].Rows[0][0].ObjToStr() + "}", RedirectUrl);
                                                // Response.Write("{\"Data\":" + ds3.Tables[0].ToList().ToJSON() + ",\"Record\":" + ds.Tables[1].Rows[0][0].ObjToStr() + "}");
                                                break;
                                                #endregion
                                            case 3://插入或更新
                                                #region
                                                int id = Request.Form["ID"].ObjToInt();
                                                par.Clear();
                                                if (configs.Count() > 0)//只有update才有附加的where条件
                                                {
                                                    #region update
                                                    sql = "update " + model.Tables + " set ";
                                                    foreach (string ParKey in Request.Form.AllKeys.Where(p => AllAlowUpdateFields.Contains(p)))
                                                    {

                                                        if (Request.Form[ParKey].ObjToStr() == "++")
                                                            sql += "[" + ParKey + "]= [" + ParKey + "]+1,";
                                                        else
                                                        {
                                                            sql += "[" + ParKey + "]=@" + ParKey + ",";
                                                            par.Add(ParKey, Request.Form[ParKey].ObjToStr());
                                                        }
                                                    }
                                                    sql = sql.TrimEnd(',');
                                                    sql += " where 1=1";
                                                    foreach (Model.DataShare_ParameterConfig config in configs)
                                                    {
                                                        string QueryValue = Request.Form[config.ParameterName].ObjToStr();
                                                        if (config.AllowEmpty == 1 || QueryValue != "")
                                                        {
                                                            if (config.DataType == "int")
                                                                QueryValue = QueryValue.ObjToInt().ToString();//强制转换以防注入
                                                            else if (config.DataType == "date")
                                                                QueryValue = QueryValue.ObjToStr("yyyy-MM-dd");
                                                            else if (config.DataType == "datetime")
                                                                QueryValue = QueryValue.ObjToStr("yyyy-MM-dd HH:mm:ss");
                                                            if (config.Operators.IndexOf("like") > -1 || config.Operators.IndexOf("in") > -1)

                                                                otherWhere += "and [" + config.FieldName + "]" + string.Format(config.Operators, QueryValue);
                                                            else
                                                                otherWhere += " and [" + config.FieldName + "]" + string.Format(config.Operators, "'" + QueryValue + "'");
                                                        }
                                                    }
                                                    sql += otherWhere;
                                                    ReSenderResult(uk.ExecuteNonQuery(sql, par).ToString(), RedirectUrl);
                                                    // Response.Write(uk.ExecuteNonQuery(sql, par).ToString());
                                                    #endregion
                                                }
                                                else
                                                {
                                                    #region insert
                                                    sql = "insert into " + model.Tables + "({0}) values ({1})";
                                                    string fieldlist = "", parlist = "";

                                                    par.Clear();
                                                    foreach (string ParKey in Request.Form.AllKeys.Where(p => AllAlowUpdateFields.Contains(p)))
                                                    {
                                                        fieldlist += ParKey + ",";
                                                        parlist += "@" + ParKey + ",";
                                                        par.Add(ParKey, Request.Form[ParKey].ObjToStr());
                                                    }
                                                    sql = string.Format(sql, fieldlist.TrimEnd(','), parlist.TrimEnd(','));
                                                    ReSenderResult(uk.ExecuteNonQuery(sql, par).ToString(), RedirectUrl);
                                                    //Response.Write(uk.ExecuteNonQuery(sql, par).ToString());
                                                    #endregion
                                                }
                                                break;
                                                #endregion
                                            case 4://删除
                                                #region
                                                sql = "delete from " + model.Tables;
                                                if (!string.IsNullOrEmpty(model.WhereStr.Trim()))
                                                {
                                                    sql += " where " + model.WhereStr + " ";
                                                }
                                                else
                                                    sql += " where 1=1 ";
                                                par.Clear();
                                                foreach (string ParKey in Request.Form.AllKeys.Where(p => AllAlowUpdateFields.Contains(p)))
                                                {
                                                    sql += " and " + ParKey + "=@" + ParKey;
                                                    par.Add(ParKey, Request.Form[ParKey].ObjToStr());
                                                }
                                                ReSenderResult(uk.ExecuteNonQuery(sql, par).ToString(), RedirectUrl);
                                                //Response.Write(uk.ExecuteNonQuery(sql, par).ToString());
                                                break;
                                                #endregion
                                        }
                                    }
                                }
                                #endregion
                                break;
                        }
                        #endregion
                        break;
                }
            }
        }
        /// <summary>
        /// 根据重定向url将结果返回给指定url，如果url为空则直接将结果输出在页面上
        /// </summary>
        /// <param name="reuslt">服务器返回结果</param>
        /// <param name="url">重定向url，如果url为空则直接将结果输出在页面上</param>
        private void ReSenderResult(string reuslt, string url)
        {
            if (!string.IsNullOrEmpty(url))
            {
                if (url.IndexOf("?") > 0)
                    Response.Redirect(url + "&Sever_Result=" + Context.Server.UrlEncode(reuslt));
                else
                    Response.Redirect(url + "?Sever_Result=" + Context.Server.UrlEncode(reuslt));
            }
            else
            {
                Response.Write(reuslt);
            }
        }
    }
}