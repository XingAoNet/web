using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XingAo.Networks.WeChat.Location
{
    /// <summary>
    /// 经纬度坐标
    /// </summary>    
    public class Degree
    {
        public Degree(double x, double y)
        {
            X = x;
            Y = y;
        }
        private double x;

        public double X
        {
            get { return x; }
            set { x = value; }
        }
        private double y;

        public double Y
        {
            get { return y; }
            set { y = value; }
        }
    }
}
