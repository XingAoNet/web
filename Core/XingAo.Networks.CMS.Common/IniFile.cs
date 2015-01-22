﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace XingAo.Networks.CMS.Common
{
    
     /// <summary>
     /// INI文件的操作类
     /// </summary>
    public class IniFile
    {
        [DllImport("kernel32")] 
private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);

        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string defVal, StringBuilder retVal, int size, string filePath); 

        public string Path;

        public IniFile(string path)
        {
            this.Path = path;
        }
        
        //声明读写INI文件的API函数

        /// <summary>
        /// 写INI文件
        /// </summary>
        /// <param name="section">段落</param>
        /// <param name="key">键</param>
        /// <param name="iValue">值</param>
        public void IniWriteValue(string section, string key, string iValue) 
        {
            WritePrivateProfileString(section, key, iValue, this.Path);
        }

        /// <summary>
        /// 读取INI文件
        /// </summary>
        /// <param name="section">段落</param>
        /// <param name="key">键</param>
        /// <returns>返回的键值</returns>
        public string IniReadValue(string section, string key) 
        { 
            StringBuilder temp = new StringBuilder(255); 

            int i = GetPrivateProfileString(section, key, "", temp, 255, this.Path); 
            return temp.ToString();
        }

        /// <summary>
       /// 读取INI文件
        /// </summary>
       /// <param name="Section">段，格式[]</param>
       /// <param name="Key">键</param>
       /// <returns>返回byte类型的section组或键值组</returns>
        public byte[] IniReadValues(string section, string key)
        {
            StringBuilder temp = new StringBuilder(255); 
            int i = GetPrivateProfileString(section, key, "", temp, 255, this.Path); 
            return Encoding.Default.GetBytes(temp.ToString());
        }
    }
}