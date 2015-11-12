using System;

namespace Sitecore.CaaS.WriteSide.Commands
{
    public abstract class ItemCommandBase : CommandBase
    {
        protected ItemCommandBase(Guid itemId)
        {
            ItemId = itemId;
        }

        public Guid ItemId { get; set; }
    }
}