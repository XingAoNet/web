using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using XingAo.Core;
using XingAo.Core.Data;

namespace XingAo.Networks.CMS.Template.Label.SystemLabel.Order
{
   public class OrderList
    {
       public string GetList()
       {
           Model.WebUsers LoginUser;
           if (CookiesHelp.IsLogin<Model.WebUsers>(CookiesHelp.CookiesTypeEnum.WebUser, out LoginUser))
           {
               UnitOfWork uk = new UnitOfWork();
               List<Model.Product_OrderBase> OrderBaseList = uk.FindByFunc<Model.Product_OrderBase>(p => p.State == 0 && p.CreateUserID == LoginUser.ID&&p.ManagerState==(int)Model.OrderManagerStateEnum.UnSet).ToList();

           
               string Template = FileOption.ReadFile("/Templates/LabelFormatTemplates/ShoppingCartList.htm");
               int index = Template.LastIndexOf("{注释线-");
               if (index > 0)
                   Template = Template.Substring(0, index);
               Template = Template.Replace("{5}", "/ConformPay");
               Regex Reg_Froeach = new Regex(@"\[%ForEach%\](?<Item>(.|\n)*)\[%EndForEach%]", RegexOptions.IgnoreCase | RegexOptions.Multiline);
               string Item = Reg_Froeach.Match(Template).Groups["Item"].Value;
               string RepItem = Reg_Froeach.Match(Template).Value;
               Template = Template.Replace(RepItem, "{Each}");
               Regex Reg_SubEach = new Regex(@"\[%SubEach%\](?<SubItem>(.|\n)*)\[%EndSubEach%]", RegexOptions.IgnoreCase | RegexOptions.Multiline);
               string SubItem = Reg_SubEach.Match(Item).Groups["SubItem"].Value;
               string RepSubItem = Reg_SubEach.Match(Item).Value;
               
               StringBuilder each = new StringBuilder();
               foreach (Model.Product_OrderBase order in OrderBaseList)
               {
                    //{0}--订单创建时间
                    //{1}--订单ID
                    //{2}--订单编号
                    //{3}--总金额
                    //{4}--订单状态
                    //{5}--确定提交处理页面地址
                   each.AppendLine(string.Format(Item.Replace(RepSubItem, "[SubItem]"),
                       order.CreateTime.ToString("yyyy-MM-dd HH:mm"),
                       order.ID,
                       order.OrderCode,
                       order.Product_OrderInfoList==null?0:order.Product_OrderInfoList.Sum(p=>p.Price*p.BuyCount),
                       order.State                       
                       )); 
                   StringBuilder subEach = new StringBuilder();
                   if (RepSubItem != "" && order.Product_OrderInfoList!=null)
                   {                      
                       foreach (Model.Product_OrderInfo orderInfo in order.Product_OrderInfoList)
                       {
                            //{0}--购买数量
                            //{1}--订单明细ID
                            //{2}--单价
                            //{3}--商品名称
                            //{4}--从购物车移除此商品的链接（此链接只负责删除并返回成功或失败，如果有需要请使用ajax来请求或修改链接对应文件的代码）
                           subEach.AppendLine(string.Format(SubItem,
                               orderInfo.BuyCount,
                               orderInfo.ID,
                               orderInfo.Price,
                               orderInfo.ProductName,
                               "/BuyRemove/" + orderInfo.ID.ToString()
                               ));
                       }
                   }
                   each = each.Replace("[SubItem]", subEach.ToString());
               }
               return Template.Replace("{Each}",each.ToString());
           }
           return "未登录";
       }
    }
}
