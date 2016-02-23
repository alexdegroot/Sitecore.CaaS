using System.Threading.Tasks;
using Sitecore.CaaS.WriteSide.Eventing;

namespace Sitecore.CaaS.WriteSide.Commands
{
    public abstract class CommandBase : ICommandAsync
    {
        public async Task<bool> ExecuteAsync(IEventHandler eventHandler)
        {
            return await eventHandler.HandleEvent(GetType().Name, this);
        }
    }
}