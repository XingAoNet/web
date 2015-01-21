/*=================================
//  模块：XA_Activities实体
//  创建者：zheng
//  创建时间：2013-11-29
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
    ///表名：报名活动的实体
    /// </summary>	
    [Table("XA_WeiXin_Activities")]
    public class Activities : IModel
    {

        private int _id;
        /// <summary>
        /// 报名活动ID
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

        private string _aguid;
        /// <summary>
        /// 报名活动Guid
        /// </summary>	
        [Column("AGuid")]
        public string AGuid
        {
            get { return _aguid; }
            set { _aguid = value; }
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
        /// 标题
        /// </summary>	
        [Column("Title")]
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        private string _pictureaddress;
        /// <summary>
        /// 图片地址
        /// </summary>	
        [Column("PictureAddress")]
        public string PictureAddress
        {
            get { return _pictureaddress; }
            set { _pictureaddress = value; }
        }

        private string _abstract;
        /// <summary>
        /// 详细内容
        /// </summary>	
        [Column("Abstract")]
        public string Abstract
        {
            get { return _abstract; }
            set { _abstract = value; }
        }

        private string _percontent;
        /// <summary>
        /// 所需用户信息
        /// </summary>	
        [Column("PerContent")]
        public string PerContent
        {
            get { return _percontent; }
            set { _percontent = value; }
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

        private int _personnum;
        /// <summary>
        /// 报名人数
        /// </summary>	
        [Column("PersonNum")]
        public int PersonNum
        {
            get { return _personnum; }
            set { _personnum = value; }
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
    [Export("ActivitiesMapping")]
    public class ActivitiesMapping : MappingBase<Model.Activities>
    {
        public ActivitiesMapping()
        {
            //映射表名
            this.ToTable("XA_WeiXin_Activities");
        }
    }
}