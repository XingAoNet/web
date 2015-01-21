using System.ComponentModel.Composition;
using XingAo.Core.Data;

namespace XingAo.Networks.CMS.Model.Mappings
{
    [Export("WeiXin_ReplyMapping")]
    public class WeiXin_ReplyMapping : MappingBase<WeiXin_Reply>
    {
        public WeiXin_ReplyMapping()
        {
            this.ToTable("XA_WeiXin_Reply");
           
        }
    }
}
