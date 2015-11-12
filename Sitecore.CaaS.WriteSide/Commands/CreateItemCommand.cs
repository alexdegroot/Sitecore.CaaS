using System;
using System.Collections.Generic;

namespace Sitecore.CaaS.WriteSide.Commands
{
    public class CreateItemCommand : ItemCommandBase
    {
        public CreateItemCommand(Guid itemId, IDictionary<string, object> propertyBag) : base(itemId)
        {
            Properties = propertyBag;
        }

        public IDictionary<string, object> Properties { get; set; }
    }
}
