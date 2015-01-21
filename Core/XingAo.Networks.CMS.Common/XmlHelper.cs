using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Data;

namespace XingAo.Networks.CMS.Common
{
    public class XmlHelper
    {
        public static XmlDocument GetXml(DataTable dt)
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
