using System.ComponentModel.Composition;
using XingAo.Core.Data;

namespace XingAo.Networks.CMS.Model.Mappings
{
    [Export("FriendLinkMapping")]
    public class FriendLinkMapping : MappingBase<FriendLink>
    {
        public FriendLinkMapping()
        {
            this.ToTable("XA_CMS_FriendLink");
            this.HasRequired(m => m.Groups).WithMany(m => m.FriendLinkList).HasForeignKey(t => t.GroupID);
        }
    }
}
