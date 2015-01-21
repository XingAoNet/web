/*=================================
//  模块：XA_CMS_WebNavigation实体
//  创建者：Lu
//  创建时间：2013-9-23
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
    ///表名：网站导航(栏目)表  的实体
    /// </summary>	
    [Table("XA_CMS_WebNavigation")]
    public class WebNavigation
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
        /// 导航（栏目）名称
        /// </summary>	
        [Column("Name")]
        [DisplayName("导航（栏目）名称")]
        public string Name
        {
            get;
            set;
        }


        /// <summary>
        /// 栏目英文名，用于前台导航url生成，也用于屏蔽自增id删除后不能重建的弊端
        /// </summary>	
        [Column("EName")]
        [DisplayName("栏目英文名，用于前台导航url生成，也用于屏蔽自增id删除后不能重建的弊端")]
        public string EName
        {
            get;
            set;
        }


        /// <summary>
        /// 图片导航
        /// </summary>	
        [Column("Pic")]
        [DisplayName("图片导航")]
        public string Pic
        {
            get;
            set;
        }


        /// <summary>
        /// 图片导航(鼠标移上去时)
        /// </summary>	
        [Column("PicHover")]
        [DisplayName("图片导航(鼠标移上去时)")]
        public string PicHover
        {
            get;
            set;
        }


        /// <summary>
        /// 栏目编码，主要用于确定栏目层级关系
        /// </summary>	
        [Column("Code")]
        [DisplayName("栏目编码，主要用于确定栏目层级关系")]
        public string Code
        {
            get;
            set;
        }


        /// <summary>
        /// 栏目首页模板id
        /// </summary>	
        [Column("IndexTemplate")]
        [DisplayName("栏目首页模板id")]
        public int IndexTemplate
        {
            get;
            set;
        }


        /// <summary>
        /// 栏目列表页模板id
        /// </summary>	
        [Column("ListTemplate")]
        [DisplayName("栏目列表页模板id")]
        public int ListTemplate
        {
            get;
            set;
        }


        /// <summary>
        /// 栏目详细页模板id
        /// </summary>	
        [Column("InfoTemplate")]
        [DisplayName("栏目详细页模板id")]
        public int InfoTemplate
        {
            get;
            set;
        }


        /// <summary>
        /// 外部链接地址
        /// </summary>	
        [Column("OutLink")]
        [DisplayName("外部链接地址")]
        public string OutLink
        {
            get;
            set;
        }


        /// <summary>
        /// 链接打开方式，包括外部链接以及系统自动生成的链接
        /// </summary>	
        [Column("Target")]
        [DisplayName("链接打开方式，包括外部链接以及系统自动生成的链接")]
        public string Target
        {
            get;
            set;
        }


        /// <summary>
        /// 是否在网站顶部导航上显示此栏目
        /// </summary>	
        [Column("ShowInTopNavigation")]
        [DisplayName("是否在网站顶部导航上显示此栏目")]
        public int ShowInTopNavigation
        {
            get;
            set;
        }


        /// <summary>
        /// 是否在网站左侧导航上显示此栏目
        /// </summary>	
        [Column("ShowInLeftNavigation")]
        [DisplayName("是否在网站左侧导航上显示此栏目")]
        public int ShowInLeftNavigation
        {
            get;
            set;
        }


        /// <summary>
        /// 搜索引擎关键字（如果此栏目为首页或列表页时有效，如果当前栏目为详细页，则根据文章正文内设置的关键字来设置）
        /// </summary>	
        [Column("SearchEngineKeyWords")]
        [DisplayName("搜索引擎关键字（如果此栏目为首页或列表页时有效，如果当前栏目为详细页，则根据文章正文内设置的关键字来设置）")]
        public string SearchEngineKeyWords
        {
            get;
            set;
        }


        /// <summary>
        /// 搜索引擎描述（如果此栏目为首页或列表页时有效，如果当前栏目为详细页，则根据文章正文内设置的描述来设置）
        /// </summary>	
        [Column("SearchEngineDescription")]
        [DisplayName("搜索引擎描述（如果此栏目为首页或列表页时有效，如果当前栏目为详细页，则根据文章正文内设置的描述来设置）")]
        public string SearchEngineDescription
        {
            get;
            set;
        }
    }
}