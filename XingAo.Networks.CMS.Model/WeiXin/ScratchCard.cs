/*=================================
//  模块：XA_ScratchCard实体
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
    ///表名：刮刮卡信息表  的实体
    /// </summary>	
    [Table("XA_WeiXin_ScratchCard")]
    public class ScratchCard:IModel
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

        private string _sguid;
        /// <summary>
        /// 刮刮卡Guid
        /// </summary>	
        [Column("SGuid")]
        public string SGuid
        {
            get { return _sguid; }
            set { _sguid = value; }
        }

        private string _wguid;
        /// <summary>
        /// 微信Guid
        /// </summary>	
        [Column("WGuid")]
        public string WGuid
        {
            get { return _wguid; }
            set { _wguid = value; }
        }

        private string _keys;
        /// <summary>
        /// 关键字
        /// </summary>	
        [Column("Keys")]
        public string Keys
        {
            get { return _keys; }
            set { _keys = value; }
        }

        private int _keytype;
        /// <summary>
        /// 匹配类型
        /// </summary>	
        [Column("KeyType")]
        public int KeyType
        {
            get { return _keytype; }
            set { _keytype = value; }
        }

        private string _title;
        /// <summary>
        /// 刮刮卡活动标题
        /// </summary>	
        [Column("Title")]
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        private string _abstract;
        /// <summary>
        /// 刮刮卡活动标题
        /// </summary>	
        [Column("Abstract")]
        public string Abstract
        {
            get { return _abstract; }
            set { _abstract = value; }
        }

        private int _parentid;
        /// <summary>
        /// 所属类别
        /// </summary>	
        [Column("ParentID")]
        public int ParentID
        {
            get { return _parentid; }
            set { _parentid = value; }
        }

        private int _orderid;
        /// <summary>
        /// 排序号
        /// </summary>	
        [Column("OrderID")]
        public int OrderID
        {
            get { return _orderid; }
            set { _orderid = value; }
        }

        private string _pictureaddress;
        /// <summary>
        /// 活动图片
        /// </summary>	
        [Column("PictureAddress")]
        public string PictureAddress
        {
            get { return _pictureaddress; }
            set { _pictureaddress = value; }
        }
        private string _cardbg;
        /// <summary>
        /// 刮刮卡背景图片（不包含中奖信息的空白卡图片）
        /// </summary>	
        [Column("CardBG")]
        public string CardBG
        {
            get { return _cardbg; }
            set { _cardbg = value; }
        }

        private string _cardbgwidthheight;
        /// <summary>
        /// 原始图片宽度高度（两个值之间以_间隔）
        /// </summary>	
        [Column("CardBGWidthHeight")]
        public string CardBGWidthHeight
        {
            get { return _cardbgwidthheight; }
            set { _cardbgwidthheight = value; }
        }

        private int _isdelete;
        /// <summary>
        /// 是否删除
        /// </summary>	
        [Column("IsDelete")]
        public int IsDelete
        {
            get { return _isdelete; }
            set { _isdelete = value; }
        }

        private string _maskpic;
        /// <summary>
        /// (已删除)要盖住中奖信息的图片，如果为空则用灰色来摭住中奖信息区
        /// </summary>	
        [Column("MaskPic")]
        public string MaskPic
        {
            get { return _maskpic; }
            set { _maskpic = value; }
        }

        private string _maskcoordinate;
        /// <summary>
        /// 要盖住中奖信息的的区域坐标（4个坐标点），坐标依次为左上、右上、左下、右下，每个坐标以|间隔，坐标xy之间以英文逗号间隔
        /// </summary>	
        [Column("MaskCoordinate")]
        public string MaskCoordinate
        {
            get { return _maskcoordinate; }
            set { _maskcoordinate = value; }
        }

        private DateTime _starttime;
        /// <summary>
        /// 开始时间
        /// </summary>	
        [Column("StartTime")]
        public DateTime StartTime
        {
            get { return _starttime; }
            set { _starttime = value; }
        }

        private DateTime _endtime;
        /// <summary>
        /// 终止时间
        /// </summary>	
        [Column("EndTime")]
        public DateTime EndTime
        {
            get { return _endtime; }
            set { _endtime = value; }
        }

        private long _totalcount;
        /// <summary>
        /// 总卡数或总票数
        /// </summary>	
        [Column("TotalCount")]
        public long TotalCount
        {
            get { return _totalcount; }
            set { _totalcount = value; }
        }

        private int _canuse;
        /// <summary>
        /// 状态 0、关闭；1、开启
        /// </summary>	
        [Column("CanUse")]
        public int CanUse
        {
            get { return _canuse; }
            set { _canuse = value; }
        }

        private long _usedcount;
        /// <summary>
        /// 已参与人数
        /// </summary>	
        [Column("UsedCount")]
        public long UsedCount
        {
            get { return _usedcount; }
            set { _usedcount = value; }
        }

        private int _allowvisitedcount;
        /// <summary>
        /// 一天允许抽几次
        /// </summary>	
        [Column("AllowVisitedCount")]
        public int AllowVisitedCount
        {
            get { return _allowvisitedcount; }
            set { _allowvisitedcount = value; }
        }

        private string _defaultgoodname;
        /// <summary>
        /// 未中奖信息
        /// </summary>	
        [Column("DefaultGoodName")]
        public string DefaultGoodName
        {
            get { return _defaultgoodname; }
            set { _defaultgoodname = value; }
        }

        private string _inhtml;
        /// <summary>
        /// 其余图片
        /// </summary>	
        [Column("InHtml")]
        public string InHtml
        {
            get { return _inhtml; }
            set { _inhtml = value; }
        }
    }
}



namespace XingAo.Networks.CMS.Model.Mappings
{
    [Export("ScratchCardMapping")]
    public class ScratchCardMapping : MappingBase<ScratchCard>
    {
        public ScratchCardMapping()
        {
            //映射表名
            this.ToTable("XA_WeiXin_ScratchCard");
            //this.HasRequired(m => m.Group).WithMany(m => m.Class).HasForeignKey(t => t.GroupId);

        }
    }
}