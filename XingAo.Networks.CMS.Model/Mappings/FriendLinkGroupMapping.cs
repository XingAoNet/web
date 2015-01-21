using System.ComponentModel.Composition;
using XingAo.Core.Data;

namespace XingAo.Networks.CMS.Model.Mappings
{
    [Export("FriendLinkGroupMapping")]
    public class FriendLinkGroupMapping : MappingBase<FriendLinkGroup>
    {
        public FriendLinkGroupMapping()
        {
            this.ToTable("XA_CMS_FriendLinkGroup");
        }
    }
}
