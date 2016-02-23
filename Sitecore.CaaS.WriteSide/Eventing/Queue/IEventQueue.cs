using Sitecore.CaaS.WriteSide.Commands;
using System.Threading.Tasks;

namespace Sitecore.CaaS.WriteSide.Eventing.Queue
{
    public interface IEventQueue
    {
        Task<bool> Enqueue(string eventName, ICommandAsync command);
    }
}
