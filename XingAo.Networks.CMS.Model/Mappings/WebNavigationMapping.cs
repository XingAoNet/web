using System.ComponentModel.Composition;
using XingAo.Core.Data;

namespace XingAo.Networks.CMS.Model.Mappings
{
    [Export("WebNavigationMapping")]
    public class WebNavigationMapping : MappingBase<WebNavigation>
    {
        public WebNavigationMapping()
        {
            this.ToTable("XA_CMS_WebNavigation");
        }
    }
}
