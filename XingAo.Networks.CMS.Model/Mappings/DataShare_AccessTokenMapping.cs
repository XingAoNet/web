using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;
using XingAo.Core.Data;

namespace XingAo.Networks.CMS.Model.Mappings
{
    [Export("DataShare_AccessTokenMapping")]
    public class DataShare_AccessTokenMapping : MappingBase<Model.DataShare_AccessToken>
    {
        public DataShare_AccessTokenMapping()
        {
            this.ToTable("XA_CMS_DataShare_AccessToken");
        }
    }
}