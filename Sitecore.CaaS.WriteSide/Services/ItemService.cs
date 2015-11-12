using System.Threading.Tasks;
using Sitecore.CaaS.WriteSide.Commands;
using Sitecore.CaaS.WriteSide.EventPersistance;

namespace Sitecore.CaaS.WriteSide.Services
{
    public class ItemService
    {
        private readonly IEventStore _eventStore;

        public ItemService(IEventStore eventStore)
        {
            _eventStore = eventStore;
        }

        public bool Execute(ICommandAsync cmd)
        {
            return cmd.ExecuteAsync(_eventStore).Result;
        }

        public async Task<bool> ExecuteAsync(ICommandAsync cmd)
        {
            return await cmd.ExecuteAsync(_eventStore);
        }
    }
}
