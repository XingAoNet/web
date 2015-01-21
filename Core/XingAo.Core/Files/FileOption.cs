/******************************************************************
* Create By:陈成杰
* Create Time:2014-07-29 01:13:26
* Update By:
* Last Update Time:
* Update Description:
******************************************************************/
using System;
using System.IO;

namespace XingAo.Core
{
    /// <summary>
    /// 文件的基础操作类
    /// </summary>
    public class FileOption
    {
        /// <summary>
        /// 获取文件或目录的绝度路径
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string GetAbslutionPath(string path)
        {
            //判断是否为绝对路径，大于0时为绝度路径，小于0时为相对路径
            if (path.IndexOf(":\\") < 0)
            {
                if(path.IndexOf("\\")<0)
                    path = string.Format(@"\{0}",path);
                path = string.Format("{0}{1}",AppDomain.CurrentDomain.BaseDirectory,path);
            }
            return path;
        }
        #region-----------操作文件-----------------------------------------------------
        /// <summary>
        /// 读文件
        /// </summary>
        /// <param name="path">文件相对或绝对路径(带文件名)</param>
        /// <returns></returns>
        public static string ReadFile(string path)
        {
            path = GetAbslutionPath(path);
            if (!File.Exists(path))
                return path + "文件不存在！";
            FileStream fs = new FileStream(path, FileMode.Open);
            StreamReader sr = new StreamReader(fs);
            string s = sr.ReadToEnd();
            sr.Close();
            fs.Close();

            return s;
        }
        /// <summary>
        /// 写文件
        /// </summary>
        /// <param name="path">文件相对或绝对路径(带文件名)</param>
        /// <param name="Content">要写入的内容</param>
        /// <param name="AppEnd">如果文件存在是不是在原有内容上添加,否则覆盖文件</param>
        public static void WriteFile(string path, string Content, bool AppEnd)
        {
            path = GetAbslutionPath(path);

            FileMode f = FileMode.Create;
            if (File.Exists(path))
            {
                if (AppEnd)
                    f = FileMode.Append;
            }
            else
            {
                FileInfo fi = new FileInfo(path);
                if (!fi.Directory.Exists)
                {
                    Directory.CreateDirectory(fi.Directory.FullName);
                }
            }
            FileStream fs = null;
            StreamWriter sr = null;
            try
            {
                fs = new FileStream(path, f);
                sr = new StreamWriter(fs);
                sr.Write(Content);

            }
            catch (IOException err)
            { throw err; }
            finally
            {
                if (sr != null)
                    sr.Close();
                if (fs != null)
                    fs.Close();
            }

        }
        /// <summary>
        /// 删除指定文件（如果文件存在时）
        /// </summary>
        /// <param name="path">文件相对或绝对路径(多个文件以符号间隔)</param>
        /// <param name="f">间隔符</param>
        public static void DelFile(string path, char f)
        {
            string[] filePath = path.Split(f);
            foreach (string file in filePath)
            {
                DelFile(file);
            }
        }
        /// <summary>
        /// 删除指定文件（如果文件存在时）
        /// </summary>
        /// <param name="path">文件相对或绝对路径</param>
        public static void DelFile(string path)
        {
            path = GetAbslutionPath(path);
            if (File.Exists(path))//如果文件存在
            {
                try
                {
                    File.Delete(path);
                }
                catch (Exception err)
                { throw err; }
            }
        }
        /// <summary>
        /// 删除指定目录下的所有文件
        /// </summary>
        /// <param name="directory">目录相对或绝对路径</param>
        public static void DelFileInDirectory(string directory)
        {
            directory = GetAbslutionPath(directory);
            if (Directory.Exists(directory))//如果目录存在
            {
                string[] files = Directory.GetFiles(directory);
                foreach (string file in files)
                {
                    DelFile(file);
                }
            }
        }
        /// <summary>
        /// 取指定目录下的 所有文件
        /// </summary>
        /// <param name="directory">目录相对或绝对路径</param>
        /// <returns></returns>
        public static string[] GetAllFile(string directory)
        {
            directory = GetAbslutionPath(directory);
            if (Directory.Exists(directory))//如果目录存在            
                return Directory.GetFiles(directory);
            return null;
        }
        /// <summary>
        /// 重命名文件
        /// </summary>
        /// <param name="Path">源文件</param>
        /// <param name="destFileName">目标文件名</param>
        /// <returns>是否成功</returns>
        public static bool ReNameFile(string Path, string destFileName)
        {
            Path = GetAbslutionPath(Path);
            destFileName = GetAbslutionPath(destFileName);
            if (File.Exists(Path))
            {
                try
                {
                    File.Move(Path, destFileName);
                    return true;
                }
                catch { return false; }
            }
            return false;
        }
        #endregion------

    }
}
