/******************************************************************
* Create By:陈成杰
* Create Time:2014-07-29 00:15:55
* Update By:获取HTTP相关信息，同XingAo.Networks.WeChat下的NetHelperHttp类
* Last Update Time:
* Update Description:
******************************************************************/
using System.Text;
using System.Net;
using System.IO;

namespace XingAo.Core
{
    /// <summary>
    /// 编码方式
    /// </summary>
    public enum EncodeFormat : int
    {
        EF_GB2312,
        EF_UTF8,
        EF_UTF7,
        EF_UTF32,
        EF_UNICODE
    }

    /// <summary>
    /// 获取HTTP相关信息，同XingAo.Networks.WeChat下的NetHelperHttp类
    /// </summary>
    public static class HttpHelper
    {
        /// <summary>
        /// 获取HTTP的GET方式的响应
        /// </summary>
        /// <param name="url">GET方式的响应地址</param>
        /// <param name="data">提交的GET请求所需的数据，数据格式为a=adata&b=bdata,a为参数一，b为参数二</param>
        /// <param name="ef">编码方式，根据响应页面的编码方式提交</param>
        /// <param name="result">返回的结果，当错误时，返回异常信息</param>
        /// <returns>响应结果的状态，默认成功为200,详细参考System.Net.HttpStatusCode枚举类</returns>
        public static int HttpGet(string url, string data, EncodeFormat ef, out string result)
        {
            try
            {
                url = url + "?" + data;
                HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(url);
                WebReq.Method = "GET";
                WebReq.ContentType = "application/x-www-form-urlencoded";
                HttpWebResponse WebResp = (HttpWebResponse)WebReq.GetResponse();
                Stream Answer = WebResp.GetResponseStream();
                result = getResult(Answer, ef);
                return (int)WebResp.StatusCode;
            }
            catch (System.Exception ex)
            {
                result = ex.Message;
                return 0;
            }
        }
        /// <summary>
        /// 获取HTTP的POST方式的响应
        /// </summary>
        /// <param name="url">POST的响应地址</param>
        /// <param name="data">提交的POST请求所需的数据，数据格式为a=adata&b=bdata,a为参数一，b为参数二</param>
        /// <param name="ef">编码方式，根据响应页面的编码方式提交</param>
        /// <param name="result">返回的结果，当错误时，返回异常信息</param>
        /// <returns>响应结果的状态，默认成功为200,详细参考System.Net.HttpStatusCode枚举类</returns>
        public static int HttpPost(string url, string data, EncodeFormat ef, out string result)
        {
            try
            {
                byte[] bData = getBytesByEncodeFormat(data, ef);
                HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(url);
                WebReq.Method = "POST";
                WebReq.ContentType = "application/x-www-form-urlencoded";
                WebReq.ContentLength = bData.Length;
                Stream PostData = WebReq.GetRequestStream();
                PostData.Write(bData, 0, bData.Length);
                PostData.Close();
                HttpWebResponse WebResp = (HttpWebResponse)WebReq.GetResponse();
                Stream Answer = WebResp.GetResponseStream();
                result = getResult(Answer, ef);
                return (int)WebResp.StatusCode;
            }
            catch (System.Exception ex)
            {
                result = ex.Message;
                return 0;
            }
        }
        /// <summary>
        /// 获取响应结果
        /// </summary>
        /// <param name="ret">响应结果流</param>
        /// <param name="ef">响应页面的编码方式</param>
        /// <returns></returns>
        public static string getResult(Stream ret, EncodeFormat ef)
        {
            StreamReader _Answer = new StreamReader(ret, getActrualEncoding(ef));
            string retStr = _Answer.ReadToEnd();
            return retStr;
        }
        /// <summary>
        /// 根据枚举获取编码方式
        /// </summary>
        /// <param name="ef">编码枚举类</param>
        /// <returns>返回编码方式</returns>
        public static Encoding getActrualEncoding(EncodeFormat ef)
        {
            switch (ef)
            {
                case EncodeFormat.EF_GB2312:
                    {
                        return Encoding.GetEncoding("gb2312");
                    }
                case EncodeFormat.EF_UNICODE:
                    {
                        return Encoding.Unicode;
                    }
                case EncodeFormat.EF_UTF32:
                    {
                        return Encoding.UTF32;
                    }
                case EncodeFormat.EF_UTF7:
                    {
                        return Encoding.UTF7;
                    }
                case EncodeFormat.EF_UTF8:
                    {
                        return Encoding.UTF8;
                    }
                default:
                    return Encoding.Default;
            }
        }
        /// <summary>
        /// 根据编码方式将字符串转换成字节序列
        /// </summary>
        /// <param name="source">需要转变的字符串</param>
        /// <param name="ef">编码方式</param>
        /// <returns>转换后的字节序列</returns>
        public static byte[] getBytesByEncodeFormat(string source, EncodeFormat ef)
        {
            Encoding encoding = getActrualEncoding(ef);
            return encoding.GetBytes(source);
        }
    }
}
