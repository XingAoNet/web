using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XingAo.Core;
using XingAo.Core.Data;
using XingAo.Networks.CMS.Model;


namespace XingAo.Networks.CMS.Web.Manager.LableDesign//----------修改命名空间
{
    /// <summary>
    /// SaveDel 的摘要说明
    /// </summary>
    public class SaveDel : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {
        readonly string navTabId = "navTab_LableDesign";//----------修改标签ID
        public void ProcessRequest(HttpContext hc)
        {
            string action = hc.Request.QueryString["action"];
            UnitOfWork uk = new UnitOfWork();
            int id = hc.Request.Form["txtID"].ObjToInt();
            string code = "200", msg = "提交成功！", callbackaction = "closeCurrent";
            if (!string.IsNullOrEmpty(action))//添加或修改
            {
                string Params= hc.Request.Form["p_Param"];
                Model.Labels mode;
                List<int> ids = new List<int>();
                if (id > 0)
                {
                    mode = uk.FindSigne<Model.Labels>(c => c.ID == id);
                    ids = mode.Params.Select(c => c.Id).ToList();
                }
                else
                {
                    mode = new Model.Labels();
                    mode.LableId = System.Guid.NewGuid().ToString("N");
                }
                mode.IsPager = hc.Request.Form["IsPager"] == "on" ? 1 : 0;
                mode.PagerSize = hc.Request.Form["TxtPageSize"].ObjToInt(0);
                mode.LableName = hc.Request.Form["txtLableName"];
                mode.LabelDescription = hc.Request.Form["txtLabelDescription"];
                mode.TemplateHtml = hc.Request.Form["LabelTxt"];
                mode.Analyze = hc.Request.Form["AnalyzeJX"];
                mode.DbSql = hc.Request.Form["SqlTxt"];
                uk.Save(mode, id);

                #region 参数新增与修改
                if (!string.IsNullOrEmpty(Params))
                {
                    LabelParams param;
                    int p_id=0;
                    foreach (string p in Params.Split(','))
                    {
                        string[] _p = p.Trim('|').Split('|');
                        if (_p.Length == 4)
                        {
                            p_id = _p[0].ObjToInt(0);
                            if (p_id != 0)
                            {
                                param = uk.FindAll<LabelParams>().Where(c => c.Id == p_id).FirstOrDefault();
                                if (param != null)
                                    ids.Remove(param.Id);
                            }
                            else
                            {
                                param = new LabelParams();
                                param.LableId = mode.LableId;
                            }

                            param.ParamName = _p[1];
                            param.DefaultValue = _p[2];
                            param.ParamDescription = _p[3];
                            uk.Save(param, p_id);
                        }
                    }
                }
                #endregion

                #region 删除修改后不需要的参数
                uk.Remove<LabelParams>(c => ids.Contains(c.Id));
                #endregion
               

            }
            else//删除
            {
                msg = "删除成功！";
                callbackaction = "";
                string[] IDs = hc.Request.Form["ids"].Split(',');
                foreach (Model.Labels g in uk.FindByFunc<Model.Labels>(c => IDs.Contains(c.ID.ToString())).ToList())
                {
                    uk.Remove<Model.LabelParams>(c => c.LableId == g.LableId, false);
                    uk.Remove(g, false);
                    
                }
               

            }
            if (uk.Commit(out msg) == 0)
                code = "300";
            else
            {
                DataCache.RemoveCache(DataCache.DataCacheType.CustomLable);
                msg = "提交成功！";
            }

            hc.Response.Write("{\"statusCode\":\"" + code + "\",\"message\":\"" + msg + "\",\"navTabId\":\"" + navTabId + "\",\"rel\":\"\",\"callbackType\":\"" + callbackaction + "\",\"forwardUrl\":\"\",\"confirmMsg\":\"\"}");
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
