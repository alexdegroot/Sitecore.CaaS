using System.Threading.Tasks;
using Sitecore.CaaS.WriteSide.Eventing;

namespace Sitecore.CaaS.WriteSide.Commands
{
    public interface ICommandAsync
    {
        Task<bool> ExecuteAsync(IEventHandler eventHandler);
    }
}