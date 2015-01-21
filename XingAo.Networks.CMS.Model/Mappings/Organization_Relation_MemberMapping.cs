using System.ComponentModel.Composition;
using XingAo.Core.Data;

namespace XingAo.Networks.CMS.Model.Mappings
{
    [Export("Organization_Relation_MemberMapping")]
    public class Organization_Relation_MemberMapping : MappingBase<Organization_Relation_Member>
    {
        public Organization_Relation_MemberMapping()
        {
            this.ToTable("XA_Organization_Relation_Member");
        }
    }
}
