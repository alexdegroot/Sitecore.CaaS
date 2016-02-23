using System.Threading.Tasks;
using Sitecore.CaaS.WriteSide.Commands;
using Sitecore.CaaS.WriteSide.Eventing.Persistance;
using Sitecore.CaaS.WriteSide.Eventing.Queue;

namespace Sitecore.CaaS.WriteSide.Eventing
{
    public interface IEventHandler
    {
        Task<bool> HandleEvent(string eventName, ICommandAsync command);
        IEventQueue EventQueue { get; }
        IEventStore EventStore { get; }
    }
}