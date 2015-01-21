using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Routing;
using XingAo.Core.Data;
using XingAo.Core;
using System.Text;
using System.Text.RegularExpressions;

namespace XingAo.Networks.CMS.Web
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            RootPath = AppDomain.CurrentDomain.BaseDirectory;
            RegisterRoutes(RouteTable.Routes);
            //System.Timers.Timer myTimer = new System.Timers.Timer();
            //myTimer.Elapsed += new System.Timers.ElapsedEventHandler(myTimer_Elapsed);
            //myTimer.Interval = 1000;
            //myTimer.Enabled = true;
        }

        static string TodayLoad = string.Empty;
        public static List<Model.Collect> collects=null;
        UnitOfWork uk = new UnitOfWork();
        string RootPath = string.Empty;

        void myTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            DateTime dt = DateTime.Now;
            if (collects == null)
                collects = new UnitOfWork().FindByFunc<Model.Collect>(p => p.IsUse == 1).ToList();
            List<Model.Collect> clls = collects.Where(c => c.StartTime== dt.ToString("HH:mm:ss") && TodayLoad != dt.ToString("yyyy-MM-dd")).ToList();
            if (clls.Count > 0)
            {
                TodayLoad = dt.ToString("yyyy-MM-dd");
                foreach (Model.Collect model in clls)
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
                                foreach (string url in urls.Take(10))
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
                                                
                                                param.Add("@" + Pattern.InsertField, LoadImage(uri.Host, url, rg.Match(cms).Groups[Pattern.ParamName].Value.Replace("\r\n","").Replace("<br />","")));
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
                }

            }
        }


        private string LoadImage(string Host, string url, string Html)
        {
            Regex Imgreg = new Regex("<img.*?src=[\'\"]?(?<imgUrl>[^\'\"]*)[\'\"]?.*?(?:>|\\/>)");
            MatchCollection match = Imgreg.Matches(Html);
            string ImgPath ="upload/image/"+ DateTime.Now.ToString("yyyyMMdd") + "/";
            string DownPath = RootPath + ImgPath;
            if (!System.IO.Directory.Exists(DownPath))
                System.IO.Directory.CreateDirectory(DownPath);
            string imgUrl = string.Empty;
            string FileName = string.Empty;
            foreach (Match var in match)
            {
                imgUrl = var.Groups["imgUrl"].Value;
                if (!string.IsNullOrEmpty(imgUrl))
                {
                    if (imgUrl.IndexOf("http://") < 0)
                    {
                        if (imgUrl.Substring(0, 1) == "/")
                        {
                            imgUrl = Host + imgUrl;
                        }
                        else
                        {
                            imgUrl = url.Substring(0, url.LastIndexOf("/") + 1) + imgUrl;
                        }
                        FileName = imgUrl.Substring(imgUrl.LastIndexOf("."));
                        
                    }
                    try
                    {
                        DownPath = DownPath + DateTime.Now.Ticks + FileName;
                        ImgPath = "/"+ImgPath + DateTime.Now.Ticks + FileName;
                        using (System.Net.WebClient wc = new System.Net.WebClient())
                        {
                            wc.Headers.Add("User-Agent", "Chrome");
                            wc.DownloadFile(imgUrl, DownPath);
                        }
                        Html = Html.Replace(var.Groups["imgUrl"].Value, ImgPath);
                    }
                    catch { }
                }


            }
            return Html;
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            //数据开放接口
            routes.MapPageRoute("DataShare", "ShareData/{MethodName}", "~/DataShare.aspx");
            //验证码
            routes.MapPageRoute("ImageCode", "ImageCode", "~/Shared/Verification.aspx");
            //网站地图
            routes.MapPageRoute("SiteMap", "SiteMap", "~/WebMap.aspx");
            //验证码
            routes.MapPageRoute("vcode", "Verification", "~/Shared/Verification.aspx");
            routes.MapPageRoute("vcode2", "Verification/{ClassName}", "~/Verification.aspx");
            //网站RSS
            routes.MapPageRoute("RSS", "RSS/{ClassName}", "~/Shared/RSS.aspx");
            //文件上传
            routes.MapPageRoute("UpLoadFile", "UpLoadFile", "~/UploadLocalFile.aspx");

            #region 前台用户
            //找回密码
            routes.MapPageRoute("FindPwd", "UserCenter/FindPwd", "~/UserCenter/FindPwd.aspx");
            //用户登录提交处理页面
            routes.MapPageRoute("Login", "UserCenter/Login", "~/UserCenter/Login.aspx");
            //用户登录页面
            routes.MapPageRoute("LoginPage", "UserCenter/UnLogin", "~/UserCenter/LoginPage.aspx");
            //用户退出登录
            routes.MapPageRoute("Logout", "UserCenter/Logout", "~/UserCenter/Logout.aspx");
            //用户修改密码
            routes.MapPageRoute("EditPwd", "UserCenter/EditPwd", "~/UserCenter/EditPwd.aspx");
            //用户注册
            routes.MapPageRoute("UserReg", "UserCenter/UserReg", "~/UserCenter/Reg.aspx");
            //用户积分总记录
            routes.MapPageRoute("UserPoint", "UserCenter/UserPoint", "~/UserCenter/UserPoint.aspx");
            //用户资料
            routes.MapPageRoute("UserInfo", "UserCenter/UserInfo", "~/UserCenter/UserInfo.aspx");
            //用户忘记密码时重置密码页面
            routes.MapPageRoute("ResetPwd", "UserCenter/ResetPwd", "~/UserCenter/ResetPassword.aspx");
            //用户订单信息
            routes.MapPageRoute("UserOrderInfo", "UserCenter/UserOrderInfo", "~/UserCenter/UserOrderInfo.aspx");
            //激活用户
            routes.MapPageRoute("ActiveUser", "UserCenter/{SearchParm}", "~/ActiveUser.aspx");
            #endregion

            #region 订单
            routes.MapPageRoute("AddShoppingCart", "ShoppingCart/{ID}", "~/Order/AddShoppingCart.aspx", true, new RouteValueDictionary { { "{ID}", "1" } }, new RouteValueDictionary { { "ID", "([0-9])+" } });//添加到购物车
            routes.MapPageRoute("ShoppingBuy", "Buy/{ID}", "~/Order/ShoppingBuy.aspx", true, new RouteValueDictionary { { "{ID}", "1" } }, new RouteValueDictionary { { "ID", "([0-9])+" } });//付款前确认商品
            routes.MapPageRoute("Pay", "ConformPay", "~/Order/Pay.aspx");//支付

            routes.MapPageRoute("PayResult", "PayResult", "~/Order/PayResult.aspx");//支付

            routes.MapPageRoute("BuyRemove", "BuyRemove/{ID}", "~/Order/BuyRemove.aspx", true, new RouteValueDictionary { { "{ID}", "1" } }, new RouteValueDictionary { { "ID", "([0-9])+" } });//从购物车内移除商品
            routes.MapPageRoute("ChangeState", "UserCenter/{State}/{ID}", "~/UserCenter/ChangeState.aspx", true, new RouteValueDictionary { { "{ID}", "1" } }, new RouteValueDictionary { { "ID", "([0-9])+" }, { "State", "\\w+" } });//更新商品状态（如、确认收货、申请退货）
            #endregion

            #region 产品
            routes.MapPageRoute("ProductListPage", "{ClassName}/Page{Page}", "~/Default.aspx", true, new RouteValueDictionary { { "ClassName", "" }, { "{Page}", "1" } }, new RouteValueDictionary { { "ClassName", "([a-z]|[A-Z]|[0-9])+" }, { "Page", "([0-9])+" } });//所有产品列表

            routes.MapPageRoute("ProductListPageByCategory", "{ClassName}/Category{Category}", "~/Default.aspx", true, new RouteValueDictionary { { "ClassName", "" }, { "Category", "" } }, new RouteValueDictionary { { "ClassName", "([a-z]|[A-Z]|[0-9])+" }, { "Category", "\\d+" }});//按类别分类产品列表首页

            routes.MapPageRoute("ProductListPageByCategoryPage", "{ClassName}/Category{Category}/Page{Page}", "~/Default.aspx", true, new RouteValueDictionary { { "ClassName", "" }, { "Category", "" }, { "{Page}", "1" } }, new RouteValueDictionary { { "ClassName", "([a-z]|[A-Z]|[0-9])+" }, { "Category", "\\d+" }, { "Page", "([0-9])+" } });//按类别分类产品分页列表

            routes.MapPageRoute("ProductShowInfo", "{ClassName}/Category{Category}/Show{ContentId}", "~/Default.aspx", true, new RouteValueDictionary { { "ClassName", "" }, { "Category", "" }, { "{ContentId}", "1" } }, new RouteValueDictionary { { "ClassName", "([a-z]|[A-Z]|[0-9])+" }, { "Category", "\\d+" }, { "ContentId", "([0-9])+" } });//产品详细页
            #endregion

            #region QQ设置
            routes.MapPageRoute("QQInfo", "QQ/GetInfo/{SearchParm}", "~/Shared/QQInfo.aspx");

            routes.MapPageRoute("QQCallBack", "QQ/CallBack/{OpenId}/{NickName}/{TimeSapn}/{Pic}/{Sign}", "~/Shared/QQCallBack.aspx");
            #endregion

            #region 文章管理
            //全站搜索
            routes.MapPageRoute("Search", "Search", "~/GetSearchPar.aspx");//搜索表单提交处理页面
            routes.MapPageRoute("ShowSearch", "ShowSearch/{SearchParm}", "~/Search.aspx");
            routes.MapPageRoute("ShowSearchByPage", "ShowSearch/{SearchParm}/{Page}", "~/Search.aspx");

            //文章类列表和详细页
            routes.MapPageRoute("","Category/{action}/{categoryName}","~/categoriespage.aspx", true, new RouteValueDictionary { { "categoryName", "food" }, { "action", "show" } });
            routes.MapPageRoute("List", "{ClassName}", "~/Default.aspx", true, new RouteValueDictionary { { "ClassName", "" } }, new RouteValueDictionary { { "ClassName", "([a-z]|[A-Z]|[0-9])+" } });
            routes.MapPageRoute("ListPage", "{ClassName}/{Page}", "~/Default.aspx", true, new RouteValueDictionary { { "ClassName", "" }, { "{Page}", "1" } }, new RouteValueDictionary { { "ClassName", "([a-z]|[A-Z]|[0-9])+" }, { "Page", "([0-9])+" } });
            routes.MapPageRoute("ShowInfo", "{ClassName}/Show_{ContentId}", "~/Default.aspx");

            routes.MapPageRoute("Template", "Template/{Template}", "~/Template.aspx");
            //routes.MapPageRoute("Template", "{Template}", "~/Template.aspx", true, new RouteValueDictionary { { "Template", "" } }, new RouteValueDictionary { { "Template", "Template/(.*?)" } });
            routes.MapPageRoute("MoveAD", "Script_AD/AD_Move", "~/AD_Move.aspx");
            #endregion

            #region 后台路由设置
            //routes.MapPageRoute("ManagerLogion", "Manager", "~/Manager/Login.aspx");
            #endregion
        }

        void Application_End(object sender, EventArgs e)
        {
            //  在应用程序关闭时运行的代码

        }

        void Application_Error(object sender, EventArgs e)
        {
            // 在出现未处理的错误时运行的代码

        }

        void Session_Start(object sender, EventArgs e)
        {
            // 在新会话启动时运行的代码

        }

        void Session_End(object sender, EventArgs e)
        {
            // 在会话结束时运行的代码。 
            // 注意: 只有在 Web.config 文件中的 sessionstate 模式设置为
            // InProc 时，才会引发 Session_End 事件。如果会话模式设置为 StateServer 
            // 或 SQLServer，则不会引发该事件。

        }

    }
}
