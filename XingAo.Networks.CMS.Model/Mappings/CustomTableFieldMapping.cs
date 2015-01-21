using System.ComponentModel.Composition;
using XingAo.Core.Data;

namespace XingAo.Networks.CMS.Model.Mappings
{
    /// <summary>
    /// 自定义表关系
    /// </summary>
    [Export("CustomTableFieldMapping")]
    public class CustomTableFieldMapping : MappingBase<CustomTableField>
    {
        public CustomTableFieldMapping()
        {
            //映射表名
            this.ToTable("XA_CMS_CustomTableField");
            //内外键关联
            this.HasRequired(m => m.CustTable).WithMany(m => m.CustomTableFields).HasForeignKey(t => t.TID);
        }
    }
}
