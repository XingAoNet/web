/*=================================
//  模块：XA_BigWheel实体
//  创建者：zheng
//  创建时间：2013-12-19
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
    ///表名：大转盘的实体
    /// </summary>	
    [Table("XA_WeiXin_BigWheel")]
    public class BigWheel : IModel
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

        private string _bguid;
        /// <summary>
        /// 转盘Guid
        /// </summary>	
        [Column("BGuid")]
        public string BGuid
        {
            get { return _bguid; }
            set { _bguid = value; }
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

        private string _title;
        /// <summary>
        /// 大转盘活动标题
        /// </summary>	
        [Column("Title")]
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        private string _pictureaddress;
        /// <summary>
        /// 活动图片地址
        /// </summary>	
        [Column("PictureAddress")]
        public string PictureAddress
        {
            get { return _pictureaddress; }
            set { _pictureaddress = value; }
        }

        private string _abstract;
        /// <summary>
        /// 描述
        /// </summary>	
        [Column("Abstract")]
        public string Abstract
        {
            get { return _abstract; }
            set { _abstract = value; }
        }

        private string _detailedcontent;
        /// <summary>
        /// 详细内容
        /// </summary>	
        [Column("DetailedContent")]
        public string DetailedContent
        {
            get { return _detailedcontent; }
            set { _detailedcontent = value; }
        }

        private string _prize;
        /// <summary>
        /// 奖品
        /// </summary>	
        [Column("Prize")]
        public string Prize
        {
            get { return _prize; }
            set { _prize = value; }
        }

        private string _color;
        /// <summary>
        /// 转盘背景色
        /// </summary>	
        [Column("Color")]
        public string Color
        {
            get { return _color; }
            set { _color = value; }
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
        /// 结束时间
        /// </summary>	
        [Column("EndTime")]
        public DateTime EndTime
        {
            get { return _endtime; }
            set { _endtime = value; }
        }

        private int _daynum;
        /// <summary>
        /// 每天摇奖次数
        /// </summary>	
        [Column("DayNum")]
        public int DayNum
        {
            get { return _daynum; }
            set { _daynum = value; }
        }

        private int _totalnum;
        /// <summary>
        /// 总共摇奖次数
        /// </summary>	
        [Column("TotalNum")]
        public int TotalNum
        {
            get { return _totalnum; }
            set { _totalnum = value; }
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

        private int _canuse;
        /// <summary>
        /// 状态
        /// </summary>	
        [Column("CanUse")]
        public int CanUse
        {
            get { return _canuse; }
            set { _canuse = value; }
        }
    }
}


namespace XingAo.Networks.CMS.Model.Mappings
{
    [Export("BigWheelMapping")]
    public class BigWheelMapping : MappingBase<Model.BigWheel>
    {
        public BigWheelMapping()
        {
            //映射表名
            this.ToTable("XA_WeiXin_BigWheel");
        }
    }
}
