using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using XingAo.Core;
using XingAo.Core.Data;
using XingAo.Networks.CMS.Template.Label.CustomLable;


//自定义标签格式：{$XA_中文数字字母组合$}  {$XA_中文数字字母组合 Params1="11" Params2="22" Params3='33'$}
//系统标签格式：{$XingAo_中文数字字母组合$}
//模块标签格式：{$中文数字字母组合$}

namespace XingAo.Networks.CMS.Template.Engine
{
    /// <summary>
    /// 模板引擎
    /// </summary>
    public static class TemplateEngine
    {
        /// <summary>
        /// 根据当前页面url相关参数调取对应模板，并返回标签替换后的内容
        /// </summary>
        /// <returns></returns>
        public static string GetPageHtml()
        {
           
            StringBuilder PageHtml = new StringBuilder();
            GetRouteData data = new GetRouteData();
            string ClassName = data.GetClassName();
            int ClassID = 1;
            if (ClassName!= "")               
             ClassID = Label.LabelFunctions.WebNavigationConvert.GetIDByEName(ClassName);
            UnitOfWork uk = new UnitOfWork();
            Model.WebNavigation nav = uk.FindSigne<Model.WebNavigation>(p => p.ID == ClassID);
            if (nav == null || nav.ID <= 0)
                return "栏目不存在！";
            int ContentID = data.GetContnetID();

            #region 开始从数据库在找模板
            Model.Templates model;
            if (ClassName == "")
            {
                model = uk.FindSigne<Model.Templates>(p => p.ID == nav.IndexTemplate);
            }
            else
            {
                if (ContentID > 0)
                {
                    model = uk.FindSigne<Model.Templates>(p => p.ID == nav.InfoTemplate);
                }
                else
                {
                    model = uk.FindSigne<Model.Templates>(p => p.ID == nav.ListTemplate);
                }
            }
            #endregion

            if (model != null && model.ID > 0)
            {
                PageHtml.Append(model.TemplateHtml);
                return GetPageHtml(PageHtml);
            }
            else
                return "模板不存在！";
        }
        /// <summary>
        /// 根据模板/模块英文名 取未渲染（标签没有被渲染）的html
        /// </summary>
        /// <param name="TempalteEname">模板或模块英文名（不允许为空）</param>
        /// <returns></returns>
        public static string GetTemplateHtml(string TempalteEname)
        {
            if (string.IsNullOrEmpty(TempalteEname))
                throw new Exception("TempalteEname--模板或模块英文名不允许为空");
            StringBuilder PageHtml = new StringBuilder();
            UnitOfWork uk = new UnitOfWork();
            Model.Templates model = uk.FindSigne<Model.Templates>(p => p.TemplateEName == TempalteEname);
            if (model != null)
            {
                if (model != null && model.ID > 0)
                {
                    PageHtml.Append(model.TemplateHtml);
                    return GetPageHtml(PageHtml);
                }
                else
                    PageHtml.Append( "模板不存在！");
            }
            return PageHtml.ToString();
        }
        /// <summary>
        /// 根据模板/模块英文名 取渲染后（标签被渲染后）的html
        /// </summary>
        /// <param name="TempalteEname">模板或模块英文名（不允许为空）</param>
        /// <returns></returns>
        public static string GetTemplateResendHtmlByEname(string TempalteEname)
        {
            return GetPageHtml(new StringBuilder(GetTemplateHtml(TempalteEname)));
        }
        /// <summary>
        /// 替换标签
        /// </summary>
        /// <param name="TemplateHtml">带标签的模板</param>
        /// <returns></returns>
        public static string GetPageHtml(StringBuilder TemplateHtml)
        {
            
            UnitOfWork uk = new UnitOfWork();
            Dictionary<string, object> AllLabel = DataCache.GetCache("AllLabelCache", DataCache.DataCacheType.AllLabels) as Dictionary<string, object>;
            if (AllLabel == null || AllLabel.Count == 0)
            {
                AllLabel = new Dictionary<string, object>();
                //加载模块
                foreach (Model.Templates temp in uk.LoadWhereLambda<Model.Templates>(p => p.TemplateType == 0))
                {
                    AllLabel.Add("{$" + temp.TemplateName + "$}", temp);
                }
                //加载系统标签
                foreach (Model.SysLabels temp in uk.LoadWhereLambda<Model.SysLabels>(p => true))
                {
                    AllLabel.Add("{$XingAo_" + temp.LabelName + "$}", temp);
                }
                AllLabel.SetCache("AllLabelCache", DataCache.DataCacheType.AllLabels);
            }

            //Regex re = new Regex(@"(\{\$(XingAo_|XA_)?([\u4e00-\u9fa5]|\d|[a-zA-Z])+([\x00-\xFF]+)?\$\})", RegexOptions.IgnoreCase);
            
        // Regex re = new Regex(@"((\{\$(XingAo_|XA_)?([\u4e00-\u9fa5]|\d|[a-zA-Z])+(?<Attribute>.+?)\$\})?)", RegexOptions.IgnoreCase);
            Regex re = new Regex(@"\{\$(.*?)\$\}", RegexOptions.IgnoreCase);
            List<string> labels = new List<string>();
            MatchCollection matchs = re.Matches(TemplateHtml.ToString());
            while (matchs.Count > 0)
            {
                foreach (Match match in matchs)
                {
                    if (match.Value.StartsWith("{$XA_"))//自定义标签
                    {
                        TemplateHtml.Replace(match.Value, LabelRending.RenderLabel(match.Value));
                        continue;
                    }
                    var label = AllLabel.Where(p => p.Key == match.Value).FirstOrDefault();
                    if (label.Key == null || label.Key == "")
                        TemplateHtml.Replace(match.Value, "<font color='red'>Err:" + match.Value.Replace("{$", "【").Replace("$}", "】") + " 不存在！</font>");
                    else
                    {
                        try
                        {
                            if (match.Value.StartsWith("{$XingAo_"))//系统标签（即调用某方法来完成）
                            {
                                Model.SysLabels temp = label.Value as Model.SysLabels;
                                TemplateHtml.Replace(match.Value, ReflectionOpt.GetMethodResult(temp.NameSpace, temp.NameSpaceClass, temp.Method, temp.Parameters.Trim() == "" ? null : temp.Parameters.Split(',')).ObjToStr());
                            }
                            else//模块
                            {
                                Model.Templates temp = label.Value as Model.Templates;
                                TemplateHtml.Replace("{$" + temp.TemplateName + "$}", temp.TemplateHtml);
                            }
                            
                        }
                        catch (Exception err)
                        {
                            TemplateHtml.Replace(match.Value, "<font color='red'>Err:" + match.Value.Replace("{$", "【").Replace("$}", "】") + err.Message + " </font>");
                        }
                    }

                }
                matchs = re.Matches(TemplateHtml.ToString());

            }
            return TemplateHtml.ToString();
        }
    }
}
