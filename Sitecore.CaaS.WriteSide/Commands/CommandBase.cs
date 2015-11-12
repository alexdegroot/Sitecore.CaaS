using System.Threading.Tasks;
using Sitecore.CaaS.WriteSide.EventPersistance;

namespace Sitecore.CaaS.WriteSide.Commands
{
    public abstract class CommandBase : ICommandAsync
    {
        public async Task<bool> ExecuteAsync(IEventStore eventStore)
        {
            return await eventStore.StoreEvent(GetType().Name, this);
        }
    }
}