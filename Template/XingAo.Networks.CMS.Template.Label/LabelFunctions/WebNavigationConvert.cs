using System;
using System.Linq.Expressions;
using XingAo.Core;
using XingAo.Core.Data;

namespace XingAo.Networks.CMS.Template.Label.LabelFunctions
{
    /// <summary>
    /// 栏目相关属性值相互转换
    /// </summary>
    public static class WebNavigationConvert
    {
        #region 栏目id、中文名、英文名、编码之间相互转换
        /// <summary>
        /// 栏目相关属性值 相互转换的缓存值
        /// </summary>
        /// <param name="navinfo"></param>
        private static void SetExchange(Model.WebNavigation navinfo)
        {
            if (navinfo != null && navinfo.ID > 0)
            {
                string Code = navinfo.Code;
                string id = navinfo.ID.ToString();
                navinfo.Code.SetCache("IDToCode" + id, 999999, DataCache.DataCacheType.ColumnAttExchange);
                navinfo.Name.SetCache("IDToName" + id, 999999, DataCache.DataCacheType.ColumnAttExchange);
                navinfo.EName.SetCache("IDToEName" + id, 999999, DataCache.DataCacheType.ColumnAttExchange);
                ///////////////////
                navinfo.ID.SetCache("CodeToID" + Code, 999999, DataCache.DataCacheType.ColumnAttExchange);
                navinfo.Name.SetCache("CodeToName" + Code, 999999, DataCache.DataCacheType.ColumnAttExchange);
                navinfo.EName.SetCache("CodeToEName" + Code, 999999, DataCache.DataCacheType.ColumnAttExchange);
                ///////////////////
                //string name = navinfo.Name;
                //navinfo.ID.SetCache("NameToID" + name, 999999, DataCache.DataCacheType.ColumnAttExchange);
                //navinfo.EName.SetCache("NameToEName" + name, 999999, DataCache.DataCacheType.ColumnAttExchange);
                //navinfo.Code.SetCache("NameToCode" + name, 999999, DataCache.DataCacheType.ColumnAttExchange);
                //因name值可能会在不同的子栏目上出现重复，特取消使用name值来转换成其它值，帮注释以上代码
                ///////////////////
                string ename = navinfo.EName;
                navinfo.ID.SetCache("ENameToID" + ename, 999999, DataCache.DataCacheType.ColumnAttExchange);
                navinfo.Name.SetCache("ENameToName" + ename, 999999, DataCache.DataCacheType.ColumnAttExchange);
                navinfo.Code.SetCache("ENameToCode" + ename, 999999, DataCache.DataCacheType.ColumnAttExchange);

            }
        }
        private static string AutoGetSetExchangeValue(string key, Expression<Func<Model.WebNavigation, bool>> where)
        {
            string Code = DataCache.GetCache(key, DataCache.DataCacheType.ColumnAttExchange).ObjToStr();
            if (Code == "")
            {
                Model.WebNavigation navinfo = new UnitOfWork().FindSigne<Model.WebNavigation>(where);// _BaseRepository.GetModelBySearch(where);
                SetExchange(navinfo);
                Code = DataCache.GetCache(key, DataCache.DataCacheType.ColumnAttExchange).ObjToStr();
            }
            return Code;
        }
        /// <summary>
        /// 将id转化成栏目编码
        /// </summary>
        /// <param name="id">栏目id</param>
        /// <returns></returns>
        public static string GetCodeByID(int id)
        {
            return AutoGetSetExchangeValue("IDToCode" + id.ToString(), p => p.ID == id);

        }
        /// <summary>
        /// 将栏目id转化成栏目中文名
        /// </summary>
        /// <param name="id">栏目id</param>
        /// <returns></returns>
        public static string GetNameByID(int Id)
        {
            return AutoGetSetExchangeValue("IDToName" + Id.ToString(), p => p.ID == Id);
        }
        /// <summary>
        /// 将栏目id转化成栏目英文名
        /// </summary>
        /// <param name="id">栏目id</param>
        /// <returns></returns>
        public static string GetENameByID(int Id)
        {
            return AutoGetSetExchangeValue("IDToEName" + Id.ToString(), p => p.ID == Id);
        }

        /// <summary>
        /// 将栏目id转化成栏目英文名
        /// </summary>
        /// <param name="ename">栏目英文名</param>
        /// <returns></returns>
        public static string GetNameByEName(string ename)
        {
            return AutoGetSetExchangeValue("NameToEName" + ename, p => p.EName == ename);
        }
        /// <summary>
        /// 将栏目英文名转化成栏目编码
        /// </summary>
        /// <param name="ename">栏目英文名</param>
        /// <returns></returns>
        public static string GetCodeByEName(string ename)
        {
            return AutoGetSetExchangeValue("ENameToCode" + ename, p => p.EName == ename);
        }
        /// <summary>
        /// 将栏目英文名转化成栏id
        /// </summary>
        /// <param name="ename">栏目英文名</param>
        /// <returns></returns>
        public static int GetIDByEName(string ename)
        {
            return AutoGetSetExchangeValue("ENameToID" + ename, p => p.EName == ename).ObjToInt();
        }


        /// <summary>
        /// 将栏目编码转化成栏目id
        /// </summary>
        /// <param name="code">栏目编码</param>
        /// <returns></returns>
        public static int GetIDByCode(string code)
        {
            return AutoGetSetExchangeValue("CodeToID" + code, p => p.Code == code).ObjToInt();
        }
        /// <summary>
        /// 将栏目编码转化成栏目中文名
        /// </summary>
        /// <param name="code">栏目编码</param>
        /// <returns></returns>
        public static string GetNameByCode(string code)
        {
            return AutoGetSetExchangeValue("CodeToName" + code, p => p.Code == code);
        }
        /// <summary>
        /// 将栏目编码转化成栏目英文名
        /// </summary>
        /// <param name="code">栏目编码</param>
        /// <returns></returns>
        public static string GetENameByCode(string code)
        {
            return AutoGetSetExchangeValue("CodeToEName" + code, p => p.Code == code);
        }
        #endregion
    }
}
