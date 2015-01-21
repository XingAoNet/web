/******************************************************************
* Create By:卢小阳
* Create Time:2013/8/21 12:18:57
* Update By:
* Last Update Time:
* Update Description:
******************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Web;
using System.IO;
namespace XingAo.Networks.CMS.Common
{
    /// <summary>
    /// 文件操作类
    /// </summary>
    public static class FileOption
    {
        #region-----------操作XML文件-----------------------------------------------------

        #region-----------读XML文件-----------------------------------------------------
        /// <summary>
        /// 读取双节点xml
        /// </summary>
        /// <param name="XmlFilePath">xml文件相对或绝对路径</param>
        /// <param name="strNode">节点名</param>
        /// <param name="strAttribute">子节点名</param>
        /// <returns></returns>
        public static string GetXmlValue(string XmlFilePath, string strNode, string strAttribute)
        {
            if (XmlFilePath.IndexOf(":\\") < 0)//如果是绝对路径
            {
                XmlFilePath = HttpContext.Current.Server.MapPath(XmlFilePath);
            }            
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(XmlFilePath);
            try
            {
                XmlNode node = xmlDoc.SelectSingleNode(strNode);
                return node.SelectSingleNode(strAttribute).InnerText;
            }
            catch (XmlException err)
            { throw err; }            
        }
        /// <summary>
        /// 读取xml配置（单节点）
        /// </summary>
        /// <param name="strNode">节点名</param>
        /// <param name="XMLpath">xml文件的相对或绝对路径</param>
        /// <returns></returns>
        public static string GetXmlValue(string strNode, string XMLpath)
        {
            string strReturn = "";
            XmlDocument xmlDoc = new XmlDocument();
            if (XMLpath.IndexOf(":\\") > 0)//如果是绝对路径
            {
                xmlDoc.Load(XMLpath);
            }
            else
            {
                xmlDoc.Load(System.Web.HttpContext.Current.Server.MapPath(XMLpath));
            }

            try
            {
                //根据路径获取节点
                XmlNode xmlNode = xmlDoc.SelectSingleNode(strNode);
                strReturn = xmlNode.InnerText;
            }
            catch (XmlException xmle)
            {
                throw xmle;
            }            
            return strReturn;
        }
        #endregion-----

        #region-----------写XML文件-----------------------------------------------------
        
        /// <summary>
        /// 双层不重复名称
        /// </summary>
        /// <param name="XmlNodeName">节点 /a/b(不能以/结尾，如果节点不存在则自动创建节点)</param>
        /// <param name="value">值</param>
        /// <param name="path">xml的相对或绝对路径</param>
        public static void SaveXml(string XmlNodeName,string value, string path)
        {
            if (path.IndexOf(":") == -1)
            {
                if (path.StartsWith("/"))
                    path = "~" + path;
                path = HttpContext.Current.Server.MapPath(path);
            }
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(path);
            /////////////////////////////////////////////////////////////////////////////////////////
            try
            {
                XmlNode node = xmlDoc.SelectSingleNode(XmlNodeName);
                node.InnerText = value;
            }
            catch
            {
                string[] name = XmlNodeName.Split('/');
                string m = name[name.Length - 1];
                string x ="" ;
                for (int i=0;i<name.Length-1;i++)
                {
                    x += "/"+name[i] ;
                }
                XmlNode root = xmlDoc.SelectSingleNode(x);//查找
                XmlElement xe1 = xmlDoc.CreateElement(m);//创建一个节点
                xe1.InnerText = value;
                root.AppendChild(xe1);
            }
           xmlDoc.Save(path);           

        }

        #endregion------
        #endregion------

        #region-----------操作文件-----------------------------------------------------
        /// <summary>
        /// 读文件
        /// </summary>
        /// <param name="path">文件相对或绝对路径(带文件名)</param>
        /// <returns></returns>
        public static string ReadFile(string path)
        {
            if (path.IndexOf(":\\") < 0)//如果是绝对路径
            {
                path = HttpContext.Current.Server.MapPath(path);
            }
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
        public static void WriteFile(string path,string Content,bool AppEnd)
        {
            if (path.IndexOf(":\\") < 0)//如果是绝对路径
            {
                path = HttpContext.Current.Server.MapPath(path);
            }  
            
            FileMode f=FileMode.Create;
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
            FileStream fs=null;
            StreamWriter sr=null;
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
                if(sr!=null)
                sr.Close();
                if(fs!=null)
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
            if (path.IndexOf(":\\") < 0)
            {
                if (path.StartsWith("/"))
                    path = "~" + path;
                path = HttpContext.Current.Server.MapPath(path);
            }
            if (File.Exists(path))//如果文件存在
            {
                try
                {
                    File.Delete(path);
                }
                catch (ArgumentException err)
                { throw err; }
            }
        }
        /// <summary>
        /// 删除指定目录下的所有文件
        /// </summary>
        /// <param name="directory">目录相对或绝对路径</param>
        public static void DelFileInDirectory(string directory)
        {
            if (directory.IndexOf(":\\") < 0)
            {
                directory = HttpContext.Current.Server.MapPath(directory);
            }
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
            if (directory.IndexOf(":\\") < 0)
            {
                directory = HttpContext.Current.Server.MapPath(directory);
            }
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
        public static bool ReNameFile(string Path,string destFileName)
        {
            if (Path.IndexOf(":\\") < 0)
            {
                Path = HttpContext.Current.Server.MapPath(Path);
            }
            if (destFileName.IndexOf(":\\") < 0)
            {
                destFileName = HttpContext.Current.Server.MapPath(destFileName);
            }
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

        #region-----------操作目录-----------------------------------------------------
        /// <summary>
        /// 取指定目录下的 子级目录
        /// </summary>
        /// <param name="directory">目录相对或绝对路径</param>
        /// <returns></returns>
        public static string[] GetAllDir(string directory)
        {
            if (directory.IndexOf(":\\") < 0)
            {
                directory = HttpContext.Current.Server.MapPath(directory);
            }
            if (Directory.Exists(directory))//如果目录存在            
                return Directory.GetDirectories(directory);
            return null;
        }
        #endregion------

        #region-----------文件转成流下载--------------------------------------------------
        /// <summary>
        /// 下载文件隐藏下载地址（转成流下载）
        /// </summary>
        /// <param name="FileName">文件相对路径</param>
        public static void DownFile(string FileName)
        {
            string filename = FileName;
            if (filename != "")
            {
                string path = HttpContext.Current.Server.MapPath(filename);
                FileInfo file = new FileInfo(path);
                if (file.Exists)
                {
                    HttpContext.Current.Response.Clear(); ;
                    HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=" + file.Name);
                    HttpContext.Current.Response.AddHeader("Content-Length", file.Length.ToString());
                    HttpContext.Current.Response.ContentType = "application/octet-stream";
                    HttpContext.Current.Response.WriteFile(file.FullName);
                    HttpContext.Current.Response.End();
                }
                else
                {
                    throw new Exception(path + "文件不存在！");
                }
            }
        }
        #endregion
    }
}
