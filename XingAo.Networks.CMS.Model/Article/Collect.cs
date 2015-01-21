using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace XingAo.Networks.CMS.Model
{
    /// <summary>
    ///采集表
    /// </summary>	
	[Table("XA_CMS_Collect")]
	public class Collect
	{    
      	private int _id;
		/// <summary>
		/// 内部自增标识采集配置表
        /// </summary>	
		[ Column("Id", Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id
        {
            get{ return _id; }
            set{ _id = value; }
        }

        private string _collectid;
        /// <summary>
        /// 采集主键
        /// </summary>	
        [Key, Column("CollectId")]
        public string CollectId
        {
            get { return _collectid; }
            set { _collectid = value; }
        }

		private string _name;
		/// <summary>
		/// 采集名
        /// </summary>	
		[Column("Name")]
        public string Name
        {
            get{ return _name; }
            set{ _name = value; }
        }        
				
		private string _starttime;
		/// <summary>
		/// 采集开始时间
        /// </summary>	
		[Column("StartTime")]
        public string StartTime
        {
            get{ return _starttime; }
            set{ _starttime = value; }
        }        
				
		private string _url;
		/// <summary>
		/// 采集地址
        /// </summary>	
		[Column("Url")]
        public string Url
        {
            get{ return _url; }
            set{ _url = value; }
        }

        private string _InsertTable;
		/// <summary>
		/// 采集到那张表
        /// </summary>	
        [Column("InsertTable")]
        public string InsertTable
        {
            get { return _InsertTable; }
            set { _InsertTable = value; }
        }   
				
		private string _expression;
		/// <summary>
		/// 列表表达式
        /// </summary>	
		[Column("Expression")]
        public string Expression
        {
            get{ return _expression; }
            set{ _expression = value; }
        }

        private string _ContentExpression;
		/// <summary>
		/// 内容表达式
        /// </summary>	
        [Column("ContentExpression")]
        public string ContentExpression
        {
            get { return _ContentExpression; }
            set { _ContentExpression = value; }
        }

        /// <summary>
        /// 使用
        /// </summary>
        public int? IsUse { get; set; } 

        //[Required]
        public virtual ICollection<Collect_Pattern> Collect_Patterns { get; set; }
    }
}
