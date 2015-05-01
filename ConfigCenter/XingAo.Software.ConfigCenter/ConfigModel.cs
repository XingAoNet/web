/*=================================
//  模块：XingAo_SysConfigs_Setting实体
//  创建者：ccj
//  创建时间：2015/4/16
//  描述：：XingAo_SysConfigs_Setting
//  生成模板来源：Networks.CMS.Model_V1.3.cmt
=================================*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.Composition;
using XingAo.Core.Data;

namespace XingAo.Software.ConfigCenter
{
    /// <summary>
    ///表名：XingAo_SysConfigs_Setting的实体
    /// </summary>	
    [Table("XingAo_SysConfigs_Setting")]//数据库真实表名
    public partial class SettingModel
    {
        /// <summary>
        /// 主键站点配置信息
        /// </summary>	
        [Key, Column("UId", Order = 1)]
        [DisplayName("编号")]
        public int UId
        {
            get;
            set;
        }
        /// <summary>
        /// Name
        /// </summary>	
        [Column("Name")] //数据库真实字段名
        [DisplayName("Name")]
        public string Name
        {
            get;
            set;
        }
        /// <summary>
        /// Value
        /// </summary>	
        [Column("Value")] //数据库真实字段名
        [DisplayName("Value")]
        public string Value
        {
            get;
            set;
        }
        /// <summary>
        /// CreateTime
        /// </summary>	
        [Column("CreateTime")] //数据库真实字段名
        [DisplayName("CreateTime")]
        public DateTime CreateTime
        {
            get;
            set;
        }
    }

}


namespace XingAo.Software.ConfigCenter.Mappings
{
    /// <summary>
    /// 实体映射表
    /// </summary>
    [Export("SettingMapping")]
    public partial class SettingMapping : MappingBase<SettingModel>
    {
        /// <summary>
        /// 实体映射表名及表间关系
        /// </summary>
        public SettingMapping()
        {
            //实体映射表名
            this.ToTable("XingAo_SysConfigs_Setting");
        }
    }
}