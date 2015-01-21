/*=================================
//  模块：XA_ScratchCard_PrizesLog实体
//  创建者：Lu
//  创建时间：2013-12-2
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
    ///表名：刮刮卡中奖记录表  的实体
    /// </summary>	
    [Table("XA_WeiXin_ScratchCard_PrizesLog")]
    public class ScratchCard_PrizesLog:IModel
    {
        private int _id;
        /// <summary>
        /// XA_ScratchCard
        /// </summary>	
        [Column("ID")]
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _scratchcardguid;
        /// <summary>
        /// 刮刮卡表的GUID
        /// </summary>	
        [Column("ScratchCardGuid")]
        public string ScratchCardGuid
        {
            get { return _scratchcardguid; }
            set { _scratchcardguid = value; }
        }

        private string _goodsguid;
        /// <summary>
        /// 奖品GUID
        /// </summary>	
        [Column("GoodsGuid")]
        public string GoodsGuid
        {
            get { return _goodsguid; }
            set { _goodsguid = value; }
        }

        private string _openid;
        /// <summary>
        /// 中奖用户微信唯一标识
        /// </summary>	
        [Column("OpenID")]
        public string OpenID
        {
            get { return _openid; }
            set { _openid = value; }
        }

        private string _goodsname;
        /// <summary>
        /// 奖品名
        /// </summary>	
        [Column("GoodsName")]
        public string GoodsName
        {
            get { return _goodsname; }
            set { _goodsname = value; }
        }

        private string _usermob;
        /// <summary>
        /// 中奖者提交的手机号
        /// </summary>	
        [Column("UserMob")]
        public string UserMob
        {
            get { return _usermob; }
            set { _usermob = value; }
        }
    }
}


namespace XingAo.Networks.CMS.Model.Mappings
{
    [Export("ScratchCard_PrizesLogMapping")]
    public class ScratchCard_PrizesLogMapping : MappingBase<ScratchCard_PrizesLog>
    {
        public ScratchCard_PrizesLogMapping()
        {
            //映射表名
            this.ToTable("XA_WeiXin_ScratchCard_PrizesLog");
            //this.HasRequired(m => m.Group).WithMany(m => m.Class).HasForeignKey(t => t.GroupId);

        }
    }
}