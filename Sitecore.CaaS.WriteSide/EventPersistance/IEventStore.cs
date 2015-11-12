using System;
using System.Threading.Tasks;
using Sitecore.CaaS.WriteSide.Commands;

namespace Sitecore.CaaS.WriteSide.EventPersistance
{
    public interface IEventStore
    {
        Task<bool> StoreEvent(string eventName, ICommandAsync command);
        TriggeredQueue<Tuple<string, string>> Events { get; }
    }
}