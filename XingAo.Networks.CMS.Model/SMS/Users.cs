using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XingAo.Networks.CMS.Model.SMSModel
{
    public class Users
    {
        /// <summary>
        /// 主键ID
        /// </summary>	        
        public int ID
        {
            get;
            set;
        }
        /// <summary>
        /// 用户key
        /// </summary>	
        public string UserKey
        {
            get;
            set;
        }
        /// <summary>
        /// 用户密钥
        /// </summary>
        public string UserPwd
        {
            get;
            set;
        }
        /// <summary>
        /// 短信可发条数
        /// </summary>	
        public int CanUseCount
        {
            get;
            set;
        }
        /// <summary>
        /// 帐号是否可用1可用，0禁用
        /// </summary>	
        public int CanUse
        {
            get;
            set;
        }
        /// <summary>	
        /// 短信发送通道：1--审核通道；2--免审通道 ；3--短信猫
        /// </summary>	
        public int SMSWay
        {
            get;
            set;
        }
    }
}
