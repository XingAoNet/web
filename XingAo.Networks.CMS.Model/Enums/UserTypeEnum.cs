using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XingAo.Networks.CMS.Model.Enums
{
    public class UserTypeEnum
    {
        public static string swichUserType(int type)
        {
            switch (type)
            {
                case 1:
                    return "高级管理员";
                case 2:
                    return "普通管理员";
                case 0:
                    return "普通后台用户";
                default:
                    return "";
            }
        }
    }      
}
