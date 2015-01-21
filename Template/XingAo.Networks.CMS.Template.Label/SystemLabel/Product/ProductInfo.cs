using System;
using System.Linq;
using System.Text;
using XingAo.Core;
using XingAo.Core.Data;

namespace XingAo.Networks.CMS.Template.Label.SystemLabel.Product
{
    /// <summary>
    /// 商品详细内容显示
    /// </summary>
   [Serializable]
    public class ProductInfo
    {
        #region 属性
        /// <summary>
       /// 商品id，如果为0则自动根据url参数来决定显示哪个商品，否则显示指定id的商品内容
       /// </summary>
       public int PorductID { get; set; }
       /// <summary>
       /// 显示图片宽度（默认400）
       /// </summary>
       public int ShowPicWidth { get; set; }
       /// <summary>
       /// 显示图片高度（默认400）
       /// </summary>
       public int ShowPicHeight { get; set; }
       /// <summary>
       /// 小图片列表的每张图片高度（注意宽度由ShowPicWidth/5得出）
       /// </summary>
       public int SmallPicListWidth { get; set;}
       /// <summary>
       /// 当前选中时，小图片边框颜色（6位16进制值）
       /// </summary>
       public string SelectedSmallPic { get; set; }
       /// <summary>
       /// 当前未选中时，小图片边框颜色（6位16进制值）
       /// </summary>
       public string UnSelectedSmallPic { get; set; }
       /// <summary>
       /// 是否自动切换图片
       /// </summary>
       public bool AutoChangPicIndex { get; set; }
       /// <summary>
       /// 自动切换图片时，每次切换的时间间隔（毫秒）
       /// </summary>
       public long AutoChangPicDelay { get; set; }
       /// <summary>
       /// 模板文件地址（可以相对或绝）
       /// </summary>
       public string TemplateFilePath { get; set; }
        #endregion

       /// <summary>
       /// 渲染html
       /// </summary>
       /// <returns></returns>
       public string GetHtml()
       {
           if (ShowPicWidth <= 0)
               ShowPicWidth = 400;
           if (ShowPicHeight <= 0)
               ShowPicHeight = 400;
           if (SmallPicListWidth <= 0)
               SmallPicListWidth = 50;
           if (!SelectedSmallPic.StartsWith("#"))
               SelectedSmallPic = "#" + SelectedSmallPic;
           if (!UnSelectedSmallPic.StartsWith("#"))
               UnSelectedSmallPic = "#" + UnSelectedSmallPic;
           GetRouteData RouteData = new GetRouteData();
           if (PorductID==0)
           PorductID = RouteData.GetContnetID();
           StringBuilder html = new StringBuilder();
           Model.Product_Base model = new UnitOfWork().FindSigne<Model.Product_Base>(p => p.ID == PorductID);
           if (model==null)
           {
               html.AppendLine("<div style=\"text-align:center; padding:10px; color:red\">商品不存在！</div>");
           }
           else
           {
               string Template = FileOption.ReadFile(TemplateFilePath);
               int index = Template.LastIndexOf("{注释线-");
               if(index>0)
               Template = Template.Substring(0, index);
               /*******************商品详细页模板参数值说明********************/
                    //0--商品图（最多5张放大及切换）
                    //1--商品名称
                    //2--市场价
                    //3--真实出售价
                    //4--商品编码（ProductNumber）
                    //5--库存（TotalCount）
                    //6--已出售数量（SellCount）
                    //7--商品自定义属性列表
               /*******************商品详细页模板参数值说明********************/
               if (string.IsNullOrEmpty(Template))
                   return "<div style=\"text-align:center; padding:10px; color:red\">商品模板不存在或内容为空！</div>";
               else
               {
                   #region 商品图片轮播及放大镜部分
                   html.AppendLine("<script type=\"text/javascript\" src=\"/Scripts/cloud-zoom.1.0.2.min.js\"></script>");
                   html.AppendLine("<style type=\"text/css\">");
                   html.AppendLine("/* zoom-section */");
                   html.AppendLine(".zoom-small-image{border:0px solid #CCC;float:left;margin-bottom:20px;}");
                   html.AppendLine(".cloud-zoom-title{background:#FFF;padding:5px;word-break:break-all; font-size:18px; line-height:100%}");
                   html.AppendLine(".cloud-zoom-big {border:0px solid #ccc;overflow:hidden;}");
                   html.AppendLine("</style>");

                   StringBuilder ProductPic = new StringBuilder();
                   ProductPic.AppendLine("<div class=\"Product_ShowPic_Box\">");
                   ProductPic.AppendLine("<div id=\"MidPicShow\" style=\"width:9999px;z-index:9998; position:absolute;\">");
                   ProductPic.AppendLine("<ul class=\"MidPic\">");
                   string[] pic = model.PicList.Split(',');
                   foreach (string url in pic)
                   {

                       ProductPic.AppendLine("<li>");
                       ProductPic.AppendLine("<div class=\"zoom-section\">");
                       ProductPic.AppendLine("<div class=\"zoom-small-image\">");
                       ProductPic.AppendLine("<a href=\"" + url + "\" class=\"cloud-zoom\" rel=\"position:'inside',showTitle:true,adjustX:0,adjustY:0\"><img src=\"" + url + "\" title=\"" + model.ProductName + "\" alt=\"\" /></a>");
                       ProductPic.AppendLine("</div>");
                       ProductPic.AppendLine("</div>");
                       ProductPic.AppendLine("</li>");

                   }


                   ProductPic.AppendLine("</ul>");
                   ProductPic.AppendLine("</div>  ");
                   ProductPic.AppendLine("<ul class=\"SmallPic\">");


                   foreach (string url in pic)
                       ProductPic.AppendLine("<li><img src=\"" + url + "\" alt=\"\" /></li>");



                   ProductPic.AppendLine("</ul>");
                   ProductPic.AppendLine("</div>");

                   html.AppendLine(ProductPic.ToString());
                   html.AppendLine("<script type=\"text/javascript\">");
                   html.AppendLine("var MidPicWidth=" + ShowPicWidth.ToString() + ";");
                   html.AppendLine("var MidPicHeight=" + ShowPicHeight.ToString() + ";");
                   html.AppendLine("var SmallPicHeight=" + SmallPicListWidth.ToString() + ";");
                   html.AppendLine("var SmallPicSelectColor=\"" + SelectedSmallPic + "\";");
                   html.AppendLine("var SmallPicUnSelectColor=\"" + UnSelectedSmallPic + "\";");
                   html.AppendLine("var Product_ShowPic_AutoMove = " + AutoChangPicIndex.ToString() + ";");
                   html.AppendLine("var Product_ShowPic_AutoMoveSpeed = " + AutoChangPicDelay.ToString() + ";");
                   html.AppendLine("</script>");
                   html.AppendLine("<script type=\"text/javascript\" src=\"/Themes/Default/Js/ProductInfoPics.js\"></script>");
                   #endregion
                   object[] parms=new object[model.Product_AttributeValuesList.Count+9];
                   parms[0] = html;
                   parms[1]=model.ProductName;
                     parms[2]=  model.Price;
                      parms[3]= model.RealPrice;
                      parms[4]= model.ProductNumber;
                     parms[5]=  model.TotalCount;
                     parms[6] = model.SellCount;
                     parms[7] = "/Buy/" + model.ID.ToString();
                     parms[8] = "/ShoppingCart/" + model.ID.ToString();
                   #region 商品自定义属性列表
                   StringBuilder CustomAttr = new StringBuilder();
                   int i = 9;
                   StringBuilder OthersArrtValue = new StringBuilder();
                   bool HaveAllOthers = Template.IndexOf("[AllOthers]") > -1;
                   foreach (var attr in model.Product_AttributeValuesList.OrderByDescending(p => p.ID))
                   {
                       if (HaveAllOthers&&Template.IndexOf("{" + i.ToString() + "}") < 0)
                           OthersArrtValue.Append("<div>" + attr.AttrName + ":" + attr.AttrValue + "</div>");
                       parms[i] = "<div class=\"title\">" + attr.AttrName + "</div><div class=\"info\">" + attr.AttrValue + "</div>";
                       i++;
                       //.AppendLine("<div>" + attr.AttrName + ":" + attr.AttrValue + "</div>");
                   }
                   #endregion

                   return string.Format(Template, parms).Replace("[AllOthers]", OthersArrtValue.ToString());
               }
           }
           return html.ToString();
       }
    }
}
