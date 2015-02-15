﻿//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

//namespace XingAo.Software.UserCenter.Account
//{
//    /// <summary>
//    /// 用户注册服务
//    /// </summary>
//    public interface IRegisterService
//    {
//        /// <summary>
//        /// 注册用户
//        /// </summary>
//        /// <param name="user">用户信息</param>
//        /// <returns>返回是否注册成功，true成功，false失败</returns>
//        public bool Register(IUser user);
//        /// <summary>
//        /// 判断用户是否存在
//        /// </summary>
//        /// <param name="user">用户信息</param>
//        /// <returns>返回是否存在，true存在，false失败</returns>
//        public bool IsUserExist(IUser user);
//        /// <summary>
//        /// 发送注册短信
//        /// </summary>
//        /// <param name="mobile">手机号码，发送验证码类见：<see cref="XingAo.Core.VerifyCode.cs"/></param>
//        /// <returns>返回发送结果，true发送成功，false发送失败</returns>
//        public bool SendRegisterMobile(string mobile);
//        /// <summary>
//        /// 验证注册短信
//        /// </summary>
//        /// <param name="validateCode">验证码</param>
//        /// <returns>返回验证结果，true验证成功，false验证失败</returns>
//        public bool ValidateRegisterMobile(string validateCode);
//    }
//}
