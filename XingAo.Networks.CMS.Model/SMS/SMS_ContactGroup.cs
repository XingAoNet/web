/*=================================
//  模块：XA_SMS_ContactGroup实体
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
    ///表名：手机短信群发联系人分组表  的实体
    /// </summary>	
    [Table("XA_SMS_ContactGroup")]
    public class SMS_ContactGroup
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
        /// 分组名称
        /// </summary>	
        [Column("GroupName")]
        [DisplayName("分组名称")]
        public string GroupName
        {
            get;
            set;
        }


        /// <summary>
        /// 分组编码
        /// </summary>	
        [Column("GroupCode")]
        [DisplayName("分组编码")]
        public string GroupCode
        {
            get;
            set;
        }

        /// <summary>
        /// 会员id
        /// </summary>	
        [Column("MembersID")]
        [DisplayName("会员id")]
        public int MembersID { get; set; }


        /// <summary>
        /// 此分组下的用户列表（此字段为多表关联用，单表操作时忽视此字段）
        /// </summary>        
        public virtual ICollection<SMS_Contact> SMS_ContactList { get; set; }
    }
}














/*=================================
//  模块：XA_SMS_ContactGroup 映射表名
//  创建者：Lu
//  创建时间：2014-1-22
=================================*/
namespace XingAo.Networks.CMS.Model.Mappings
{
    [Export("SMS_ContactGroupMapping")]
    public class SMS_ContactGroupMapping : MappingBase<SMS_ContactGroup>
    {
        public SMS_ContactGroupMapping()
        {
            //映射表名
            this.ToTable("XA_SMS_ContactGroup"); 
        }
    }
}
