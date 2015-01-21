/******************************************************************
* Create By:卢小阳
* Create Time:2013/4/21 22:18:57
* Update By:
* Last Update Time:
* Update Description:
******************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XingAo.NetWorks.VerifyPermissions.IModels;
using XingAo.NetWorks.VerifyPermissions.Enum;
using XingAo.NetWorks.VerifyPermissions.Models;

namespace XingAo.NetWorks.VerifyPermissions.Utility
{
    /// <summary>
    /// 用户权限验证类
    /// </summary>
   public static class UserPermission
    {
       /// <summary>
       /// 用户菜单与操作权限列表
       /// </summary>
       private static IList<IMenu> li = new List<IMenu>();
       /// <summary>
       /// 登记用户权限（在验证权限前必须执行一次）
       /// </summary>
       /// <param name="userinfo"></param>
       public static void SetUserOperating(IUser userinfo)
       {
           if(userinfo!=null)
           li = userinfo.MenuList;
       }
       
       /// <summary>
       /// 验证是否有此权限
       /// </summary>
       /// <param name="menu">菜单</param>
       /// <param name="operating">操作类型枚举</param>
       /// <returns></returns>
       public static bool IsHavePermission(IMenu menu, Operating operating)
       {
           if (li == null || li.Count == 0)
               return false;
           return li.Where(p => p.ID== menu.ID&& p.OperatingInfo.Where(c=>c.OperatingEnum== operating).Count()>0).Count()>0;
       }
       /// <summary>
       /// 验证是否有此权限
       /// </summary>
       /// <param name="menuCode">菜单编码</param>
       /// <param name="operating">操作类型枚举</param>
       /// <returns></returns>
       public static bool IsHavePermission(string menuCode, Operating operating)
       {
           if (li == null || li.Count == 0)
               return false;
           return li.Where(p => p.Code == menuCode && p.OperatingInfo.Where(c => c.OperatingEnum == operating).Count() > 0).Count() > 0;
       }
       /// <summary>
       /// 验证是否有此权限
       /// </summary>
       /// <param name="menuID">菜单ID</param>
       /// <param name="operating">操作类型枚举</param>
       /// <returns></returns>
       public static bool IsHavePermission(int menuID, Operating operating)
       {
           if (li == null || li.Count == 0)
               return false;
           return li.Where(p => p.ID == menuID && p.OperatingInfo.Where(c=>c.OperatingEnum == operating).Count()>0).Count() > 0;
       }
       /// <summary>
       /// 验证是否有此权限
       /// </summary>
       /// <param name="menu">菜单</param>
       /// <param name="operating">操作类型枚举</param>
       /// <param name="err">回传具体错误</param>
       /// <returns></returns>
       public static bool IsHavePermission(IMenu menu, Operating operating, ErrorInfo err)
       {
           if (li == null || li.Count == 0)
           {
               err.ErrType = ErrorType.NullMenuOperatingErr;
               err.ErrMsg = "用户所拥有的权限为空或未登记用户权限！";
               return false;
           }
           return li.Where(p => p.ID == menu.ID && p.OperatingInfo.Where(c=>c.OperatingEnum == operating).Count()>0).Count() > 0;
       }
       /// <summary>
       /// 返回所有菜单对应的可操作权限
       /// </summary>
       /// <returns></returns>
       public static IList<IMenu> GetUserOperating()
       {
           return li;
       }
       /// <summary>
       /// 返回指定菜单下所拥有的权限
       /// </summary>
       /// <param name="menu"></param>
       /// <returns></returns>
       public static IList<IOperatingInfo> GetUserOperating(IMenu menu)
       {
           return li.Where(p => p.ID == menu.ID).FirstOrDefault().OperatingInfo;
       }
       /// <summary>
       /// 返回指定菜单下所拥有的权限
       /// </summary>
       /// <param name="menuID">指定菜单ID</param>
       /// <returns></returns>
       public static IList<IOperatingInfo> GetUserOperating(int menuID)
       {
           return li.Where(p => p.ID == menuID).FirstOrDefault().OperatingInfo;
       }
       /// <summary>
       /// 返回指定菜单下所拥有的权限
       /// </summary>
       /// <param name="menuCode">指定菜单ID</param>
       /// <returns></returns>
       public static IList<IOperatingInfo> GetUserOperating(string menuCode)
       {
           return li.Where(p => p.Code == menuCode).FirstOrDefault().OperatingInfo;
       }
    }
}
