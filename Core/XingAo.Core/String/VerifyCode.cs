using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;

namespace XingAo.Core
{
    /// <summary>
    /// 验证码
    /// </summary>
    public class VerifyCode
    {
        private const double PI = 3.1415926535897932384626433832795;
        private const double PI2 = 6.283185307179586476925286766559;

        private string _chackCode;
        /// <summary>
        /// 获取验证码值
        /// </summary>
        public string ChackCode
        {
            get { return _chackCode; }
        }
        private int length = 6;
        /// <summary>
        /// 验证码长度(默认为4)
        /// </summary>
        public int Length
        {
            get { return length; }
            set { length = value; }
        }
        int fontSize = 12;
        /// <summary>
        /// 验证码字体大小(默认12像素)
        /// </summary>
        public int FontSize
        {
            get { return fontSize; }
            set { fontSize = value; }
        }
        int padding = 1;
        /// <summary>
        /// 边框(默认1像素)
        /// </summary>
        public int Padding
        {
            get { return padding; }
            set { padding = value; }
        }
        bool chaos = false;
        /// <summary>
        /// 是否输出燥点(默认不输出)
        /// </summary>
        public bool Chaos
        {
            get { return chaos; }
            set { chaos = value; }
        }
        Color chaosColor = Color.LightGray;
        /// <summary>
        /// 输出燥点的颜色(默认灰色)
        /// </summary>
        public Color ChaosColor
        {
            get { return chaosColor; }
            set { chaosColor = value; }
        }
        Color backgroundColor = Color.White;
        /// <summary>
        /// 自定义背景色(默认白色)
        /// </summary>
        public Color BackgroundColor
        {
            get { return backgroundColor; }
            set { backgroundColor = value; }
        }
        Color[] colors = { Color.Black, Color.Red, Color.DarkBlue, Color.Green, Color.Orange, Color.Brown, Color.DarkCyan, Color.Purple };

        
        /// <summary>
        /// 自定义随机颜色数组
        /// </summary>
        public Color[] Colors
        {
            get { return colors; }
            set { colors = value; }
        }
        string[] fonts = { "Arial", "Georgia" };
        /// <summary>
        /// 自定义字体数组
        /// </summary>
        public string[] Fonts
        {
            get { return fonts; }
            set { fonts = value; }
        }
        FontStyle[] FontStyles = { FontStyle.Bold, FontStyle.Italic, FontStyle.Regular, FontStyle.Strikeout};
        string codeSerial = "1,2,3,4,5,6,7,8,9," +
                            "a,b,c,d,e,f,g,h,i,j,k,m,n,p,q,r,s,t,u,v,w,x,y,z," +
                            "A,B,C,D,E,F,G,H,J,K,L,M,N,P,Q,R,S,T,U,V,W,X,Y,Z";
        /// <summary>
        /// 自定义随机码字符串序列(使用逗号分隔)
        /// </summary>
        public string CodeSerial
        {
            get { return codeSerial; }
            set { codeSerial = value; }
        }

        /// <summary>
        /// 生成校验码图片
        /// </summary>
        /// <returns></returns>
        public byte[] CreateImageCode()
        {
            _chackCode = CreateVerifyCode(Length);
            Random rand = new Random();
            int fSize = rand.Next(9, 12);// FontSize;
            int fWidth = fSize + Padding;
            int imageWidth = (int)(_chackCode.Length * fWidth) + 4 + Padding * 2;
            int imageHeight = fSize * 2 + Padding;
            Bitmap image = new Bitmap(imageWidth, imageHeight);
            Graphics g = Graphics.FromImage(image);
            g.Clear(BackgroundColor);
           
            //给背景添加随机生成的燥点
            if (this.Chaos)
            {
               
            }
            
            int c = Length * 5;
            Color[] colors2 = { Color.AntiqueWhite, Color.Coral, Color.DarkKhaki, Color.Fuchsia, Color.Gold };
            for (int i = 0; i < c; i++)
            {
                Pen pen = new Pen(colors2[rand.Next(Colors.Length - 1)], 1);
                int x = rand.Next(image.Width);
                int y = rand.Next(image.Height);
                g.DrawRectangle(pen, x, y, 2, 2);
            }

            int left = 0, top = 0, top1 = 1, top2 = 1;
            int n1 = (imageHeight - FontSize - Padding * 2);
            int n2 = n1 / 4;
            top1 = n2;
            top2 = n2 * 2;
            Font f;
            Brush b;
            int cindex, findex;
            //随机字体和颜色的验证码字符
            for (int i = 0; i < _chackCode.Length; i++)
            {
                cindex = rand.Next(Colors.Length - 1);
                findex = rand.Next(Fonts.Length - 1);
                f = new Font(Fonts[findex], fSize, FontStyles[rand.Next(FontStyles.Length-1)]);
                b = new SolidBrush(Colors[cindex]);
                if (i % 2 == 1)
                {
                    top = top2;
                }
                else
                {
                    top = top1;
                }
                left = i * fWidth;
                g.DrawString(_chackCode.Substring(i, 1), f, b, left, top);
            }
            //画一个边框 边框颜色为Color.Gainsboro
            g.DrawRectangle(new Pen(Color.Gainsboro, 0), 0, 0, image.Width - 1, image.Height - 1);
            g.Dispose();
            //产生波形
            image = TwistImage(image, true,0, 40);
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            //将图像保存到指定的流
            image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            return ms.GetBuffer();
        }
        /// <summary>
        /// 产生波形滤镜效果(正弦曲线Wave扭曲图片)
        /// </summary>
        /// <param name="srcBmp">图片路径</param>
        /// <param name="bXDir">如果扭曲则选择为True</param>
        /// <param name="nMultValue">波形的幅度倍数，越大扭曲的程度越高，一般为3</param>
        /// <param name="dPhase">波形的起始相位，取值区间[0-2*PI)</param>
        /// <returns></returns>
        public Bitmap TwistImage(Bitmap srcBmp, bool bXDir, double dMultValue, double dPhase)
        {
            Bitmap destBmp = new Bitmap(srcBmp.Width, srcBmp.Height);
            // 将位图背景填充为白色
            Graphics graph = Graphics.FromImage(destBmp);
            graph.FillRectangle(new SolidBrush(Color.White), 0, 0, destBmp.Width, destBmp.Height);
            graph.Dispose();
            double dBaseAxisLen = bXDir ? (double)destBmp.Height : (double)destBmp.Width;
            for (int i = 0; i < destBmp.Width; i++)
            {
                for (int j = 0; j < destBmp.Height; j++)
                {
                    double dx = 0;
                    dx = bXDir ? (PI2 * (double)j) / dBaseAxisLen : (PI2 * (double)i) / dBaseAxisLen;
                    dx += dPhase;
                    double dy = Math.Sin(dx);
                    // 取得当前点的颜色
                    int nOldX = 0, nOldY = 0;
                    nOldX = bXDir ? i + (int)(dy * dMultValue) : i;
                    nOldY = bXDir ? j : j + (int)(dy * dMultValue);
                    Color color = srcBmp.GetPixel(i, j);
                    if (nOldX >= 0 && nOldX < destBmp.Width
                     && nOldY >= 0 && nOldY < destBmp.Height)
                    {
                        destBmp.SetPixel(nOldX, nOldY, color);
                    }
                }
            }
            return destBmp;
        }
        /// <summary>
        /// 生成随机字符码
        /// </summary>
        /// <param name="codeLen"></param>
        /// <returns></returns>
        public string CreateVerifyCode(int codeLen)
        {
            if (codeLen == 0)
            {
                codeLen = Length;
            }
            string[] arr = CodeSerial.Split(',');
            string code = "";
            int randValue = -1;
            Random rand = new Random(unchecked((int)DateTime.Now.Ticks));
            for (int i = 0; i < codeLen; i++)
            {
                randValue = rand.Next(0, arr.Length - 1);
                code += arr[randValue];
            }
            return code;
        }
    }
}
