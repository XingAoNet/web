using System.Web.UI;

namespace XingAo.Core
{
    /// <summary>
    /// 从路由表中取信息相关参数
    /// </summary>
    public  class GetRouteData : Page
    {
        /// <summary>
        /// 从路由表中取栏目英文名（不存在时返回空）
        /// </summary>
        /// <returns></returns>
        public string GetClassName()
        {
            return GetClassName(true);

        }
        /// <summary>
        /// 从路由表中取栏目英文名（不存在时返回空）
        /// </summary>
        /// <param name="FilterParameter">是否过滤sql关键字</param>
        /// <returns></returns>
        public string GetClassName(bool FilterParameter)
        {
            string v = RouteData.Values["ClassName"].ObjToStr(); 
            if (FilterParameter)
                v = StringOption.FilterParameters(v);
            return v;
        }
        /// <summary>
        /// 从路由表中取某参数值
        /// </summary>
        /// <param name="name">参数名称</param>
        /// <returns></returns>
        public string GetRouteValue(string name)
        {
            return RouteData.Values[name].ObjToStr();
        }

        /// <summary>
        /// 从路由表中取id（不存在时返回-1）
        /// </summary>
        /// <returns></returns>
        public int GetContnetID()
        {
            return RouteData.Values["ContentId"].ObjToInt();
        }      
        /// <summary>
        /// 取当前页码（不存在时返回1）
        /// </summary>
        /// <returns></returns>
        public int GetPage()
        {
            int page = RouteData.Values["Page"].ObjToInt(1);
            if (page <= 0)
                page = 1;
            return page;

        }
        /// <summary>
        /// 取搜索参数集(不存在时返回空,并带有简单sql注入过滤)
        /// </summary>
        /// <returns></returns>
        public string GetSearchParm()
        {
            string v= RouteData.Values["SearchParm"].ObjToStr();
                v = StringOption.FilterParameters(v);
            return v;
        }
    }
}
