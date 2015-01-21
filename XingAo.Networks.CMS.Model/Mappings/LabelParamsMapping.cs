using System.ComponentModel.Composition;
using XingAo.Core.Data;

namespace XingAo.Networks.CMS.Model.Mappings
{
    [Export("LabelParamsMapping")]
    public class LabelParamsMapping : MappingBase<LabelParams>
    {
        public LabelParamsMapping()
        {
            this.ToTable("XA_CMS_Label_Params");

            this.HasRequired(m => m.Label).WithMany(m => m.Params).HasForeignKey(t => t.LableId);
        }
    }
}
