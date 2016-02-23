using System.Threading.Tasks;
using Sitecore.CaaS.WriteSide.Commands;
using Sitecore.CaaS.WriteSide.Eventing;

namespace Sitecore.CaaS.WriteSide.Services
{
    public class ItemService
    {
        private readonly IEventHandler _eventHandler;

        public ItemService(IEventHandler eventHandler)
        {
            _eventHandler = eventHandler;
        }

        public bool Execute(ICommandAsync cmd)
        {
            return cmd.ExecuteAsync(_eventHandler).Result;
        }

        protected async Task<bool> ExecuteAsync(ICommandAsync cmd)
        {
            return await cmd.ExecuteAsync(_eventHandler);
        }
    }
}
