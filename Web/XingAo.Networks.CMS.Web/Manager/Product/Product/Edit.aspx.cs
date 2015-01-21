using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XingAo.Core;
using XingAo.Core.Data;
using System.Text;

namespace XingAo.Networks.CMS.Web.Manager.Product.Product
{
    public partial class Edit : Common.BaseEditPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UnitOfWork uk = new UnitOfWork();
                Rep_List.DataSource = uk.FindAll<Model.Product_AttributeGroup>().ToList();
                Rep_List.DataBind();
                List<Model.Product_Class> AllClass = uk.FindAll<Model.Product_Class>().OrderBy(p => p.ClassCode).ToList();
                string SelectedIds = "";
                int id = Request.QueryString["ID"].ObjToInt(0);
                if (id > 0)
                {
                    txtID.Value = id.ToString();
                    Model.Product_Base model = uk.FindSigne<Model.Product_Base>(p => p.ID == id);
                    if (model != null && model.ID > 0)
                    {
                        txtAttributeGroupID.Text = model.AttributeGroupID.ToString();

                        GetPic(model.PicList);

                        txtPrice.Text = model.Price.ToString();
                        SelectedIds = model.ProductClassIDs.Trim(',');
                        txtProductName.Text = model.ProductName;
                        txtProductNumber.Text = model.ProductNumber;
                        txtRealPrice.Text = model.RealPrice.ToString();
                        txtSellCount.Text = model.SellCount.ToString();
                        txtState.SelectedValue = model.State.ToString();
                        txtTotalCount.Text = model.TotalCount.ToString();
                        txtTotalCount.ReadOnly = true;
                        txtGetPoint.Text = model.GetPoint.ToString();
                        txtMaxPayPoint.Text = model.MaxPayPoint.ToString();
                        StringBuilder AttrNameAndValues = new StringBuilder();
                        foreach (Model.Product_AttributeValues attr in uk.FindByFunc<Model.Product_AttributeValues>(p => p.ProductBaseID == model.ID))
                        {
                            AttrNameAndValues.Append("{\"Key\":\"txt_" + attr.AttrName.ToMD5() + "\",\"Values\":\"" + attr.AttrValue.Replace("\r\n","").Replace("\"","'") + "\"},"); 
                        }
                        ClientScript.RegisterStartupScript(this.GetType(), "Edit", "$(function(){SelectTemplateGroup('" + model.AttributeGroupID.ToString() + "',[" + AttrNameAndValues.ToString().TrimEnd(',') + "]);});", true);                       
                    }
                    else
                        JUIJsonResult.Err("数据不存在！", "");

                }
                txtProductClassIDs.Text = "<div style=\"height:120px;width:80%; overflow:scroll;overflow-x:hidden;border:1px solid #B8D0D6;\">" + MakeClassCheckBox(AllClass, SelectedIds.Split(','), "").ToString() + "</div>";
            }
        }



        private StringBuilder MakeClassCheckBox(List<Model.Product_Class> list, string[] SelectedIDs, string code)
        {
            StringBuilder PClassCheckBox = new StringBuilder();
            IEnumerable<Model.Product_Class> CurrentList;
            if (string.IsNullOrEmpty(code))
                CurrentList = list.Where(p => p.ClassCode.Length == 4);
            else
                CurrentList = list.Where(p => p.ClassCode.Length == code.Length + 4 && p.ClassCode.StartsWith(code));
            foreach(Model.Product_Class model in CurrentList)
            {
                bool haveNext = list.Where(p => p.ClassCode.Length == model.ClassCode.Length + 4 && p.ClassCode.StartsWith(model.ClassCode)).Count() > 0;
                PClassCheckBox.AppendLine("<label>" + (model.ClassCode.Length > 4 ? "".PadRight(model.ClassCode.Length / 2, (char)0xA0) : "") + "<input type=\"checkbox\" value=\"" + model.ID.ToString() + "\" name=\"txtProductClassIDs\" " + (haveNext ? " disabled=\"disabled\"" : "") + (SelectedIDs.Contains(model.ID.ToString()) ? " checked=\"checked\"" : "") + "\" />" + model.ClassName + "</label><br />");
                if (haveNext)
                   PClassCheckBox.AppendLine(MakeClassCheckBox(list, SelectedIDs, model.ClassCode).ToString());
            }
            return PClassCheckBox;
        }

        /// <summary>
        /// 对图片进行赋值
        /// </summary>
        /// <param name="picList"></param>
        private void GetPic(string picList)
        {
            string[] pics = picList.ObjToStr().Split(',');
            TextBox[] txtPicFiles = { txt_PicTitle1, txt_PicTitle2, txt_PicTitle3, txt_PicTitle4, txt_PicTitle5 };
            if (pics.Count() > 0)
            {
                for(int i=0;i<pics.Count()&&i<5;i++)
                {
                    if (!string.IsNullOrEmpty(pics[i]))
                    {
                        txtPicFiles[i].Text = pics[i];
                    }
                }
            }
        }
    }
}