using System.ComponentModel.Composition;
using XingAo.Core.Data;

namespace XingAo.Networks.CMS.Model.Mappings
{
    [Export("TemplatesMapping")]
    public class TemplatesMapping : MappingBase<Templates>
    {
        public TemplatesMapping()
        {
            this.ToTable("XA_CMS_Templates");
        }
    }
}
