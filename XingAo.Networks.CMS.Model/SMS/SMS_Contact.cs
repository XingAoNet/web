/*=================================
//  模块：XA_SMS_Contact实体
//  创建者：Lu
//  创建时间：2014-1-22
=================================*/
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
    ///表名：手机短信群发联系人表  的实体
    /// </summary>	
    [Table("XA_SMS_Contact")]
    public class SMS_Contact
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
        /// 联系人姓名
        /// </summary>	
        [Column("Name")]
        [DisplayName("联系人姓名")]
        public string Name
        {
            get;
            set;
        }


        /// <summary>
        /// 手机号码
        /// </summary>	
        [Column("Mob")]
        [DisplayName("手机号码")]
        public string Mob
        {
            get;
            set;
        }


        /// <summary>
        /// 邮箱
        /// </summary>	
        [Column("Email")]
        [DisplayName("邮箱")]
        public string Email
        {
            get;
            set;
        }


        /// <summary>
        /// 办公室电话
        /// </summary>	
        [Column("OfficeTel")]
        [DisplayName("办公室电话")]
        public string OfficeTel
        {
            get;
            set;
        }


        /// <summary>
        /// 公司名称
        /// </summary>	
        [Column("Company")]
        [DisplayName("公司名称")]
        public string Company
        {
            get;
            set;
        }


        /// <summary>
        /// 部门
        /// </summary>	
        [Column("Depart")]
        [DisplayName("部门")]
        public string Depart
        {
            get;
            set;
        }


        /// <summary>
        /// 职称
        /// </summary>	
        [Column("Title")]
        [DisplayName("职称")]
        public string Title
        {
            get;
            set;
        }
        /// <summary>
        /// 分组id
        /// </summary>	
        [Column("GroupID")]
        [DisplayName("分组id")]
        public int GroupID { get; set; }


        /// <summary>
        /// 会员id
        /// </summary>	
        [Column("MembersID")]
        [DisplayName("会员id")]
        public int MembersID { get; set; }


        /// <summary>
        /// 此用户对应的分组信息（此字段为多表关联用，单表操作时忽视此字段）
        /// </summary>        
        public virtual SMS_ContactGroup ContactGroup { get; set; }
    }
}














/*=================================
//  模块：XA_SMS_Contact 映射表名
//  创建者：Lu
//  创建时间：2014-1-22
=================================*/
namespace XingAo.Networks.CMS.Model.Mappings
{
    [Export("SMS_ContactMapping")]
    public class SMS_ContactMapping : MappingBase<SMS_Contact>
    {
        public SMS_ContactMapping()
        {
            //映射表名
            this.ToTable("XA_SMS_Contact");
            this.HasRequired(m => m.ContactGroup).WithMany(m => m.SMS_ContactList).HasForeignKey(t => t.GroupID);

        }
    }
}



