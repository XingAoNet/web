using System.ComponentModel.Composition;
using XingAo.Core.Data;

namespace XingAo.Networks.CMS.Model.Mappings
{

    [Export("OrganizationElectMapping")]
    public class OrganizationElectMapping : MappingBase<OrganizationElect>
    {
        public OrganizationElectMapping()
        {
            this.ToTable("XA_OrganizationElect");
        }
    }
}
