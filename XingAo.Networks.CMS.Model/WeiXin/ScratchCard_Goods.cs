/*=================================
//  模块：XA_ScratchCard_Goods实体
//  创建者：Lu
//  创建时间：2013-12-2
=================================*/
using System; 
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using XingAo.Core.Data;
using System.ComponentModel.Composition;

namespace XingAo.Networks.CMS.Model
{
    /// <summary>
    ///表名：刮刮卡奖品设置表  的实体
    /// </summary>	
    [Table("XA_WeiXin_ScratchCard_Goods")]
    public class ScratchCard_Goods : IModel
    {
        private int _id;
        /// <summary>
        /// ID
        /// </summary>	
        [Column("ID")]
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _sgguid;
        /// <summary>
        /// 刮卡奖品Guid
        /// </summary>	
        [Column("SGGuid")]
        public string SGGuid
        {
            get { return _sgguid; }
            set { _sgguid = value; }
        }

        private string _wguid;
        /// <summary>
        /// 用户微信唯一标识
        /// </summary>	
        [Column("WGUID")]
        public string WGUID
        {
            get { return _wguid; }
            set { _wguid = value; }
        }

        private string _scratchcardguid;
        /// <summary>
        /// 刮刮卡表的Guid
        /// </summary>	
        [Column("ScratchCardGuid")]
        public string ScratchCardGuid
        {
            get { return _scratchcardguid; }
            set { _scratchcardguid = value; }
        }

        private string _goodsname;
        /// <summary>
        /// 奖品名称
        /// </summary>	
        [Column("GoodsName")]
        public string GoodsName
        {
            get { return _goodsname; }
            set { _goodsname = value; }
        }

        private int _goodscount;
        /// <summary>
        /// 奖品数量(即此奖品允许多少人中奖)
        /// </summary>	
        [Column("GoodsCount")]
        public int GoodsCount
        {
            get { return _goodscount; }
            set { _goodscount = value; }
        }

        private int _usedcount;
        /// <summary>
        /// 已被抽走多少个
        /// </summary>	
        [Column("UsedCount")]
        public int UsedCount
        {
            get { return _usedcount; }
            set { _usedcount = value; }
        }

        private int _levels;
        /// <summary>
        /// 奖项级别1--一等奖 2--二等 奖....
        /// </summary>	
        [Column("Levels")]
        public int Levels
        {
            get { return _levels; }
            set { _levels = value; }
        }

        private string _goodspic;
        /// <summary>
        /// 奖品图片
        /// </summary>	
        [Column("GoodsPic")]
        public string GoodsPic
        {
            get { return _goodspic; }
            set { _goodspic = value; }
        }

        private string _prizenum;
        /// <summary>
        /// 中奖数字,多个以英文逗号间隔
        /// </summary>	
        [Column("PrizeNum")]
        public string PrizeNum
        {
            get { return _prizenum; }
            set { _prizenum = value; }
        }

        private string _allowmob;
        /// <summary>
        /// 此奖项允许抽中的手机号码，如果为空，则表示谁都可能抽中
        /// </summary>	
        [Column("AllowMob")]
        public string AllowMob
        {
            get { return _allowmob; }
            set { _allowmob = value; }
        }

        private int _visitednum;
        /// <summary>
        /// 当前访问数(只有AllowMob不为空时有效，用来表示手机列表中，有多少个手机号已经招财抽过了)
        /// </summary>	
        [Column("VisitedNum")]
        public int VisitedNum
        {
            get { return _visitednum; }
            set { _visitednum = value; }
        }
    }
}


namespace XingAo.Networks.CMS.Model.Mappings
{
    [Export("ScratchCard_GoodsMapping")]
    public class ScratchCard_GoodsMapping : MappingBase<ScratchCard_Goods>
    {
        public ScratchCard_GoodsMapping()
        {
            //映射表名
            this.ToTable("XA_WeiXin_ScratchCard_Goods");
            //this.HasRequired(m => m.Group).WithMany(m => m.Class).HasForeignKey(t => t.GroupId);

        }
    }
}