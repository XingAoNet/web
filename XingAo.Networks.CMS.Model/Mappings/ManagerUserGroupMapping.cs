using System.ComponentModel.Composition;
using XingAo.Core.Data;

namespace XingAo.Networks.CMS.Model.Mappings
{
    [Export("ManagerUserGroupMapping")]
    public class ManagerUserGroupMapping : MappingBase<ManagerUserGroup>
    {
        public ManagerUserGroupMapping()
        {
            this.ToTable("XA_CMS_ManagerUserGroup");
        }
    }
}