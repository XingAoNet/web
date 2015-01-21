/******************************************************************
* Create By:陈成杰
* Create Time:2014-07-29 01:29:28
* Update By:
* Last Update Time:
* Update Description:
******************************************************************/
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace XingAo.Core
{
    /// <summary>
    /// INI文件操作类
    /// </summary>
    public static class INIFileOption
    {
        //声明读写INI文件的API函数
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);

        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string defVal, StringBuilder retVal, int size, string filePath); 

        /// <summary>
        /// 写INI文件
        /// </summary>
        /// <param name="section">段落</param>
        /// <param name="key">键</param>
        /// <param name="iValue">值</param>
        public static void IniWriteValue(string section, string key, string iValue,string path) 
        {
            path = FileOption.GetAbslutionPath(path);
            if (File.Exists(path))
                WritePrivateProfileString(section, key, iValue, path);
            else
                throw new FileNotFoundException("INI文件不存在");
        }

        /// <summary>
        /// 读取INI文件
        /// </summary>
        /// <param name="section">段落</param>
        /// <param name="key">键</param>
        /// <returns>返回的键值</returns>
        public static string IniReadValue(string section, string key, string path) 
        {
            path = FileOption.GetAbslutionPath(path);
            if (File.Exists(path))
            {
                StringBuilder temp = new StringBuilder(255);

                int i = GetPrivateProfileString(section, key, "", temp, 255, path);
                return temp.ToString();
            }
            else
                throw new FileNotFoundException("INI文件不存在");
        }

        /// <summary>
        /// 读取INI文件
        /// </summary>
        /// <param name="Section">段，格式[]</param>
        /// <param name="Key">键</param>
        /// <returns>返回byte类型的section组或键值组</returns>
        public static byte[] IniReadValues(string section, string key, string path)
        {
            path = FileOption.GetAbslutionPath(path);
            if (File.Exists(path))
            {
                StringBuilder temp = new StringBuilder(255);
                int i = GetPrivateProfileString(section, key, "", temp, 255, path);
                return Encoding.Default.GetBytes(temp.ToString());
            }
            else
                throw new FileNotFoundException("INI文件不存在");
        }

    }
}
