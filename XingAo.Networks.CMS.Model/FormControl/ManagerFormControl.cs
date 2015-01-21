using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Web;
using System.Xml.Linq;

namespace XingAo.Networks.CMS.Model
{
    /// <summary>
    /// 表单控件类型枚举
    /// </summary>
    public enum FormControlTypeEnum
    {
        /// <summary>
        /// 单行文本框
        /// </summary>
        [Description("单行本框")]
        Textbox = 0,
        ///// <summary>
        ///// 单选框
        ///// </summary>
        //[Description("单选框")] 
        //Radio,
        /// <summary>
        /// 下拉框
        /// </summary>
        [Description("下拉框")]
        Droupdownlist = 1,
        /// <summary>
        /// 多选框
        /// </summary>
        [Description("多选框")]
        Checkbox = 2,
        /// <summary>
        /// 多行文本框
        /// </summary>
        [Description("多行文本框")]
        MultilineTextbox = 3,
        ///// <summary>
        ///// 隐藏域
        ///// </summary>
        //[Description("隐藏域")]
        //HiddenFields,
        /// <summary>
        /// 单图片文件上传框
        /// </summary>
        [Description("单图片文件上传框")]
        PicFile = 4,
        /// <summary>
        /// 多图片文件上传框
        /// </summary>
        [Description("多图片文件上传框")]
        PicFiles = 5,
        /// <summary>
        /// 单附件上传框
        /// </summary>
        [Description("单附件上传框")]
        AttachmentFile = 6,
        /// <summary>
        /// 多附件上传框
        /// </summary>
        [Description("多附件上传框")]
        AttachmentFiles = 7,
        /// <summary>
        /// 富文本框
        /// </summary>
        [Description("富文本框")]
        RichTextbox = 8,
        /// <summary>
        /// 查找并带回（dwz【jui】特有控件，点击时弹出窗口，选择后关闭）
        /// </summary>
        [Description("查找并带回")]
        lookupGroup = 9


        //警告：为防止对现有数据破坏，请强制为枚举赋值
    }


    /// <summary>
    /// 后台编辑页面表单控件实体类
    /// </summary>
    public class EditFormControl
    {
        private static  readonly string xmlpath = "/Config/EditFormControlSet.config";
        private static XElement xd = XElement.Load(HttpContext.Current.Server.MapPath(xmlpath));
        /// <summary>
        /// 表单对应字段名
        /// </summary>
        public string FieldName { get; set; }
       /// <summary>
       /// 表单生成项的文本（如：姓名:＜ｉｎｔｐｕ　ｔｙｐｅ＝＇ｔｅｘｔ＇＞中的姓名【注意：不用带冒号】）
       /// </summary>
       public string FormTxt { get; set; }
       /// <summary>
       /// 表单控件类型，比如单选、多选、文本等（详细参照FormControlTypeEnum枚举）
       /// </summary>
       public FormControlTypeEnum ControlType { get; set; }
       /// <summary>
       /// 表单控件数据验证类型，比如非空、时间、整数等（详细参照DataValidationEnum枚举）
       /// </summary>
       public DataValidationEnum DataValidation { get; set; }
       /// <summary>
       /// 当验证类别为与某控件作比较时，此处为被比较控件的ID，或者在验证大于10时，来保存10这个值
       /// </summary>
       public string DataValidationCompareID { get; set; }
       /// <summary>
       /// 控件要绑定数据时（表名|绑定值|绑定文本||自定义绑定文本|自定义值|自定义绑定文本2|自定义值2...）【注意，如果控件类型为FormControlTypeEnum.lookupGroup时，此处用于“查找并带回”功能所指向的链接地址，具体参看“查找并带回”控件的写法】
       /// </summary>
       public string DataBindTableTxtFieldValue { get; set; }
        /// <summary>
        /// 生成控件时的宽度，可以用数字或百分比
        /// </summary>
       public string Width { get;set; }
       /// <summary>
       /// 生成控件时的高度，可以用数字或百分比
       /// </summary>
       public string Height { get; set; }
        /// <summary>
       /// 是否使用P标签与label标签来生成表单的项（否的话以dt dd dl来生成）
        /// </summary>
       public bool UseTag_P { get; set; }
        /// <summary>
       /// 是否在当前项生成完成后，加一条线【只在UseTag_P为true时使用有效】
        /// </summary>
       public bool DrawLineAfter { get; set; }
        /// <summary>
        /// 操作符，如：等于、大于、小于、in、like.....
        /// </summary>
       public string SeachOpt { get; set; }
       /// <summary>
       /// 默认值
       /// </summary>
       public string DefaultValue { get; set; }
       /// <summary>
       /// 是否可编辑
       /// </summary>
       public bool IsEdit { get; set; }
       /// <summary>
       /// 根据属性生成表单项
       /// </summary>
       /// <returns></returns>
       public override string ToString()
       {
           string TempLate = "<dl>\r\n<dt>{0}：</dt>\r\n<dd[Width]>\r\n{1}\r\n</dd>\r\n</dl>\r\n";//{0}--文本，{1}--控件
           if (UseTag_P)
               TempLate = "<p>\r\n<label>{0}：</label>\r\n{1}</p>\r\n";//{0}--文本，{1}--控件

           XElement element = xd.Elements(ControlType.ToString().ToLower()).FirstOrDefault();
           XElement attr = element.Element("ShowAttr");
           StringBuilder temp = new StringBuilder(element.Element("Template").Value);
           StringBuilder Attributes = new StringBuilder();
           bool haveClass = false;
           foreach (var nodel in attr.Elements())
           {

               if (nodel.Name.ToString().ToLower() == "class")
               {
                   haveClass = true;
                   Attributes.Append(nodel.Name.ToString() + "=\"{DataValidationClass} " + nodel.Value + "\" ");
               }
               else
                   Attributes.Append(nodel.Name.ToString() + "=\"" + nodel.Value + "\" ");
           }
           Attributes = Attributes.Append(" name=\"txt_"+FieldName+"\" ");
           Attributes = Attributes.Replace("{ID}", "txt_" + FieldName);
           if (Width == "")
           {
               Attributes = Attributes.Replace("{Width}px", "auto");
               Attributes = Attributes.Replace("{Width}%", "auto");
               TempLate = TempLate.Replace("<dd[Width]>","");
           }
           else
           {
               Attributes = Attributes.Replace("{Width}px", Width);
               Attributes = Attributes.Replace("{Width}%", Width);
               Attributes = Attributes.Replace("{Width}", Width);
               TempLate = TempLate.Replace("<dd[Width]>", "<dd style=\"width:80%\">");
           }
           if (Height == "")
           {
               Attributes = Attributes.Replace("{Height}px", "auto");
               Attributes = Attributes.Replace("{Height}%", "auto");
           }
           else
           {
               Attributes = Attributes.Replace("{Height}px", Height);
               Attributes = Attributes.Replace("{Height}%", Height);
               Attributes = Attributes.Replace("{Height}", Height);
           }
           string DataValidationStr = DataValidation.ToString().ToLower();
           if (DataValidationStr.IndexOf("_class") > 0)
           {
               if (haveClass)
                   Attributes = Attributes.Replace("{DataValidationClass}", DataValidationStr.Split('_')[0]);
               else
                   Attributes = Attributes.Append("class=\"" + ((DataValidation == DataValidationEnum.digits_class || DataValidation == DataValidationEnum.number_class) ? "required " : "") + DataValidationStr.Split('_')[0] + "\" ");
           }
           else if (DataValidationStr.IndexOf("_attr") > 0)
           {
               Attributes = Attributes.Append(DataValidationStr.Split('_')[0] + "=\"" + DataValidationCompareID + "\" ");
           }
           else
               Attributes = Attributes.Replace("{DataValidationClass}", "");
           if (!string.IsNullOrEmpty(DataBindTableTxtFieldValue))
           {
               if (this.ControlType == FormControlTypeEnum.lookupGroup)
               {
                   temp = temp.Replace("{DataBind}", DataBindTableTxtFieldValue);
               }
               else
               {
                   if (Attributes.ToString().IndexOf("class=\"") > 0)
                       Attributes = Attributes.Replace("class=\"", "class=\"Bind ");
                   else
                       Attributes = Attributes.Append("class=\"Bind\" ");
                   Attributes.Append("DataBind=\"" + DataBindTableTxtFieldValue + "\" ");
               }
           }
           temp = new StringBuilder(temp.ToString().Replace("{0}", Attributes.ToString()).Replace("{ID}","txt_"+FieldName));
           
           return string.Format(TempLate, FormTxt, temp.Replace("[", "<").Replace("]", ">")) + ((DrawLineAfter&&UseTag_P) ? "<div class=\"divider\"></div>" : "");
       }
    }
}
