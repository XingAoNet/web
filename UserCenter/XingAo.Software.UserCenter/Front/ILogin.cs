﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace XingAo.Software.UserCenter
{
    public interface ILogin:ITokenService
    {
        /// <summary>
        /// 登陆post请求
        /// </summary>
        /// <param name="identity"></param>
        /// <param name="password"></param>
        /// <param name="token"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        Result Login(string identity, string password, string token, Hashtable options);
    }
}
