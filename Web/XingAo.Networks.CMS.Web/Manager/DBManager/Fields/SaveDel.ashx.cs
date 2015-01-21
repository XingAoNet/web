using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XingAo.Core;
using XingAo.Networks.CMS.Model;
using XingAo.Core.Data;


namespace XingAo.Networks.CMS.Web.Manager.DBManager.Fields//----------修改命名空间
{
    /// <summary>
    /// SaveDel 的摘要说明
    /// </summary>
    public class SaveDel : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {
        readonly string navTabId = "FieldnavTab";//----------修改标签ID
        public void ProcessRequest(HttpContext context)
        {
            string action = context.Request.QueryString["action"];
            string TID = context.Request.QueryString["TID"];
            int id = context.Request.Form["ID"].ObjToInt();
            string code = "200", msg = "提交成功！", callbackaction = "closeCurrent";
            UnitOfWork uk = new UnitOfWork();
            Dictionary<string, object> par = new Dictionary<string, object>();
            if (!string.IsNullOrEmpty(action))//添加或修改
            {
                //----------在些添加服务相关操作
                CustomTableField model = new CustomTableField();
                #region 数据库相关项
                model.TID = int.Parse(context.Request.Form["txtTID"]);
                model.FieldName = context.Request.Form["txtFieldName"];
                model.IsPrimaryKey = int.Parse(context.Request.Form["txtIsPrimaryKey"]);
                model.ID = context.Request.Form["txtID"].ObjToInt(0);
                model.ChineseName = context.Request.Form["txtChineseName"];
                model.DataType = int.Parse(context.Request.Form["txtDataType"]).ToEnum<FieldTypeEnum>().ToString();
                model.IsSystemField = context.Request.Form["txtIsSystemField"].ObjToInt(1);//如果取不到值就默认作为系统字段处理
                string txtlen = context.Request.Form["txtLeng"].ObjToStr();
                
                model.Description = context.Request.Form["txtDescription"];
                model.DefaultValue = context.Request.Form["txtDefaultValue"];
                if (model.DefaultValue.Trim() == "")
                {
                    if (model.DataType.ToLower().StartsWith(FieldTypeEnum.nvarchar.ToString().ToLower()) || model.DataType.ToLower().StartsWith(FieldTypeEnum.ntext.ToString().ToLower()))
                    {
                        model.DefaultValue = "''";
                    }
                    else if (model.DataType.ToLower().StartsWith(FieldTypeEnum.Int.ToString().ToLower())
                        || model.DataType.ToLower().StartsWith(FieldTypeEnum.bigint.ToString().ToLower())
                        || model.DataType.ToLower().StartsWith(FieldTypeEnum.Float.ToString().ToLower())
                        || model.DataType.ToLower().StartsWith(FieldTypeEnum.money.ToString().ToLower())
                        )
                    {
                        txtlen = "";
                        model.DefaultValue = "0";
                    }
                    else if (model.DataType.ToLower().StartsWith(FieldTypeEnum.smalldatetime.ToString().ToLower()))
                    {
                        txtlen = "";
                        model.DefaultValue = "getdate()";
                    }
                }
                if (txtlen != "")
                    model.DataType += "(" + (txtlen == "0" ? "max" : txtlen) + ")";
                #endregion

                #region 编辑页面相关项
                model.ShowFormEditIndex = int.Parse(context.Request.Form["txtShowFormIndex"]);
                model.ShowEditInForm = int.Parse(context.Request.Form["txtShowInForm"]);
                Model.EditFormControl editform = new EditFormControl();
                editform.ControlType = int.Parse(context.Request.Form["txtFormControlType"]).ToEnum<Model.FormControlTypeEnum>();
                editform.DataBindTableTxtFieldValue = context.Request.Form["txtDataBind"];
                editform.DataValidation = int.Parse(context.Request.Form["txtDataValidation"]).ToEnum<Model.DataValidationEnum>();
                editform.DataValidationCompareID = context.Request.Form["txtDataValidationConparTo"];
                editform.DrawLineAfter = context.Request.Form["txtDrawLin"] == "1";
                editform.FieldName = model.FieldName;
                editform.FormTxt = context.Request.Form["txtFormTxt"];
                editform.Height = context.Request.Form["txtHeight"];
                editform.UseTag_P = context.Request.Form["txtUseTag_P"] == "1";
                editform.Width = context.Request.Form["txtWidth"];
                model.ShowFormEditParJson = editform.ToJSON();
                #endregion

                #region 列表页面相关项
                Model.ListFormControl listform = new ListFormControl();
                listform.Align = context.Request.Form["txtAlign"];
                listform.DataItemAlign = context.Request.Form["txtDataItemAlign"];
                listform.DisplayTitleText = context.Request.Form["txtDisplayTitleText"];
                listform.DisplayValue = context.Request.Form["txtDisplayValue"];
                listform.FieldName = model.FieldName;
                listform.Format = context.Request.Form["txtFormat"];
                listform.HrefLink = context.Request.Form["txtHrefLink"];
                listform.TitleWidth = context.Request.Form["txtTitleWidth"];
                model.ShowListParJson = listform.ToJSON();
                model.ShowList =int.Parse(context.Request.Form["txtShowList"]);
                model.ShowListIndex = int.Parse(context.Request.Form["txtShowListIndex"]);
                #endregion


                #region 列表页上面搜索相关项
                Model.SearchFormControl Searchform = new SearchFormControl();
                Searchform.BeforControlText = context.Request.Form["txtBeforControlText"];
                Searchform.ControlType = context.Request.Form["txtSearchFormControlType"].ObjToInt(0);
                Searchform.DataBindTableTxtFieldValue = context.Request.Form["txtSearchFormDataBind"]; 
                Searchform.FieldName = model.FieldName;
                Searchform.SeachOpt = context.Request.Form["txtSeachOpt"].Replace("＞", ">").Replace("＜", "<").Replace("＝", "=");
                Searchform.ShowInLocation = context.Request.Form["txtShowSearch"].ObjToInt(1);
                model.ShowInSearchJson = Searchform.ToJSON();
                model.ShowInSearch = Searchform.ShowInLocation;
                model.ShowInSearchIndex = context.Request.Form["txtShowSearchOrder"].ObjToInt(0);
                #endregion
                
                par.Add("ID", model.ID);
                par.Add("TID", model.TID);
                par.Add("FieldName", model.FieldName);
                par.Add("DataType", model.DataType);
                par.Add("ChineseName", model.ChineseName);
                par.Add("DefaultValue", model.DefaultValue);
                par.Add("IsPrimaryKey", model.IsPrimaryKey);
                par.Add("Description", model.Description);
                par.Add("ShowEditInForm", model.ShowEditInForm);
                par.Add("ShowFormEditIndex", model.ShowFormEditIndex);
                par.Add("ShowFormEditParJson", model.ShowFormEditParJson);
                par.Add("ShowList", model.ShowList);
                par.Add("ShowListIndex", model.ShowListIndex);
                par.Add("ShowListParJson", model.ShowListParJson);


                par.Add("ShowInSearch", model.ShowInSearch);
                par.Add("ShowInSearchIndex", model.ShowInSearchIndex);
                par.Add("ShowInSearchJson", model.ShowInSearchJson);

                par.Add("IsSystemField", model.IsSystemField);
                par.Add("IsDel", 0);
               
            }
            else//删除
            {
                msg = "删除成功！";
                callbackaction = "";
                //----------在些添加服务相关操作
               
                int ID = context.Request.Form["ids"].Split(',')[0].ObjToInt();
                par.Add("ID", ID);
                par.Add("TID", 0);
                par.Add("FieldName", "");
                par.Add("DataType", "");
                par.Add("ChineseName", "");
                par.Add("DefaultValue", "");
                par.Add("IsPrimaryKey", "");
                par.Add("Description", "");
                par.Add("ShowEditInForm", "");
                par.Add("ShowFormEditIndex", "");
                par.Add("ShowFormEditParJson", "");
                par.Add("ShowList", "");
                par.Add("ShowListIndex", "");
                par.Add("ShowListParJson", "");
                par.Add("ShowInSearch", "");
                par.Add("ShowInSearchIndex", "");
                par.Add("ShowInSearchJson", "");
                par.Add("IsSystemField", "");
                par.Add("IsDel", 1);                
            }
            string err = uk.ExecuteScalar("Pro_UpdateFieldAndCreateTable", par).ObjToStr();
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
