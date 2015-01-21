using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using XingAo.Networks.CMS.Model.DatabaseModel;

namespace XingAo.Networks.CMS.Model
{
    /// <summary>
    /// 标签表
    /// </summary>
    public class Labels
    {
        private int _id;
        /// <summary>
        /// {标签表}
        /// </summary>	
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID")]
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }


        private string _LableId;
        /// <summary>
        /// {标签表}
        /// </summary>	
        [Key,Column("LableId")]
        public string LableId
        {
            get { return _LableId; }
            set { _LableId = value; }
        }

        private string _lablename;
        /// <summary>
        /// 标签名
        /// </summary>	
        [Column("LableName")]
        public string LableName
        {
            get { return _lablename; }
            set { _lablename = value; }
        }

        private string _Analyze;
        /// <summary>
        /// 解析方式
        /// </summary>	
        [Column("Analyze")]
        public string Analyze
        {
            get { return _Analyze; }
            set { _Analyze = value; }
        }

        private int _IsPager;
        /// <summary>
        /// 是否启动分页
        /// </summary>	
        [Column("IsPager")]
        public int IsPager
        {
            get { return _IsPager; }
            set { _IsPager = value; }
        }

        private int _PagerSize;
        /// <summary>
        /// 每页显示记录数
        /// </summary>	
        [Column("PagerSize")]
        public int PagerSize
        {
            get { return _PagerSize; }
            set { _PagerSize = value; }
        }

        private string _labeldescription;
        /// <summary>
        /// LabelDescription
        /// </summary>	
        [Column("LabelDescription")]
        public string LabelDescription
        {
            get { return _labeldescription; }
            set { _labeldescription = value; }
        }

        private string _templatehtml;
        /// <summary>
        /// 标签内容
        /// </summary>	
        [Column("TemplateHtml")]
        public string TemplateHtml
        {
            get { return _templatehtml; }
            set { _templatehtml = value; }
        }

        private string _dbsql;
        /// <summary>
        /// 数据sql语句
        /// </summary>	
        [Column("DbSql")]
        public string DbSql
        {
            get { return _dbsql; }
            set { _dbsql = value; }
        }

        public virtual ICollection<LabelParams> Params { get; set; }
    }
}
