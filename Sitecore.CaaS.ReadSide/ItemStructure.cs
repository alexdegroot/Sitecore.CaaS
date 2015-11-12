using System;
using System.Collections.Generic;

namespace Sitecore.CaaS.ReadSide
{
    public class MicroItem
    {
        //public IDictionary<string, string> Dimension;
        public IDictionary<string, string> Properties;
        public IDictionary<MicroItemVersionDefinition, MicroItemFieldList> Versions;
    }

    public class MicroItemFieldList : Dictionary<Guid, object>
    {
    }

    public class MicroItemVersionDefinition
    {
        public IDictionary<string, string> Dimensions { get; set; }
        public int VersionNumber { get; set; }
    }
}
