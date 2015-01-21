using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XingAo.Networks.CMS.Model.SMSModel
{
    /// <summary>
    /// 定时发送子表数据实体（不作数据增删改使用，只用于查询）
    /// </summary>
    public class MobAndNames
    {
        /// <summary>
        /// 姓名
        /// </summary>	
        public string Name
        {
            get;
            set;
        }
        /// <summary>
        /// 手机号
        /// </summary>	
        public string Mob
        {
            get;
            set;
        }
    }
}
