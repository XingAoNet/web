using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XingAo.Core;
using XingAo.Networks.CMS.Model;
using System.Text;
using XingAo.Core.Data;
using System.Data;

namespace XingAo.Networks.CMS.Web.Manager.Custom
{
    public partial class Edit : Common.BaseEditPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int TID = Request.QueryString["TID"].ObjToInt(0);
                UnitOfWork uk = new UnitOfWork();
                
              IEnumerable<Model.CustomTableField> datalist= uk.LoadWhereLambda<Model.CustomTableField>(p => p.TID == TID&&p.ShowEditInForm==1, p => p.OrderBy(c=>c.ShowFormEditIndex), 1, 9999);
              
               

                if (datalist.Count()==0)
                {
                    JUIJsonResult.Err("数据不存在！", "");
                }
                else
                {
                    List<Model.CustomTableField> data = datalist.ToList();
                    string Fields = "";
                    StringBuilder formhtml = new StringBuilder();
                    foreach (CustomTableField f in data)
                    {
                        Model.EditFormControl edit = f.ShowFormEditParJson.JsonToObject<Model.EditFormControl>();
                        formhtml.AppendLine(edit.ToString());
                        Fields += f.FieldName + ",";
                    }
                    Fields_List.Value = Fields;
                    Fields += "ID";
                    FormHtml.Text = formhtml.ToString();
                    int ID = Request.QueryString["ID"].ObjToInt();
                    if (ID > 0)
                    {
                        txt_ID.Value = ID.ToString();
                        //Impl.CustomTableDataRepository rep2 = new Impl.CustomTableDataRepository();
                        string DefaultV = GetDataItem(TID, Fields, ID).Tables[0].ToList().ToJSON();
                        FormHtml.Text += "<script>\nvar DefaultV=" + DefaultV + ";\n</script>";

                    }
                    else
                    {
                        txt_ID.Value = "0";
                        FormHtml.Text += "<script>\nvar DefaultV=undefined;\n</script>";
                    }
                }
            }
        }
        /// <summary>
        /// 取某自定义表的一条数据
        /// </summary>
        /// <param name="TID">自定义表id</param>
        /// <param name="Fields">要读取的字段，空为取所有</param>
        /// <param name="ID">要取数据的id</param>
        /// <returns></returns>
        public DataSet GetDataItem(int TID, string Fields, int ID)
        {
            Dictionary<string, object> par = new Dictionary<string, object>();
            par.Add("TID", TID);
            par.Add("Fields", Fields);
            par.Add("ID", ID);
            return new UnitOfWork().ExecDataSetByPro("Pro_GetCustomTableDataItem", par);
           // return _BaseRepository.GetProDataSet("Pro_GetCustomTableDataItem", par);
        }
    }
}