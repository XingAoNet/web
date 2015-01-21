/******************************************************************
* Create By:陈成杰
* Create Time:2013/8/21 12:18:57
* Update By:
* Last Update Time:
* Update Description:
******************************************************************/
using System;
using System.Text;
using System.Security.Cryptography;

namespace XingAo.Core
{
    /// <summary>
    /// 非对称加密解密操作类
    /// </summary>
    public class RSAEncrypt
    {
        private RSACryptoServiceProvider rsaProvider;
        private string _PublicKey, _PrivateKey;
        /// <summary>
        /// 公钥
        /// </summary>
        public string PublicKey
        {
            get { return _PublicKey; }
            set { _PublicKey = value; }
        }
        /// <summary>
        /// 私钥
        /// </summary>
        public string PrivateKey
        {
            get { return _PrivateKey; }
            set { _PrivateKey = value; }
        }

        /// <summary>
        /// 默认构造
        /// </summary>
        public RSAEncrypt()
        {
            rsaProvider = new RSACryptoServiceProvider();
            //将RSA算法的公钥导出到字符串PublicKey中，参数为false表示不导出私钥
            PublicKey = rsaProvider.ToXmlString(false);
            //将RSA算法的私钥导出到字符串PrivateKey中，参数为true表示导出私钥
            PrivateKey = rsaProvider.ToXmlString(true);
        }
        
        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="PublicKey">公钥</param>
        /// <param name="PrivateKey">私钥</param>
        public RSAEncrypt(string PublicKey, string PrivateKey)
        {
            rsaProvider = new RSACryptoServiceProvider();
            this.PrivateKey = PrivateKey;
            this.PublicKey = PublicKey;
        }

        /// <summary>
        /// 使用公钥加密
        /// </summary>
        /// <param name="sSource"></param>
        /// <returns></returns>
        public string EncryptString(string sSource)
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            string plaintext = sSource;
            rsa.FromXmlString(PublicKey);
            byte[] cipherbytes;
            byte[] byteEn = rsa.Encrypt(Encoding.UTF8.GetBytes("lsdjfaIYIu^$#$%d78"), false);
            cipherbytes = rsa.Encrypt(Encoding.UTF8.GetBytes(plaintext), false);
            StringBuilder sbString = new StringBuilder();
            for (int i = 0; i < cipherbytes.Length; i++)
            {
                sbString.Append(cipherbytes[i] + ",");
            }
            return sbString.ToString().EncryptStr();
        }
        /// <summary>
        /// 使用私钥解密
        /// </summary>
        /// <param name="EncryptSource"></param>
        /// <returns></returns>
        public string DecryptString(string EncryptSource)
        {
            EncryptSource = EncryptSource.DecryptStr();
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            rsa.FromXmlString(PrivateKey);
            byte[] byteEn = rsa.Encrypt(Encoding.UTF8.GetBytes("lsdjfaIYIu^$#$%d78"), false);
            string[] sBytes = EncryptSource.Split(',');
            for (int j = 0; j < sBytes.Length; j++)
            {
                if (sBytes[j] != "")
                {
                    byteEn[j] = Byte.Parse(sBytes[j]);
                }
            }
            byte[] plaintbytes = rsa.Decrypt(byteEn, false);
            return Encoding.UTF8.GetString(plaintbytes);
        }


        /// <summary>
        /// 使用公钥将byte[]加密
        /// </summary>
        /// <param name="data">要加密的数据</param>
        /// <returns></returns>
        public byte[] EncryptData(byte[] data)
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(128);
            //将公钥导入到RSA对象中，准备加密；
            rsa.FromXmlString(PublicKey);
            //对数据data进行加密，并返回加密结果；
            //第二个参数用来选择Padding的格式
            return rsa.Encrypt(data, false);

        }

        /// <summary>
        /// 使用私钥将byte[]进行解密
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public byte[] DecryptData(byte[] data)
        {
            try
            {
                RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(128);
                //将私钥导入RSA中，准备解密；
                rsa.FromXmlString(PrivateKey);
                //对数据进行解密，并返回解密结果；
                return rsa.Decrypt(data, false);
            }
            catch { return new byte[] { }; }

        }



        /// <summary>
        /// 使用私钥生成签名
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public byte[] Sign(byte[] data)
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(128);
            //导入私钥，准备签名
            rsa.FromXmlString(PrivateKey);
            //将数据使用MD5进行消息摘要，然后对摘要进行签名并返回签名数据
            return rsa.SignData(data, "MD5");
        }

        /// <summary>
        /// 验证两个byte[]经公钥与私钥加密后的值是否相同
        /// </summary>
        /// <param name="data">未经任何加密的原始数据</param>
        /// <param name="Signature">经私钥加密后的（即签名Sign生成的）</param>
        /// <returns></returns>
        public bool Verify(byte[] data, byte[] Signature)
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(128);
            //导入公钥，准备验证签名
            rsa.FromXmlString(PublicKey);
            //返回数据验证结果
            return rsa.VerifyData(data, "MD5", Signature);
        }
    }
}
