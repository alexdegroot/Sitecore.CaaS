using System;
using System.Collections.Generic;

namespace Sitecore.CaaS.WriteSide.Commands
{
    public class AddVersionCommand : ItemCommandBase
    {
        public AddVersionCommand(Guid itemId, IDictionary<string, string> dimension) : base(itemId)
        {
            Dimension = dimension;
        }

        public IDictionary<string, string> Dimension { get; set; }

    }
}
