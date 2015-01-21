using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace XingAo.Networks.CMS.Model.DatabaseModel
{
    /// <summary>
    /// 服务返回信息
    /// </summary>
    public class ServiceBackModel<T>
    {
        public ServiceBackModel()
        { }
        /// <summary>
        /// 错误信息
        /// </summary>
        public string ErrMsg { get; set; }
        /// <summary>
        /// 是否有错误
        /// </summary>
        public bool IsErr { get; set; }
        /// <summary>
        /// 返回数据
        /// </summary>
        public List<T> Data { get; set; }
        /// <summary>
        /// 返回数据条数
        /// </summary>
        public int DataCount { get; set; }
        /// <summary>
        /// 返回数据的总记录数
        /// </summary>
        public int TotalDataCount { get; set; }
        /// <summary>
        /// 服务返回信息
        /// </summary>
        /// <param name="errmsg">错误信息</param>
        /// <param name="iserr">是否有错误</param>
        /// <param name="data">返回数据</param>
        /// <param name="datacount">返回数据条数</param>
        /// <param name="totaldatacount">返回数据的总记录数</param>
        public ServiceBackModel(string errmsg, bool iserr, List<T> data, int datacount, int totaldatacount)
        {
            List<DataRow> li = new List<DataRow>();
            ErrMsg = errmsg;
            IsErr = iserr;
            Data = data;
            DataCount = datacount;
            TotalDataCount = totaldatacount;
        }
    }
}
