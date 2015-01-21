/*=================================
//  模块：XA_CMS_Advertising实体
//  创建者：Lu
//  创建时间：2013-10-19
=================================*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace XingAo.Networks.CMS.Model
{
    /// <summary>
    ///表名：广告表  的实体
    /// </summary>	
    [Table("XA_CMS_Advertising")]
    public class Advertising
    {
        /// <summary>
        /// 内部自增标识ID
        /// </summary>	
        [Key, Column("ID", Order = 1)]
        [DisplayName("编号")]
        public int ID
        {
            get;
            set;
        }


        /// <summary>
        /// 所属分组id
        /// </summary>	
        [Column("GroupID")]
        [DisplayName("所属分组id")]
        public int GroupID
        {
            get;
            set;
        }


        /// <summary>
        /// 广告名称
        /// </summary>	
        [Column("Title")]
        [DisplayName("广告名称")]
        public string Title
        {
            get;
            set;
        }

        /// <summary>
        /// 广告内容（使用编辑器来编辑一个或多个广告信息）
        /// </summary>	
        [Column("Html")]
        [DisplayName("广告内容（使用编辑器来编辑一个或多个广告信息）")]
        public string Html
        {
            get;
            set;
        }


        /// <summary>
        /// 显示方式:0--普通 1-固定浮动式 2-全屏飘浮式
        /// </summary>	
        [Column("ShowType")]
        [DisplayName("显示方式:0--普通 1-固定浮动式 2-全屏飘浮式")]
        public int ShowType
        {
            get;
            set;
        }


        /// <summary>
        /// 广告其它配置参数json字符串
        /// </summary>	
        [Column("ParametersJson")]
        [DisplayName("广告其它配置参数json字符串")]
        public string ParametersJson
        {
            get;
            set;
        }


        /// <summary>
        /// 引用js文件路径
        /// </summary>	
        [Column("JsFile")]
        [DisplayName("引用js文件路径")]
        public string JsFile
        {
            get;
            set;
        }
        /// <summary>
        /// 当前广告数据所属分组信息
        /// </summary>
        public virtual AdvertisingGroup Groups { get; set; }
    }
}