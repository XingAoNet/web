using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XingAo.Core;
using XingAo.Core.Data;
using XingAo.Networks.CMS.Model.Enums;

namespace XingAo.Networks.CMS.Web.Manager.Wechat.Activities.ScratchCard//----------修改命名空间
{
    /// <summary>
    /// SaveDel1 的摘要说明
    /// </summary>
    public class SaveDel : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {
        public string navTabId = "navTab_ScratchCard";//----------修改标签ID
        public void ProcessRequest(HttpContext context)
        {
            string action = context.Request.QueryString["action"];
            string sguid = context.Request.Params["txtSGuid"];
            int id = context.Request.Form["txtID"].ObjToInt();
            string code = "200", msg = "提交成功！", callbackaction = "closeCurrent";
            UnitOfWork uk = new UnitOfWork();
            string tablename = WeiWebEnum.TableNameSwitch(6);
            int TotalGoodsCount = 0;
            List<Model.ScratchCard_Goods> ScratchCard_GoodsList = uk.FindAll<Model.ScratchCard_Goods>().Where(c => c.ScratchCardGuid == sguid && c.ID != id).ToList();//已保存的奖品数
            if (ScratchCard_GoodsList.Count() > 0)
                TotalGoodsCount = ScratchCard_GoodsList.Sum(c => c.GoodsCount).ObjToInt(0);
            if (!string.IsNullOrEmpty(action))//添加或修改
            {
                switch (action)
                {
                    case "Card":
                        #region
                        string key = context.Request.Form["txtKeys"];
                        List<Model.KeywordsIndex> keyList;
                        if (sguid != "")
                            keyList = uk.FindAll<Model.KeywordsIndex>().Where(c => c.KeyWords == key && c.PrimaryValue != sguid).ToList();
                        else
                            keyList = uk.FindAll<Model.KeywordsIndex>().Where(c => c.KeyWords == key).ToList();
                        if (keyList.Count() > 0)
                        {
                            code = "300";
                            msg = "关键字重复";
                            callbackaction = "";
                        }
                        else
                        {
                            if (TotalGoodsCount > context.Request.Form["txtTotalCount"].ObjToInt(0))
                            {
                                context.Response.Write("{\"statusCode\":\" 300 \",\"message\":\"总票数必须大于总奖品数\",\"navTabId\":\"" + navTabId + "\",\"rel\":\"\",\"callbackType\":\"\",\"forwardUrl\":\"\",\"confirmMsg\":\"\"}");
                                context.Response.End();
                            }
                            Model.ScratchCard model;
                            if (id > 0)
                                model = uk.FindSigne<Model.ScratchCard>(p => p.ID == id);
                            else
                            {
                                model = new Model.ScratchCard();
                                model.Creater = "";
                                model.IDateTime = DateTime.Now;
                                model.WGuid = "";
                                model.SGuid = "S" + System.Guid.NewGuid().ToString("N");
                            }
                            model.Title = context.Request.Form["txtTitle"];
                            model.Keys = key;
                            model.StartTime = StringOption.ObjToDate(context.Request.Form["txtStartTime"], DateTime.Now);
                            model.EndTime = StringOption.ObjToDate(context.Request.Form["txtEndTime"], DateTime.Now);
                            model.ParentID = context.Request.Form["txtParentID"].ObjToInt();
                            model.OrderID = context.Request.Form["txtOrderID"].ObjToInt(1000);
                            model.CanUse = context.Request.Form["txtCanUse"].ObjToInt();
                            model.PictureAddress = context.Request.Form["txtPictureAddress"];
                            model.Abstract = context.Request.Form["txtAbstract"];
                            model.AllowVisitedCount = context.Request.Form["txtPersonNum"].ObjToInt(0);
                            model.TotalCount = context.Request.Form["txtTotalCount"].ObjToInt(0);
                            model.DefaultGoodName = context.Request.Form["txtDefaultGoods"];
                            model.InHtml = context.Request.Form["InHmtl"];
                            model.CardBG = context.Request.Form["txtCardBG"];
                            model.MaskCoordinate = context.Request.Form["txtCardBGSelect"];
                            model.CardBGWidthHeight = context.Request.Form["txtCardBGWidthHeight"];
                            model.EditTime = DateTime.Now;
                            model.Editer = "";
                            uk.Save(model, model.ID);
                            Model.KeywordsIndex ki;
                            ki = uk.FindSigne<Model.KeywordsIndex>(c => c.TableName == tablename && c.PrimaryValue == model.SGuid);
                            if (ki == null)
                            {
                                ki = new Model.KeywordsIndex();
                                ki.WGuid = "";
                            }
                            ki.KeyWords = model.Keys;
                            ki.PrimaryValue = model.SGuid;
                            ki.TableName = tablename;
                            uk.Save(ki, ki.ID);
                        }
                        #endregion
                        break;
                    case "Good":
                        #region
                        navTabId = "navTab_GoodsList";
                        string GoodsName = context.Request.Form["txtGoodsName"];
                        string GoodsCount = context.Request.Form["txtGoodsCount"];
                        string UsedCount = context.Request.Form["txtUsedCount"];
                        string AllowMob = context.Request.Form["txtAllowMob"];
                        Model.ScratchCard_Goods Goodsmodel;
                        if (id > 0)
                            Goodsmodel = uk.FindSigne<Model.ScratchCard_Goods>(p => p.ID == id);
                        else
                        {
                            Goodsmodel = new Model.ScratchCard_Goods();
                            Goodsmodel.Creater = "";
                            Goodsmodel.IDateTime = DateTime.Now;
                            Goodsmodel.SGGuid = "S" + System.Guid.NewGuid().ToString("N");
                            Goodsmodel.ScratchCardGuid = sguid;
                            Goodsmodel.WGUID = "";
                        }

                        Goodsmodel.GoodsName = GoodsName;
                        Goodsmodel.GoodsCount = GoodsCount.ObjToInt(0);
                        if (!string.IsNullOrEmpty(AllowMob))
                        {
                            AllowMob = AllowMob.Replace("\r\n", ",").Trim(',');
                        }

                        Goodsmodel.AllowMob = AllowMob;
                        Goodsmodel.EditTime = DateTime.Now;
                        Goodsmodel.Editer = "";

                        int mobileNum = Goodsmodel.AllowMob.Trim(',').Split(',').Length;//手机号码个数
                        int PrizeNum = Goodsmodel.GoodsCount;//默认值：奖品个数
                        int maxValue = 0;
                        int MakedCount = 0;
                        string Num = ",";
                        Model.ScratchCard maindata = uk.FindSigne<Model.ScratchCard>(p => p.SGuid == sguid);
                        if (maindata != null)
                        {
                            maxValue = int.Parse(maindata.TotalCount.ToString());//所有奖品总数
                        }
                        if (maxValue < Goodsmodel.GoodsCount + TotalGoodsCount)
                        {
                            context.Response.Write("{\"statusCode\":\" 300 \",\"message\":\"总票数必须大于总奖品数\",\"navTabId\":\"" + navTabId + "\",\"rel\":\"\",\"callbackType\":\"\",\"forwardUrl\":\"\",\"confirmMsg\":\"\"}");
                            context.Response.End();
                        }
                        if (Goodsmodel.AllowMob.Trim() != "")//如果有手机，生成的个数为：奖品个数-手机号码个数
                        {
                            if (Goodsmodel.GoodsCount > mobileNum)//奖品个数 大于 手机号码个数
                                PrizeNum = Goodsmodel.GoodsCount - mobileNum;
                            else
                                PrizeNum = 0;
                        }

                        maxValue++;
                        var AddedNum = uk.FindAll<Model.ScratchCard_Goods>().Where(p => p.ID != id && p.ScratchCardGuid == sguid);
                        while (MakedCount < PrizeNum)//生成X个奖品的中奖号码（X=奖品数量）
                        {
                            string v = "," + new Random().Next(1, maxValue).ToString() + ",";
                            if (Num.IndexOf(v) == -1 && (AddedNum.Where(p => p.PrizeNum.IndexOf(v) > -1).Count() == 0))
                            {
                                Num = Num.TrimEnd(',') + v;
                                MakedCount++;
                            }
                        }
                        Goodsmodel.PrizeNum = Num;
                        uk.Save(Goodsmodel, Goodsmodel.ID);
                        #endregion
                        break;
                    case "del":
                        msg = "删除成功！";
                        callbackaction = "";
                        string[] ID = context.Request.Form["ids"].Split(',');
                        string[] Guid = uk.FindByFunc<Model.ScratchCard>(p => ID.Contains(p.ID.ToString())).Select(c => c.SGuid).ToArray();
                        uk.Remove<Model.ScratchCard>(p => ID.Contains(p.ID.ToString()));
                        uk.Remove<Model.KeywordsIndex>(p => Guid.Contains(p.PrimaryValue) && p.TableName == tablename);
                        break;

                }

            }

            string err = "";
            uk.Commit(out err);
            if (err != "")
            {
                code = "300";
                msg = err;
            }
            context.Response.Write("{\"statusCode\":\"" + code + "\",\"message\":\"" + msg + "\",\"navTabId\":\"" + navTabId + "\",\"rel\":\"\",\"callbackType\":\"" + callbackaction + "\",\"forwardUrl\":\"\",\"confirmMsg\":\"\"}");
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}