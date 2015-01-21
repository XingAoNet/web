/******************************************************************
* Create By:陈成杰
* Create Time:2014-07-29 01:01:22
* Update By:XML文件操作
* Last Update Time:
* Update Description:
******************************************************************/
using System;
using System.Data;
using System.Xml;

namespace XingAo.Core
{
    /// <summary>
    /// XML文件操作
    /// </summary>
    public static class XMLOption
    {
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
            XmlFilePath = FileOption.GetAbslutionPath(XmlFilePath);
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
            XMLpath = FileOption.GetAbslutionPath(XMLpath);
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
        public static void SaveXml(string XmlNodeName, string value, string path)
        {
            path = FileOption.GetAbslutionPath(path);
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
                string x = "";
                for (int i = 0; i < name.Length - 1; i++)
                {
                    x += "/" + name[i];
                }
                XmlNode root = xmlDoc.SelectSingleNode(x);//查找
                XmlElement xe1 = xmlDoc.CreateElement(m);//创建一个节点
                xe1.InnerText = value;
                root.AppendChild(xe1);
            }
            xmlDoc.Save(path);

        }

        #endregion------

        /// <summary>
        /// 将数据集转换成XML形式
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static XmlDocument DataTableToXml(DataTable dt)
        {
            string strXml = @"<?xml version='1.0' encoding='UTF-8' ?><DataTable />";
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(strXml);
            XmlNode root = doc.SelectSingleNode("//DataTable");
            // 创建子节点        
            for (int j = 0; j < dt.Rows.Count; j++)
            {
                XmlElement xe = doc.CreateElement("Rows");
                XmlElement xeChild = null;
                if (!Object.Equals(dt, null))
                {
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        if (dt.Columns[i].ColumnName.StartsWith("@"))
                        {
                            string AttributeName = dt.Columns[i].ColumnName.Replace("@", "");
                            // 为该子节点设置属性        
                            xe.SetAttribute(AttributeName, dt.Rows[j][i].ToString());
                        }
                        else
                        {
                            xeChild = doc.CreateElement(dt.Columns[i].ColumnName);

                            try
                            {
                                //  xeChild.InnerXml = dt.Rows[j][i].ToString();
                                xeChild.InnerXml = "<![CDATA[" + dt.Rows[j][i].ToString() + "]]>";//.Replace("\r\n","<br />")
                            }
                            catch
                            {
                                //xeChild.InnerText = dt.Rows[j][i].ToString();
                                xeChild.InnerText = "<![CDATA[" + dt.Rows[j][i].ToString() + "]]>";
                            }
                            xe.AppendChild(xeChild);
                        }
                    }
                }
                // 保存子节点设置        
                root.AppendChild(xe);
            }
            return doc;
        }


    }
}
