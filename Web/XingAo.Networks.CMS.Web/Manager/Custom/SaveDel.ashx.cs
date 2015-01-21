using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XingAo.Core;
using XingAo.Core.Data;
using System.Text;

namespace XingAo.Networks.CMS.Web.Manager.Custom//----------修改命名空间
{
    /// <summary>
    /// SaveDel 的摘要说明
    /// </summary>
    public class SaveDel : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {
        string navTabId = "navTab_";//----------修改标签ID
        public void ProcessRequest(HttpContext context)
        {
            string action = context.Request.QueryString["action"];

            int id = context.Request.Form["txt_ID"].ObjToInt();
            int TID = context.Request.QueryString["TID"].ObjToInt();
            navTabId += TID.ToString();
           
            string code = "200", msg = "提交成功！", callbackaction = "closeCurrent";

            UnitOfWork uk = new UnitOfWork();
            Model.CustomTable mode= uk.FindSigne<Model.CustomTable>(p => p.ID == TID);
            string TableName =mode.TabName;
            
            if (!string.IsNullOrEmpty(action))//添加或修改
            {
                string Fields = context.Request.Form["Fields_List"];
                if (!string.IsNullOrEmpty(Fields))
                {
                    #region
                    string[] Fields_List = Fields.Trim(',').Split(',');
                    StringBuilder sql = new StringBuilder();
                    Dictionary<string, object> par = new Dictionary<string, object>();
                    if (id > 0)
                    {
                        #region 修改
                        sql.Append("update " + TableName + " set ");
                        string Val = string.Empty;
                        foreach (Model.CustomTableField Field in mode.CustomTableFields.Where(c=>c.ShowEditInForm==1))
                        {
                            Val = context.Request.Form["txt_" + Field.FieldName];
                            if (!string.IsNullOrEmpty(Val) || Field.DataType.IndexOf("char")>-1)
                            {
                                sql.Append(Field.FieldName + "=@" + Field.FieldName + ",");
                                par.Add(Field.FieldName, Val);
                            }
                            else 
                            {
                                if (Field.DataType == "Int")
                                {
                                    Model.EditFormControl edit = Field.ShowFormEditParJson.JsonToObject<Model.EditFormControl>();
                                    if (edit.ControlType == Model.FormControlTypeEnum.Checkbox)
                                    {
                                        sql.Append(Field.FieldName + "=@" + Field.FieldName + ",");
                                        par.Add(Field.FieldName, Val=="on"?1:0);
                                    }
                                }
                            }
                        }
                        sql = sql.Remove(sql.Length - 1, 1);
                        sql.Append(" where id=@id");
                        par.Add("id", id);
                        #endregion
                    }
                    else
                    {
                        #region 新增
                        sql.Append("insert into " + TableName + " ( ");
                        StringBuilder values = new StringBuilder(" values (");
                        foreach (string f in Fields_List)
                        {
                            if (!string.IsNullOrEmpty(f))
                            {

                                if (!string.IsNullOrEmpty(context.Request.Form["txt_" + f]))
                                {
                                    sql.Append(f + ",");
                                    values.Append("@" + f + ",");
                                    par.Add(f, context.Request.Form["txt_" + f]);
                                }

                            }
                        }
                        sql = sql.Remove(sql.Length - 1, 1);
                        values = values.Remove(values.Length - 1, 1);
                        sql = sql.Append(")").Append(values).Append(")");
                        #endregion
                    }
                    uk.ExecuteNonQuery(sql.ToString(), par);
                    #endregion
                }
                else
                {
                    code = "300";
                    msg = "字段为空";
                }

            }
            else//删除
            {
                msg = "删除成功！";
                callbackaction = "";
                string ids = context.Request.Form["ids"];
                uk.ExecuteNonQuery("delete from " + TableName + " where id in(" + ids + ")", null);

            }
            string err = "";
            uk.Commit(out err);
            if (err != "")
            {
                code = "300";
                msg = err;
            }
            context.Response.Write("{\"statusCode\":\"" + code + "\",\"message\":\"" + msg + "\",\"navTabId\":\"" + navTabId + "\",\"rel\":\"\",\"callbackType\":\"" + callbackaction + "\",\"forwardUrl\":\"\",\"confirmMsg\":\"\"}");
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}