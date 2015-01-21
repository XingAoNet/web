using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;
using XingAo.Networks.CMS.InterFace;
using XingAo.Networks.CMS.Model;

namespace XingAo.Networks.CMS.Model.Mappings
{
    [Export("WeiXin_ArticleMapping")]
    public class WeiXin_ArticleMapping : MappingBase<WeiXin_Article>
    {
        public WeiXin_ArticleMapping()
        {
            this.ToTable("XA_WeiXin_Article");
           
        }
    }
}
