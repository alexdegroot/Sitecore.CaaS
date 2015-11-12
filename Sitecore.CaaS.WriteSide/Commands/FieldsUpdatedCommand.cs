using System;
using System.Collections.Generic;

namespace Sitecore.CaaS.WriteSide.Commands
{
    public class FieldsUpdatedCommand : ItemCommandBase
    {
        public FieldsUpdatedCommand(Guid itemId, Dictionary<Guid, string> fields) : base(itemId)
        {
            Fields = fields;
        }

        public Dictionary<Guid, string> Fields { get; set; }
    }
}
