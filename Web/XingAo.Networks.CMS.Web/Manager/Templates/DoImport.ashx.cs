using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XingAo.Core;
using System.IO;
using System.Text.RegularExpressions;
using XingAo.Core.Data;
namespace XingAo.Networks.CMS.Web.Manager.Templates//----------修改命名空间
{
    /// <summary>
    /// DoImport 的摘要说明
    /// </summary>
    public class DoImport : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {
        readonly string navTabId = "navTab_Templates";//----------修改标签ID
        UnitOfWork db = new UnitOfWork();
        public void ProcessRequest(HttpContext context)
        {
            string code = "200", msg = "提交成功！", callbackaction = "closeCurrent";
            if (context.Request.QueryString["Import"].ObjToInt() == 1)//导入
            {
                DataCache.RemoveCache(DataCache.DataCacheType.TempLate);
                DataCache.RemoveCache(DataCache.DataCacheType.AllLabels);
                #region 导入
                int bakid = context.Request.Form["txt_BakID"].ObjToInt();                
                if (bakid >= 0)//
                {
                    string DirName = "/Templates";
                    if (bakid > 0)
                    {
                        try
                        {
                           
                            Model.TemplatesBak model = db.FindByFunc<Model.TemplatesBak>(p => p.ID == bakid).FirstOrDefault();// templatesbakrepository.GetModelBySearch(p => p.ID == bakid);
                            DirName += "/" + model.DirName;
                            model.LastUpdateTime = DateTime.Now;
                            db.Save(model, model.ID);
                            db.Commit();
                        }
                        catch
                        {
                            DirName = "";
                            code = "300";
                            msg = "模板路径设置异常！";
                        }
                    }

                    if (DirName != "")
                    {
                        if (!Directory.Exists(context.Server.MapPath(DirName)))
                        {
                            code = "300";
                            msg = "模板路径不存在！";
                        }
                        else
                        {
                            FileInfo[] Files = new DirectoryInfo(context.Server.MapPath(DirName)).GetFiles("*_*_*.html", SearchOption.TopDirectoryOnly);
                            //Impl.TemplatesRepository templatesrepository = new Impl.TemplatesRepository();
                            
                            foreach (FileInfo f in Files)
                            {
                                MatchCollection mc = Regex.Matches(f.ToString(), @"(?<parm1>^\d+)_(?<parm2>\d+)_(?<parm3>.*).html");
                                if (mc.Count > 0)
                                {
                                    int DbID = mc[0].Groups["parm1"].Value.ObjToInt();
                                    if (DbID >= 0)
                                    {
                                        bool isInsert = DbID == 0 ? true : false;
                                        int TypeID = mc[0].Groups["parm2"].Value.ObjToInt();
                                        string TemplateTitle = mc[0].Groups["parm3"].Value;
                                        Model.Templates bak = new Model.Templates();
                                        bak.ID = DbID;
                                        bak.TemplateDescription = TemplateTitle;
                                        bak.TemplateHtml = File.ReadAllText(f.FullName);
                                        bak.TemplateName = TemplateTitle;
                                        bak.TemplateType = TypeID;
                                        int newid = 0;
                                        if (db.Save(bak, bak.ID).ID>0 && isInsert)
                                        {
                                            File.Move(f.FullName, f.FullName.Replace(f.ToString(), "") + newid.ToString() + "_" + TypeID.ToString() + "_" + TemplateTitle + ".html");
                                        }
                                        //if (templatesrepository.Save(bak, out newid) && isInsert)
                                        //{
                                        //    File.Move(f.FullName, f.FullName.Replace(f.ToString(), "") + newid.ToString() + "_" + TypeID.ToString() + "_" + TemplateTitle + ".html");
                                        //}
                                    }
                                }
                            }
                            db.Commit();
                        }
                    }
                }
                else
                {
                    code = "300";
                    msg = "请选择要导入的模板！";
                }
                #endregion
            }
            else//导出
            {
                #region 导出
                int bakid = context.Request.Form["txtID"].ObjToInt();
                Model.TemplatesBak bak=null;
                //Impl.TemplatesBakRepository BakRepository=new Impl.TemplatesBakRepository();
                if (bakid == 0)//新建一个
                {
                    bak = new Model.TemplatesBak();
                    bak.Descriptions = context.Request.Form["txtDescriptions"];
                    bak.DirName = DateTime.Now.ToString("yyyyMMddHHmmss");
                    bak.Title = context.Request.Form["txtTitle"];
                    bak.CreateTime = bak.LastUpdateTime = DateTime.Now;
                }
                else if (bakid > 0)//导出到原有记录里
                {
                    bak = db.FindByFunc<Model.TemplatesBak>(p => p.ID == bakid).FirstOrDefault();// BakRepository.GetModelBySearch(p => p.ID == bakid);
                    if (bak != null && bak.ID > 0)
                    {
                        bak.Descriptions = context.Request.Form["txtDescriptions"];
                       // bak.DirName = DateTime.Now.ToString("yyyyMMddHHmmss");
                        bak.Title = context.Request.Form["txtTitle"];
                        bak.LastUpdateTime = DateTime.Now;
                        FileOption.DelFileInDirectory("/Templates/"+bak.DirName);
                    }
                    else
                    {
                        code = "300";
                        msg = "原来模板不存在，无法导入到此模板";
                    }
                }
                if (code == "200")//如果没有错误时，执行导出文件
                {
                    //Impl.TemplatesRepository templatesrepository = new Impl.TemplatesRepository();
                    foreach (Model.Templates temp in db.FindAll<Model.Templates>().ToList())
                    {
                        FileOption.WriteFile("/Templates/" + bak.DirName + "/" + temp.ID.ToString() + "_" + temp.TemplateType.ToString() + "_" + temp.TemplateName + ".html", temp.TemplateHtml, false);
                    }
                    db.Save(bak, bak.ID);
                    db.Commit();
                    //BakRepository.Save(bak);
                }
                #endregion
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
