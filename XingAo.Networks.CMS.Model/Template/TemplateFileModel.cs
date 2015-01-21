/******************************************************************
* Create By:陈成杰
* Create Time:2014-06-30 09:52:54
* Update By:
* Last Update Time:
* Update Description:
* 描述 ：模板中的文件管理（包括css文件、HTML文件等）
******************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.Composition;
using XingAo.Core.Data;

namespace XingAo.Networks.CMS.Model
{
    /// <summary>
    ///表名：模板中的文件管理（包括css文件、HTML文件等）的实体
    /// </summary>	
    [Table("XA_Template_File")]//数据库真实表名
    public partial class TemplateFileModel
    {
        /// <summary>
        /// 主键ID
        /// </summary>	
        [Key, Column("ID", Order = 1)]
        [DisplayName("编号")]
        public int ID
        {
            get;
            set;
        }
        /// <summary>
        /// 文件名称
        /// </summary>	
        [Column("FileName")] //数据库真实字段名
        [DisplayName("文件名称")]
        public string FileName
        {
            get;
            set;
        }
        /// <summary>
        /// 文件描述
        /// </summary>	
        [Column("FileDiscrption")] //数据库真实字段名
        [DisplayName("文件描述")]
        public string FileDiscrption
        {
            get;
            set;
        }
        /// <summary>
        /// 文件路径
        /// </summary>	
        [Column("DirPath")] //数据库真实字段名
        [DisplayName("文件路径")]
        public string DirPath
        {
            get;
            set;
        }
        /// <summary>
        /// 创建人
        /// </summary>	
        [Column("CreateUser")] //数据库真实字段名
        [DisplayName("创建人")]
        public string CreateUser
        {
            get;
            set;
        }
        /// <summary>
        /// 创建人编号
        /// </summary>	
        [Column("CreateUserId")] //数据库真实字段名
        [DisplayName("创建人编号")]
        public int CreateUserId
        {
            get;
            set;
        }
        /// <summary>
        /// 最后一次修改人名称
        /// </summary>	
        [Column("ModifyUser")] //数据库真实字段名
        [DisplayName("最后一次修改人名称")]
        public string ModifyUser
        {
            get;
            set;
        }
        /// <summary>
        /// 最后一次修改人编号
        /// </summary>	
        [Column("ModifyUserId")] //数据库真实字段名
        [DisplayName("最后一次修改人编号")]
        public int ModifyUserId
        {
            get;
            set;
        }
        /// <summary>
        /// 创建时间
        /// </summary>	
        [Column("CreateTime")] //数据库真实字段名
        [DisplayName("创建时间")]
        public DateTime CreateTime
        {
            get;
            set;
        }
        /// <summary>
        /// 最后一次修改时间
        /// </summary>	
        [Column("ModifyTime")] //数据库真实字段名
        [DisplayName("最后一次修改时间")]
        public DateTime ModifyTime
        {
            get;
            set;
        }
        /// <summary>
        /// 版本信息
        /// </summary>	
        [Column("HistoryVision")] //数据库真实字段名
        [DisplayName("版本信息")]
        public decimal HistoryVision
        {
            get;
            set;
        }
        /// <summary>
        /// 文件类型
        /// </summary>	
        [Column("FileType")] //数据库真实字段名
        [DisplayName("文件类型")]
        public string FileType
        {
            get;
            set;
        }
        /// <summary>
        /// 文件大小
        /// </summary>	
        [Column("FileLength")] //数据库真实字段名
        [DisplayName("文件大小")]
        public int FileLength
        {
            get;
            set;
        }
    }

}

namespace XingAo.Networks.CMS.Model.Mappings//所有映射
{
    /// <summary>
    /// 实体映射表
    /// </summary>
    [Export("Template_FileMapping")]
    public partial class Template_FileMapping : MappingBase<Model.TemplateFileModel>
    {
        /// <summary>
        /// 实体映射表名及表间关系
        /// </summary>
        public Template_FileMapping()
        {
            //实体映射表名
            this.ToTable("XA_Template_File");
            //表间关系映射

        }
    }
}