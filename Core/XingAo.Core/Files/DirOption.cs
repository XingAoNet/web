/******************************************************************
* Create By:陈成杰
* Create Time:2014-07-29 01:36:11
* Update By:
* Last Update Time:
* Update Description:
******************************************************************/
using System.IO;

namespace XingAo.Core
{
    /// <summary>
    /// 文件夹（目录）操作类
    /// </summary>
    public static class DirOption
    {
        /// <summary>
        /// 取指定目录下的 子级目录
        /// </summary>
        /// <param name="directory">目录相对或绝对路径</param>
        /// <returns></returns>
        public static string[] GetAllDir(string directory)
        {
            directory = FileOption.GetAbslutionPath(directory);
            if (Directory.Exists(directory))//如果目录存在            
                return Directory.GetDirectories(directory);
            return null;
        }
    }
}
