using System.ComponentModel.Composition;
using XingAo.Core.Data;

namespace XingAo.Networks.CMS.Model.Mappings
{
    [Export("ManagerUserMapping")]
    public class ManagerUserMapping : MappingBase<ManagerUser>
    {
        public ManagerUserMapping()
        {
            this.ToTable("XA_CMS_ManagerUser");
        }
    }
}
