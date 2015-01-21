using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace XingAo.Networks.CMS.Web.Shared
{
    public partial class Verification : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //获取GB2312编码页（表） 
            /**/
            /** 
* 生成中文验证验码所要使用的方法 
* 注，生成中文验证码时要改变一下生成验证码图片的宽度 
* var imageCode = new System.Drawing.Bitmap((int)Math.Ceiling((code.Length * 22.5)), 23); //定义图片的宽度和高度 
**/

            //var gb = Encoding.GetEncoding("gb2312"); 

            /**/
            ////调用函数产生4个随机中文汉字编码 
            //object[] bytes = CreateRegionCode(4); 

            /**/
            ////根据汉字编码的字节数组解码出中文汉字 
            //var sbCode = new StringBuilder().Append(gb.GetString((byte[])Convert.ChangeType(bytes[0], typeof(byte[])))) 
            // .Append(gb.GetString((byte[])Convert.ChangeType(bytes[1], typeof(byte[])))) 
            // .Append(gb.GetString((byte[])Convert.ChangeType(bytes[2], typeof(byte[])))) 
            // .Append(gb.GetString((byte[])Convert.ChangeType(bytes[3], typeof(byte[])))); 
            //CreateCheckCodeImage(sbCode.ToString()); 
            string code = GenerateCheckCode(4);
            CreateCheckCodeImage(GenerateCheckCode(4)); //生成数字英文所要使用的方法 
            Session["V_Code"] = code;
        }

        //生成汉字验证码#region 生成汉字验证码 
        /**/
        /// <summary> 
        /// 此函数在汉字编码范围内随机创建含两个元素的十六进制字节数组，每个字节数组代表一个汉字，并将四个字节数组存储在object数组中。 
        /// </summary> 
        /// <param name="strLength">代表需要产生的汉字个数</param> 
        /// <returns></returns> 
        static object[] CreateRegionCode(int strLength)
        {
            var rBase = new[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "a", "b", "c", "d", "e", "f" };

            var random = new Random();
            var bytes = new object[strLength];

            /**/
            /*每循环一次产生一个含两个元素的十六进制字节数组，并将其放入bject数组中 
每个汉字有四个区位码组成 
区位码第1位和区位码第2位作为字节数组第一个元素 
区位码第3位和区位码第4位作为字节数组第二个元素 
*/

            for (int i = 0; i < strLength; i++)
            {
                //区位码第1位 
                var r1 = random.Next(11, 14);
                var str_r1 = rBase[r1].Trim();

                random = new Random(r1 * unchecked((int)DateTime.Now.Ticks) + i); //更换随机数发生器的种子避免产生重复值 

                var r2 = 0;
                if (r1 == 13)
                    r2 = random.Next(0, 7);
                else
                    r2 = random.Next(0, 16);

                var str_r2 = rBase[r2].Trim();

                //区位码第3位 
                random = new Random(r2 * unchecked((int)DateTime.Now.Ticks) + i);
                var r3 = random.Next(10, 16);
                var str_r3 = rBase[r3].Trim();

                //区位码第4位 
                random = new Random(r3 * unchecked((int)DateTime.Now.Ticks) + i);
                var r4 = 0;
                if (r3 == 10)
                    r4 = random.Next(1, 16);
                else if (r3 == 15)
                    r4 = random.Next(0, 15);
                else
                    r4 = random.Next(0, 16);

                var str_r4 = rBase[r4].Trim();

                var byte1 = Convert.ToByte(str_r1 + str_r2, 16);
                var byte2 = Convert.ToByte(str_r3 + str_r4, 16);
                //将两个字节变量存储在字节数组中 
                var str_r = new[] { byte1, byte2 };

                //将产生的一个汉字的字节数组放入object数组中 
                bytes.SetValue(str_r, i);
            }
            return bytes;
        }


        //生成图片#region 生成图片 
        void CreateCheckCodeImage(string code)
        {
            var imageCode = new System.Drawing.Bitmap((int)Math.Ceiling((code.Length * 14.1)), 22); //定义图片的宽度和高度 
            var g = Graphics.FromImage(imageCode); //加载图片到画布上 

            try
            {
                var random = new Random();
                g.Clear(Color.White); //清空图片背景色 
                Color[] zd = { Color.Silver, Color.Gray, Color.MediumPurple, Color.MistyRose, Color.DarkOrange };
                //画图片的背景噪音线 
                for (int i = 0; i < 25; i++)
                {
                    var x1 = random.Next(imageCode.Width);
                    var x2 = random.Next(imageCode.Width);
                    var y1 = random.Next(imageCode.Height);
                    var y2 = random.Next(imageCode.Height);

                    g.DrawLine(new Pen(zd[random.Next(0, 4)]), new Point(x1, y1), new Point(x2, y2));
                }
                string[] FontList = { "Arial", "黑体", "宋体", "仿宋", "Verdana" };
                float[] FontSize = { 13F, 14F, 15F };
                Color[] ColorList = { Color.Red, Color.DarkGreen, Color.Blue, Color.DarkRed, Color.Green, Color.DeepPink };
                //FontStyle[] Fontstyle = { System.Drawing.FontStyle.Bold , System.Drawing.FontStyle.Italic , FontStyle.Underline};
                var font = new System.Drawing.Font(FontList[random.Next(0, 4)], FontSize[random.Next(0, 2)], System.Drawing.FontStyle.Bold);
                var brush = new System.Drawing.Drawing2D.LinearGradientBrush(
                new Rectangle(0, 0, imageCode.Width, imageCode.Height),
                ColorList[random.Next(0, 5)], ColorList[random.Next(0, 5)], 1.2F, true);
                g.DrawString(code, font, brush, random.Next(1, 3), random.Next(1, 3));

                //画图片的前景噪音点 
                for (int i = 0; i < 100; i++)
                {
                    var x = random.Next(imageCode.Width);
                    var y = random.Next(imageCode.Height);
                    imageCode.SetPixel(x, y, Color.FromArgb(random.Next()));
                }

                //画图片的边框线 
                g.DrawRectangle(new Pen(Color.Silver), 0, 0, imageCode.Width - 1, imageCode.Height - 1);
                var ms = new System.IO.MemoryStream();
                imageCode.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);

                Response.ClearContent();
                Response.ContentType = "image/Jpeg";
                Response.BinaryWrite(ms.ToArray());
            }
            finally
            {
                g.Dispose();
                imageCode.Dispose();
            }

        }


        //生成数据验证码#region 生成数据验证码 
        private string GenerateCheckCode(int length)
        {
            int number;
            char code;
            string checkCode = String.Empty;

            var random = new Random();

            for (int i = 0; i < length; i++)
            {
                number = random.Next();

                if (number % 2 == 0)
                    code = (char)('0' + (char)(number % 10));
                else
                    code = (char)('A' + (char)(number % 26));

                checkCode += code.ToString();
            }
            return checkCode;
        }
    }
}