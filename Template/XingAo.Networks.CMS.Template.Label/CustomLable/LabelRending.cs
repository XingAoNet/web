using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Xml.Xsl;
using XingAo.Core;
using XingAo.Core.Data;
using XingAo.Networks.CMS.Model;
using XingAo.Networks.CMS.Template.Label.SystemLabel;

namespace XingAo.Networks.CMS.Template.Label.CustomLable
{
    public class LabelRending
    {
        private static List<Labels> Labels
        {
            get
            {
                object labels = DataCache.GetCache("AllCustomLableCache", DataCache.DataCacheType.CustomLable);
                if (labels == null)
                {
                    UnitOfWork uk = new UnitOfWork();
                    labels = uk.FindAll<Labels>().ToList();
                    DataCache.SetCache("AllCustomLableCache", labels);

                }
                return labels as List<Labels>;
            }
        }

        /// <summary>
        /// 标签正则
        /// </summary>
        static Regex Reg = new Regex(@"(?<Label>\{\$XA_(?<LableName>([\u4e00-\u9fa5]|\w)+)[\s]*?(?<Attribute>.*?)?\$\})", RegexOptions.Singleline | RegexOptions.IgnoreCase | RegexOptions.Compiled);

        /// <summary>
        /// 参数正则
        /// </summary>
        static Regex ParamReg = new Regex(@"(?<ParamName>\w+)=['""]?(?<ParamValue>\w+)['""]?", RegexOptions.Singleline | RegexOptions.IgnoreCase | RegexOptions.Compiled);

        static Regex RoutesReg = new Regex(@"(?<Routes>@Routes_(?<ParamName>\w+))", RegexOptions.Singleline | RegexOptions.IgnoreCase | RegexOptions.Compiled);//   ClassName

        static Regex RequestReg = new Regex(@"(?<Request>@Request_(?<RequestName>\w+))", RegexOptions.Singleline | RegexOptions.IgnoreCase | RegexOptions.Compiled);

        static Regex FormReg = new Regex(@"(?<Request>@Form_(?<RequestName>\w+))", RegexOptions.Singleline | RegexOptions.IgnoreCase | RegexOptions.Compiled);

        // static Regex UrlPagerReg = new Regex(@"(?<UrlPager>\{@UrlPager\s*?(PageSize=['""]?(?<PageSize>\d+)['""]?)?\})", RegexOptions.Singleline | RegexOptions.IgnoreCase | RegexOptions.Compiled);

        static Regex UrlPagerReg = new Regex(@"(?<UrlPager>\{@UrlPager\})", RegexOptions.Singleline | RegexOptions.IgnoreCase | RegexOptions.Compiled);

        /// <summary>
        /// 渲染标签
        /// </summary>
        /// <param name="Html"></param>
        /// <returns></returns>
        public static string RenderLabel(string Html)
        {
            MatchCollection match = Reg.Matches(Html);

            while (match.Count > 0)
            {
                Dictionary<string, string> Params = null;
                foreach (Match var in match)
                {
                    Params = new Dictionary<string, string>();
                    if (!string.IsNullOrEmpty(var.Groups["Attribute"].Value))
                    {
                        MatchCollection p_match = ParamReg.Matches(var.Groups["Attribute"].Value);
                        foreach (Match p in p_match)
                        {
                            Params.Add("@" + p.Groups["ParamName"].Value, p.Groups["ParamValue"].Value);
                        }
                    }

                    Html = Html.Replace(var.Groups["Label"].Value, LabelRending.LabelHtml(ReleaseParam(var.Groups["LableName"].Value), Params));
                }
                match = Reg.Matches(Html);
            }
            return Html;
        }

        private static string ReleaseParam(string Html)
        {
            GetRouteData rd = new GetRouteData();
            foreach (Match var in RoutesReg.Matches(Html))
            {
                Html = Html.Replace(var.Groups["Routes"].Value, rd.GetRouteValue(var.Groups["ParamName"].Value));

            }
            foreach (Match var in RequestReg.Matches(Html))
            {
                Html = Html.Replace(var.Groups["Request"].Value, HttpContext.Current.Request.QueryString[var.Groups["RequestName"].Value]);

            }
            foreach (Match var in FormReg.Matches(Html))
            {
                Html = Html.Replace(var.Groups["Request"].Value, HttpContext.Current.Request.Form[var.Groups["RequestName"].Value]);

            }

            return Html;
        }

        /// <summary>
        /// 渲染标签
        /// </summary>
        /// <param name="LabelName"></param>
        /// <returns></returns>
        private static string LabelHtml(string LabelName, Dictionary<string, string> Params)
        {
            string RendHtm = string.Empty;
            if (!string.IsNullOrEmpty(LabelName))
            {
                var lb = Labels.Where(l => l.LableName == LabelName).FirstOrDefault();
                if (lb != null)
                {

                    string SQL = lb.DbSql;
                    string LabelTemplate = lb.TemplateHtml;
                    #region 加载参数
                    foreach (var p in lb.Params)
                    {
                        if (Params != null)
                        {
                            if (Params.ContainsKey(p.ParamName))//判断传递参数是否是设定参数列表中
                            {
                                p.DefaultValue = Params[p.ParamName];//如果参数有赋值使用赋值，否则使用默认值
                            }
                        }
                        SQL = SQL.Replace(p.ParamName, p.DefaultValue);
                        LabelTemplate = LabelTemplate.Replace(p.ParamName, p.DefaultValue);

                    }
                    #endregion
                    SQL = ReleaseParam(SQL);
                    LabelTemplate = ReleaseParam(LabelTemplate);
                    //渲染模式
                    RendHtm = DbToHtm(SQL, LabelTemplate, lb.IsPager, lb.PagerSize, lb.Analyze);
                }
                else
                    RendHtm = "标签：" + LabelName + "渲染失败。失败：标签不存在！";

            }
            else
                RendHtm = "标签：" + LabelName + "渲染失败。失败：标签名为空！";
            return RendHtm;
        }


        /// <summary>
        /// 拆分sql语句
        /// </summary>\s+order\s+by\s+(?<order>[\w_]+(\s+(ASC|DESC))?))?\s*
        /// <param name="SQL"></param>
        /// <returns></returns>
        public static Dictionary<string, object> SplitSql(string SQL)
        {
            Dictionary<string, object> sqlParam = new Dictionary<string, object>();
            Regex IsVreg = new Regex(Sqlpattern(), RegexOptions.Singleline | RegexOptions.IgnoreCase | RegexOptions.Compiled);
            Match match = IsVreg.Match(SQL.Trim());
            if (match.Length > 0)
            {
                sqlParam.Add("@TableName", match.Groups["table"].Value);
                sqlParam.Add("@Fields", match.Groups["fileds"].Value);
                sqlParam.Add("@Where", match.Groups["where"].Value);
                sqlParam.Add("@OrderBy", match.Groups["order"].Value);
                sqlParam.Add("@CurrentPage", new GetRouteData().GetPage());
            }
            return sqlParam;
        }

        public static string Sqlpattern()
        {
            String column = "(\\w+\\s*(\\w+\\s*){0,1})";//一列的正则表达式匹配如 product p
            String columns = column + "(,\\s*" + column + ")*"; //多列正则表达式 匹配如 product p,category c,warehouse w
            String ownerenable = "((\\w+\\.){0,1}\\w+\\s*(\\w+\\s*){0,1})";//一列的正则表达式匹配如 a.product p
            String ownerenables = ownerenable + "(,\\s*" + ownerenable + ")*";//多列正则表达式 匹配如 a.product p,a.category c,b.warehouse w
            String from = "FROM\\s+(?<table>" + columns + ")";
            String condition = "(\\w+\\.){0,1}\\w+\\s*(=|LIKE|IS)\\s*'?(\\w+\\.){0,1}[\\w%]+'?";//条件的正则表达式匹配如 a=b 或 a is b..
            String conditions = condition + "(\\s+(AND|OR)\\s*" + condition + "\\s*)*";//多个条件匹配如 a=b and c like 'r%' or d is null
            String where = "(WHERE\\s+(?<where>" + conditions + ")){0,1}";
            String order = "(order\\s+by\\s+(?<order>.*)){0,1}";
            String pattern = "SELECT\\s+((?<fileds>\\*|" + ownerenables + ")\\s+" + from + ")\\s+" + where + "\\s*" + order; //匹配最终sql的正则表达式
            return pattern;
        }

        /// <summary>
        /// 加载XSL数据并渲染
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="Template"></param>
        /// <returns></returns>
        public static string DbToHtm(string sql, string Template)
        {
            return DbToHtm(sql, Template, 0, 15, "");
        }

        /// <summary>
        /// 加载XSL数据并渲染
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="Template"></param>
        /// <returns></returns>
        public static string DbToHtm(string sql, string Template, int IsPager, int PageSize, string Analyze)
        {
            if (Analyze == "Text") return Template;
            UnitOfWork uk = new UnitOfWork();
            DataTable souce = new DataTable();
            int RecordNum = 0;
            Dictionary<string, string> Pagers = new Dictionary<string, string>();

            if (!string.IsNullOrEmpty(sql))
            {
                sql = ReleaseParam(sql);
                Template = ReleaseParam(Template);
                if (IsPager == 0)
                    souce = uk.GetProDataTable(sql);
                else
                {
                    Dictionary<string, object> sqlParam = SplitSql(sql);
                    sqlParam.Add("@PageSize", PageSize);
                    DataSet ds = uk.GetProDataSet("Pro_GetRecordByPage", sqlParam);
                    souce = ds.Tables[0];
                    RecordNum = ds.Tables[1].Rows[0][0].ObjToInt(0);
                }
            }


            System.IO.StringWriter output = new System.IO.StringWriter();
            System.Xml.XmlDocument xml = XMLOption.DataTableToXml(souce);
            XslCompiledTransform transform = new XslCompiledTransform();
            System.Xml.XmlDocument xls = new System.Xml.XmlDocument();
            xls.LoadXml(Template);
            transform.Load(xls.CreateNavigator());
            transform.Transform(xml.CreateNavigator(), null, output);
            output.Close();
            Template = output.ToString();
            foreach (Match var in UrlPagerReg.Matches(Template))
            {
                Template = Template.Replace(var.Groups["UrlPager"].Value, PageInfo.GetPageInfo(RecordNum, PageSize));
            }

            return Template;
        }
    }
}
