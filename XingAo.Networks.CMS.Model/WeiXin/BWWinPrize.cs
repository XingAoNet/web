/*=================================
//  模块：XA_BWWinPrize实体
//  创建者：Lu
//  创建时间：2013-12-21
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
    ///表名：转盘中奖表  的实体
    /// </summary>	
    [Table("XA_WeiXin_BWWinPrize")]
    public class BWWinPrize : IModel
    {
        /// <summary>
        /// 内部自增标识中奖ID
        /// </summary>	
        [Key, Column("ID", Order = 1)]
        [DisplayName("编号")]
        public int ID
        {
            get;
            set;
        }


        /// <summary>
        /// 转盘Guid
        /// </summary>	
        [Column("BGuid")]
        [DisplayName("转盘Guid")]
        public string BGuid
        {
            get;
            set;
        }


        /// <summary>
        /// 客户OpenID
        /// </summary>	
        [Column("OPenId")]
        [DisplayName("客户OpenID")]
        public string OPenId
        {
            get;
            set;
        }


        /// <summary>
        /// 奖品
        /// </summary>	
        [Column("Prize")]
        [DisplayName("奖品")]
        public string Prize
        {
            get;
            set;
        }
    }
}














/*=================================
//  模块：XA_BWWinPrize 映射表名
//  创建者：Lu
//  创建时间：2013-12-21
=================================*/
namespace XingAo.Networks.CMS.Model.Mappings
{
    [Export("BWWinPrizeMapping")]
    public class BWWinPrizeMapping : MappingBase<BWWinPrize>
    {
        public BWWinPrizeMapping()
        {
            //映射表名
            this.ToTable("XA_WeiXin_BWWinPrize");
            //this.HasRequired(m => m.Group).WithMany(m => m.Class).HasForeignKey(t => t.GroupId);
        }
    }
}
