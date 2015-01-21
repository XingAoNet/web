using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XingAo.Core;
using System.Linq.Expressions;
using XingAo.Core.Data;

namespace XingAo.Networks.CMS.Web.Manager.ProductOrder
{
    public partial class Main : Common.BaseListPage
    {
        public string status;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var where = QueryBuilder.Create<Model.Product_OrderBase>()
                    .Like(c => c.OrderCode, keyString);

                /*
                 * 
                 * 
                 * 以下为高级搜索选项，请自行修改字段名称以及参数值
                 * 
                 * 
                 *
                
                if (!string.IsNullOrEmpty(ClassID) && ClassID != "0")
                    where = where.And(p => p.xxx = xxxx);
                if (!string.IsNullOrEmpty(StartDate))
                    where = where.And(p => p.xxx = xxxx);
                if (!string.IsNullOrEmpty(EndDate))
                    where = where.And(p => p.xxx = xxxx);
                if (!string.IsNullOrEmpty(SetTop) && SetTop != "0")
                    where = where.And(p => p.xxx = xxxx);
                if (!string.IsNullOrEmpty(Pass) && Pass != "0")
                    where = where.And(p => p.xxx = xxxx);
                 *
                 * 
                 * 
                 */
                int State=Request["state"].ObjToInt(0);
                //当ManagerState为0时，查询正常订单信息
                //即：管理员状态为：UnSet（未设置）
                //当ManagerState为1时查询非正常订单
                //即：管理员状态为：UnEnable（管理员置为无效订单）、Doing（管理员置为订单操作中）、Finshed（管理员置为已完成订单）
                int managerState = Request["ManagerState"].ObjToInt(0);
                int r = 0;
                UnitOfWork uk = new UnitOfWork();
                if (managerState > 0)
                {
                    Rep_List.DataSource = uk.LoadWhereLambda<Model.Product_OrderBase>
                        (p => (string.IsNullOrEmpty(keyString) || p.OrderCode.IndexOf(keyString) > 0) &&
                            p.State == State || p.ManagerState > 0,
                            p => p.OrderByDescending(c => c.ID), PageNum, PageSize, out r).ToList();
                }
                else
                {
                    Rep_List.DataSource = uk.LoadWhereLambda<Model.Product_OrderBase>
                        (p => (string.IsNullOrEmpty(keyString) || p.OrderCode.IndexOf(keyString) > 0) &&
                            p.State == State && p.ManagerState == 0,
                            p => p.OrderByDescending(c => c.ID), PageNum, PageSize, out r).ToList();
                }
                TotalCount = r;//绑定前必须给总记录数赋值
                Rep_List.DataBind();
            }
        }
    }
}